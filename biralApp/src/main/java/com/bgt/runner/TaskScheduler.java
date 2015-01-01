package com.bgt.runner;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.TimerTask;

import javax.annotation.Resource;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.ShuffleList;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.AppMain;
import com.bgt.mybatis.service.IpInfoDao;
import com.bgt.mybatis.service.ServerInfoDao;
import com.bgt.mybatis.service.TaskDao;
import com.bgt.mybatis.service.TaskScheduleDao;
import com.bgt.mybatis.service.TaskStatusDao;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.mybatis.vo.Task;
import com.bgt.mybatis.vo.TaskSchedule;

/**
 * TaskList 생성룰
 * 1. 한시간 작업량 기준
 * 1. 총 작업건수는 Naver|Daum 한쪽으로 25개이상 안되도록 한다.
 * 2. 한쪽의 일정비율(20%)을 Robot으로 수행
 * 
 * 3. IP당 1시간 
 * **IP는 
 * @author jinnonsbox
 * 생성일 : 2014. 11. 1.
 */
public class TaskScheduler  extends TimerTask {
	
	static boolean instanceRunning = false;
	Date now; // to display current time

	static Logger Log = Logger.getLogger(TaskScheduler.class);
	@Autowired ApplicationContext cxt;

	@Resource(name = "taskDao")
	public TaskDao taskDao;
	
	@Resource(name = "taskStatusDao")
	public TaskStatusDao taskStatusDao;
	
	@Resource(name = "ipInfoDao")
	public IpInfoDao ipInfoDao;
	
	@Resource(name = "ServerInfoDao")
	public ServerInfoDao serverInfoDao;
	
	@Resource(name = "taskScheduleDao")
	public TaskScheduleDao taskScheduleDao;

//	public void doTask() {
//		taskDao = (TaskDao)cxt.getBean("taskDao");
//		List<com.bgt.mybatis.vo.Task> taskList =  taskDao.selectAllTask();
//		for (com.bgt.mybatis.vo.Task task : taskList) {
//			LOGGER.info(task.toString());
//		}
//	}
	
	
	public TaskScheduler(ApplicationContext cxt) {
		this.cxt = cxt;
		initialize();
	}
	
	private void initialize() {
		taskDao = (TaskDao)cxt.getBean("taskDao");
		taskStatusDao = (TaskStatusDao)cxt.getBean("taskStatusDao");
		ipInfoDao = (IpInfoDao)cxt.getBean("ipInfoDao");
		serverInfoDao = (ServerInfoDao)cxt.getBean("serverInfoDao");
		taskScheduleDao = (TaskScheduleDao)cxt.getBean("taskScheduleDao");
	}
	
	
	/** 
	 * task_status 테이블에서 최종일자/시간을 받아서 그 다음다음 시간작업을 취한다.
	 * @return
	 */
	private String getNextDateTime() {
		String nextDate = taskStatusDao.selectMaxDate();
		
		return nextDate;
	}
	
	private String getCurDateTime() {
		String curDate = taskStatusDao.selectCurDate();
		
		return curDate;
	}
	
	private boolean IsScheduleReady(String executeDate, int workHour) {
		boolean result = false;
		try {
			List<TaskSchedule> scheduleList = taskScheduleDao.selectByDateTime(executeDate, workHour);
			result =  (scheduleList !=null && scheduleList.size()>0);
		} catch (Exception e) {
			Log.error("IsScheduleReady no data",e);
		}
		
		return result;
	}
	
	private List<IpInfo> srcIpList = new ArrayList<IpInfo>();
	private List<ServerInfo> srcServerList = new ArrayList<ServerInfo>();

	private List<TaskSchedule> taskScheduleMobileList = new ArrayList<TaskSchedule>();
	private List<TaskSchedule> taskScheduleWebList = new ArrayList<TaskSchedule>();
	
	private boolean insertTaskSchedule() {
		boolean result = true;
		
		for (TaskSchedule schedule : taskScheduleMobileList) {
			taskScheduleDao.delete(schedule);
			schedule.setUpdateDate(Utils.getFullDateStr());
			 result = (0 > taskScheduleDao.insert(schedule));
		}
		for (TaskSchedule schedule : taskScheduleWebList) {
			taskScheduleDao.delete(schedule);
			schedule.setUpdateDate(Utils.getFullDateStr());
			 result = (0 > taskScheduleDao.insert(schedule));
		}
		return result;
	}
	/**
	 * 1.1. 
 server id - ip를 맵핑한다.
 1.1.1. server list 조회  List<String> serverList
 1.1.2. ip list를 조회 serverList에 맵핑
       ip list를 랜덤처리후 맵핑 
       web/mobile 별도
       List<TaskSchedule> taskScheduleMobileList
       List<TaskSchedule> taskScheduleWebList
1.1.3. task list를 조회
      조회기준: mobile/web, hour00_hit_count > 0
      taskId, curCount, max Count, naver/daum
      시간당 
      
      if  ip갯수 * 50 <= total_task_hit_count ==> 경고 메시지 "IP추가 필요"
      
      task list 에 robot(naver, daum)을 max Count=60으로 설정
       0.2*(naver/daum task count) 갯수만큼 추가한다.
	  * salting처리
	  각 IP별 naver/daum별로 25건이 넘으면 더이상 채우지 않고 타사 또는 robot task를 추가
	  ex)  if naver_count > 25 
	            if task == naver robot or task == daum
	                add list
	    
      각각 25건이 넘어가면 그 이상은 salting을 한다. salting후 60건을 초과하면 
      초과분은 제외한다.
        
      1.1.3.1. ip당 하나씩  랜덤 task목록에서 task를 가져감
      				task가져갈때 마다. taskSchedule taskList에 hexa값으로 추가
      				total_task_task 건수 < 50인 경우
      				
           if curCount < maxCount {
           		if task == naver robot
           		    add list 
           		if task == daum robot
           		    add list
           		if task == naver or daum
           		    if ip daum task count or naver task count > 25
           				skip
           		    else 
           		        add list
           }  
	 * @param serverId
	 * @param ipAddress
	 */
	public void generateTaskList(boolean isNow) {
		
		srcIpList.clear();
		srcServerList.clear();
		taskScheduleMobileList.clear();
		taskScheduleWebList.clear();

		
		int totalMobileCapacity = 0; //ip갯수 * 50
		int totalMobileNaverTaskCount = 0;
		int totalMobileDaumTaskCount = 0;

		int totalMobileNaverHitCount = 0;
		int totalMobileDaumHitCount = 0;
		
		int avgMobileNaverHitCount = 0;
		int avgMobileDaumHitCount = 0;
		
		int totalMobileNaverRobotHitCount = 0;
		int totalMobileDaumRobotHitCount = 0;
		
		int totalMobileNaverRobotTaskCount = 0;
		int totalMobileDaumRobotTaskCount = 0;

		
		int totalWebCapacity = 0; //ip갯수 * 50
		int totalWebNaverTaskCount = 0;
		int totalWebDaumTaskCount = 0;

		int totalWebNaverHitCount = 0;
		int totalWebDaumHitCount = 0;
		
		int avgWebNaverHitCount = 0;
		int avgWebDaumHitCount = 0;
		
		int totalWebNaverRobotHitCount = 0;
		int totalWebDaumRobotHitCount = 0;

		
		int totalWebNaverRobotTaskCount = 0;
		int totalWebDaumRobotTaskCount = 0;
		
		
		////////////////////////////////////////////////////////////////////////////////////
		// 시간 설정
		////////////////////////////////////////////////////////////////////////////////////
		//즉시기동이면 현재시간 데이터를 확인
		//없으면 현재데이터 생성
		//schedule에 의한 기동이면 매시 50분 기동 다음시간 데이터를 확인 없으면 다음시간 데이터 생성
		String executeTime= getNextDateTime();
		String executeDate = executeTime.substring(0,8);
		int workHour = Integer.parseInt(executeTime.substring(8));
		if (isNow) {
			executeTime= getCurDateTime();
			executeDate = executeTime.substring(0,8);
		} else {
			executeTime= getNextDateTime();
			executeDate = executeTime.substring(0,8);
		}
		workHour = Integer.parseInt(executeTime.substring(8));
		
		if (IsScheduleReady(executeDate, workHour)) {
			Log.info(String.format("스케줄데이터 이미 생성 executeDate[%s]workHour[%d]", executeDate, workHour));
			return;
		}
		
		////////////////////////////////////////////////////////////////////////////////////
		//그룹별 task수 hit수 산출
		////////////////////////////////////////////////////////////////////////////////////
		List<Task> taskMobileList = taskDao.selectAvailMobileList(workHour);
		List<Task> taskWebList = taskDao.selectAvailWebList(workHour);
		
		for (Task item : taskMobileList) {
			if (item.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
				totalMobileNaverTaskCount ++;
				totalMobileNaverHitCount += item.getHourHitCount();
			} else if (item.getSiteType().equals(CommonConst.SITE_DAUM.get())) {
				totalMobileDaumTaskCount ++;
				totalMobileDaumHitCount += item.getHourHitCount();
			}
		}
		for (Task item : taskWebList) {
			if (item.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
				totalWebNaverTaskCount ++;
				totalWebNaverHitCount += item.getHourHitCount();
			} else if (item.getSiteType().equals(CommonConst.SITE_DAUM.get())) {
				totalWebDaumTaskCount ++;
				totalWebDaumHitCount += item.getHourHitCount();
			}
		}
		
		////////////////////////////////////////////////////////////////////////////////////
		// 스케줄 목록 생성(프로세스id - ip주소 - 실행일자 - 실행시간)
		////////////////////////////////////////////////////////////////////////////////////
		//TODO 현재 프로세스ID기준이나, 추후 IP기준으로 변경할것
		
		srcIpList = ipInfoDao.selectAllIpInfo();
		
		srcServerList = serverInfoDao.selectAll();

		//serverId가 갯수가 적어 iplist랜덤처리할때 모바일 또는 웹 한쪽으로 몰릴수있어
		//최수갯수 지정 0으로 환산되면 2로 보정
		int minMobileServerCount =(srcServerList.size() * taskMobileList.size())/(taskMobileList.size() + taskWebList.size());
		minMobileServerCount = (minMobileServerCount==0)?2:minMobileServerCount;
		int minWebServerCount = srcServerList.size() - minMobileServerCount;
				//(srcServerList.size() * taskWebList.size())/(taskMobileList.size() + taskWebList.size());
		minWebServerCount = (minWebServerCount==0)?2:minWebServerCount;

		//1.1. server id - ip를 맵핑한다.
		ShuffleList.shuffleList(srcIpList);
		int i = 0;
		Iterator<IpInfo> srcIpIt = srcIpList.iterator();
		for (ServerInfo item : srcServerList) {
			while (srcIpIt.hasNext()) {
				IpInfo srcIpInfo = srcIpIt.next();
				if (srcIpInfo.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
					//남은 serverId갯수가 최소갯수보다 적어지는걸 방지
					if (srcServerList.size()-taskScheduleMobileList.size() <= minWebServerCount) continue; 
					taskScheduleMobileList.add(new TaskSchedule(item.getServerId(), srcIpInfo, executeDate, workHour));
					break;
				} else {
					//남은 serverId갯수가 최소갯수보다 적어지는걸 방지
					if (srcServerList.size()-taskScheduleWebList.size() <= minMobileServerCount) continue; 
					taskScheduleWebList.add(new TaskSchedule(item.getServerId(), srcIpInfo, executeDate, workHour));
					break;
				}
			}
		}
		
		////////////////////////////////////////////////////////////////////////////////////
		//총 용량 구하기
		////////////////////////////////////////////////////////////////////////////////////
		totalMobileCapacity = taskScheduleMobileList.size()
				*CommonConst.MAX_TASK_ACTIVITY_PER_MIN.val();
		totalWebCapacity = taskScheduleWebList.size()
				*CommonConst.MAX_TASK_ACTIVITY_PER_MIN.val();
		
		////////////////////////////////////////////////////////////////////////////////////
		//  task list 에 robot(naver, daum)을 max Count=60으로 설정
		//	       0.2*(naver/daum task count) 갯수만큼 추가한다.
		//		  * salting처리
		//		  각 IP별 naver/daum별로 25건이 넘으면 더이상 채우지 않고 타사 또는 robot task를 추가
		//		  ex)  if naver_count > 25 
		//		            if task == naver robot or task == daum
		//		                add list
		//		    
		//  각각 25건이 넘어가면 그 이상은 salting을 한다. salting후 60건을 초과하면 
		//  초과분은 제외한다.
		////////////////////////////////////////////////////////////////////////////////////
		if (totalMobileCapacity < (totalMobileNaverHitCount+totalMobileDaumHitCount)) {
			Log.warn(String.format("IP추가 필요 totalMobileCapacity[%d] totalMobileTaskTodoCount[%d] "
					, totalMobileCapacity, (totalMobileNaverHitCount+totalMobileDaumHitCount)));
		}
		if (totalWebCapacity < (totalWebNaverHitCount+totalWebDaumHitCount)) {
			Log.warn(String.format("IP추가 필요 totalWebCapacity[%d] totalWebTaskTodoCount[%d] "
					, totalWebCapacity, (totalWebNaverHitCount+totalWebDaumHitCount)));
		}
		
		/////////////////////////////////////////////////////////////////////////
		//각 4그룹은 각각 25개를 최대 한계치로 설정한다.
		//
		/////////////////////////////////////////////////////////////////////////
		//mobile naver robot task 갯수 구하기
		//1.초과
		if (totalMobileNaverHitCount > taskScheduleMobileList.size() * CommonConst.MAX_HIT_ACTIVITY_PER_MIN.val()) {
			totalMobileNaverRobotHitCount = totalMobileCapacity*totalMobileNaverHitCount/(totalMobileNaverHitCount+totalMobileDaumHitCount)
					- totalMobileNaverHitCount  + 1;
			totalMobileNaverRobotTaskCount = totalMobileNaverTaskCount*50/100;
		} else if (totalMobileNaverTaskCount == 0) {
			totalMobileNaverRobotHitCount = 0;
			totalMobileNaverRobotTaskCount = 0;
		} else {
			avgMobileNaverHitCount = totalMobileNaverHitCount/totalMobileNaverTaskCount;
			totalMobileNaverRobotHitCount = totalMobileCapacity*totalMobileNaverHitCount/(totalMobileNaverHitCount+totalMobileDaumHitCount)
					- totalMobileNaverHitCount  + 1;
			totalMobileNaverRobotTaskCount = totalMobileNaverRobotHitCount/avgMobileNaverHitCount;
		}
		//mobile daum robot task 갯수 구하기
		if (totalMobileDaumHitCount > taskScheduleMobileList.size() * CommonConst.MAX_HIT_ACTIVITY_PER_MIN.val()) {
			totalMobileDaumRobotHitCount = totalMobileCapacity*totalMobileDaumHitCount/(totalMobileNaverHitCount+totalMobileDaumHitCount)
					- totalMobileDaumHitCount  + 1;
			totalMobileDaumRobotTaskCount = totalMobileDaumTaskCount*50/100;
		} else if (totalMobileDaumTaskCount == 0) {
			totalMobileDaumRobotHitCount = 0;
			totalMobileDaumRobotTaskCount = 0;		
		} else {
			avgMobileDaumHitCount = totalMobileDaumHitCount/totalMobileDaumTaskCount;
			totalMobileDaumRobotHitCount = totalMobileCapacity*totalMobileDaumHitCount/(totalMobileNaverHitCount+totalMobileDaumHitCount)
					- totalMobileDaumHitCount  + 1;
			totalMobileDaumRobotTaskCount = totalMobileDaumRobotHitCount/avgMobileDaumHitCount;
		}		
		//web naver robot task 갯수 구하기
		if (totalWebNaverHitCount > taskScheduleWebList.size() * CommonConst.MAX_HIT_ACTIVITY_PER_MIN.val()) {
			totalWebNaverRobotHitCount =  totalWebCapacity*totalWebNaverHitCount/(totalWebNaverHitCount+totalWebDaumHitCount)
					- totalWebNaverHitCount  + 1;
			totalWebNaverRobotTaskCount = totalWebNaverTaskCount*50/100;
		} else if (totalWebNaverTaskCount == 0) {
			totalWebNaverRobotHitCount =  0;
			totalWebNaverRobotTaskCount = 0;		
		} else {
			avgWebNaverHitCount    = totalWebNaverHitCount/totalWebNaverTaskCount;
			totalWebNaverRobotHitCount =  totalWebCapacity*totalWebNaverHitCount/(totalWebNaverHitCount+totalWebDaumHitCount)
					- totalWebNaverHitCount  + 1;
			totalWebNaverRobotTaskCount    = totalWebNaverRobotHitCount/avgWebNaverHitCount;
		}
		//web daum robot task 갯수 구하기
		if (totalWebDaumHitCount > taskScheduleWebList.size() * CommonConst.MAX_HIT_ACTIVITY_PER_MIN.val()) {
			totalWebDaumRobotHitCount =  totalWebCapacity*totalWebDaumHitCount/(totalWebNaverHitCount+totalWebDaumHitCount)
					- totalWebDaumHitCount  + 1;
			totalWebDaumRobotTaskCount = totalWebDaumTaskCount*50/100;
		} else if (totalWebDaumTaskCount == 0) {
			totalWebDaumRobotHitCount =  0;
			totalWebDaumRobotTaskCount = 0;		
		} else {
			avgWebDaumHitCount    = totalWebDaumHitCount/totalWebDaumTaskCount;
			totalWebDaumRobotHitCount =  totalWebCapacity*totalWebDaumHitCount/(totalWebNaverHitCount+totalWebDaumHitCount)
					- totalWebDaumHitCount  + 1;
			totalWebDaumRobotTaskCount = totalWebDaumRobotHitCount/avgWebDaumHitCount;
		}
		
		//daum/naver, robot daum/robot naver 모두 골고루 배분된 후 남는 건수를 robot daum/robot naver 둘중 적은 쪽에 배분
		int addMobileCnt = totalMobileCapacity
				- (totalMobileDaumHitCount+totalMobileNaverHitCount+totalMobileNaverRobotHitCount+totalMobileDaumRobotHitCount);
		if (addMobileCnt > 0) {
			if (totalMobileNaverRobotHitCount>totalMobileDaumRobotHitCount)
				totalMobileDaumRobotHitCount += addMobileCnt;
			else
				totalMobileNaverRobotHitCount += addMobileCnt;
		}
		int addWebCnt = totalWebCapacity
				- (totalWebDaumHitCount+totalWebNaverHitCount+totalWebNaverRobotHitCount+totalWebDaumRobotHitCount);
		if (addWebCnt > 0) {
			if (totalWebNaverRobotHitCount>totalWebDaumRobotHitCount)
				totalWebDaumRobotHitCount += addWebCnt;
			else
				totalWebNaverRobotHitCount += addWebCnt;
		}
			
		//naver mobile robot 추가
		int remainingHitCount = totalMobileNaverRobotHitCount;
		int randomHitCount = 0;
		for (int j = 0; j < totalMobileNaverRobotTaskCount; j++) {
			randomHitCount = Utils.randInt(0, (remainingHitCount>30?30:remainingHitCount));
			remainingHitCount -= randomHitCount;
			taskMobileList.add(new Task(taskMobileList.get(0),CommonConst.SITE_NAVER.get(), executeDate, randomHitCount));
		}
		//daum mobile robot 추가
		remainingHitCount = totalMobileDaumRobotHitCount;
		randomHitCount = 0;
		for (int j = 0; j < totalMobileDaumRobotTaskCount; j++) {
			randomHitCount = Utils.randInt(0, (remainingHitCount>30?30:remainingHitCount));
			remainingHitCount -= randomHitCount;
			taskMobileList.add(new Task(taskMobileList.get(0),CommonConst.SITE_DAUM.get(), executeDate, randomHitCount));
		}
		ShuffleList.shuffleList(taskMobileList);

		//naver web robot 추가
		remainingHitCount = totalWebNaverRobotHitCount;
		randomHitCount = 0;
		for (int j = 0; j < totalWebNaverRobotTaskCount; j++) {
			randomHitCount = Utils.randInt(0, (remainingHitCount>30?30:remainingHitCount));
			remainingHitCount -= randomHitCount;
			taskWebList.add(new Task(taskWebList.get(0),CommonConst.SITE_NAVER.get(), executeDate, randomHitCount));
		}
		//daum web robot 추가
		remainingHitCount = totalWebDaumRobotHitCount;
		randomHitCount = 0;
		for (int j = 0; j < totalWebDaumRobotTaskCount; j++) {
			randomHitCount = Utils.randInt(0, (remainingHitCount>30?30:remainingHitCount));
			remainingHitCount -= randomHitCount;
			taskWebList.add(new Task(taskWebList.get(0),CommonConst.SITE_DAUM.get(), executeDate, randomHitCount));
		}
		ShuffleList.shuffleList(taskWebList);
		
		int testMobileCount = 0;
		for (Task task : taskMobileList) {
			testMobileCount += task.getHourHitCount();
		}
		int testWebCount = 0;
		for (Task task : taskWebList) {
			testWebCount += task.getHourHitCount();
		}

		/*
 	      1.1.3.1. ip당 하나씩  랜덤 task목록에서 task를 가져감
			task가져갈때 마다. taskSchedule taskList에 hexa값으로 추가
			total_task_task 건수 < 50인 경우
			
		 if curCount < maxCount {
		 		if task == naver robot
		 		    add list 
		 		if task == daum robot
		 		    add list
		 		if task == naver or daum
		 		    if ip daum task count or naver task count > 25
		 				skip
		 		    else 
		 		        add list
		 }  
		 */

		for (TaskSchedule schedule : taskScheduleMobileList) {
			if (taskMobileList.size() ==0) {
				taskScheduleMobileList.clear();
				Log.info(String.format("모바일 업무 스케줄 추가건 없음 executeDate[%s]workHour[%d]", executeDate, workHour));
				break;
			}

			while(true) {
				if (schedule.getJobList().split(CommonConst.TASK_LIST_DELIMITER.get()).length < 60) {
					ShuffleList.shuffleList(taskMobileList);
					fillMobileTaskList(schedule, taskMobileList);
				} else 
					break;
			}
		}//for (TaskSchedule schedule
		

		for (TaskSchedule schedule : taskScheduleWebList) {
			if (taskWebList.size() == 0) {
				taskScheduleWebList.clear();
				Log.info(String.format("웹 업무 스케줄 추가건 없음 executeDate[%s]workHour[%d]", executeDate, workHour));
				break;
			}
			
			while(true) {
				if (schedule.getJobList().split(CommonConst.TASK_LIST_DELIMITER.get()).length < 60) {
					ShuffleList.shuffleList(taskWebList);
					fillWebTaskList(schedule, taskWebList);
				} else 
					break;
			}
		}//for (TaskSchedule schedule
		//
	}

	private void fillMobileTaskList(TaskSchedule schedule, List<Task> taskMobileList) {
		int taskCount = schedule.getJobList().split(CommonConst.TASK_LIST_DELIMITER.get()).length;
//		int curMobileNaverCount = 0;
//		int curMobileDaumCount = 0;

		for (Task task : taskMobileList) {
			if (taskCount >= 60) break;
			
			if (task.getHourHitCount() <=  task.getTempHitCount()) {
				continue;
			}
			
			//if (task.getTaskType().equals(CommonConst.TASK_ROBOT.get())) {
//			if (task.getTaskId() > CommonConst.TASK_ID_WEB_NAVER_00.val()) {
//				Utils.addTaskToSchedule(schedule, task);
//				continue;
//			}
			
//			if (task.getSiteType().equals(CommonConst.SITE_NAVER.get())
//					&& (curMobileNaverCount > 40/*25*/)) {
//				continue;
//			}
//			
//			if (task.getSiteType().equals(CommonConst.SITE_DAUM.get())
//					&& (curMobileDaumCount > 40/*25*/)) { 
//				continue;
//			}
			
			Utils.addTaskToSchedule(schedule, task);
			task.setTempHitCount(task.getTempHitCount()+1);
			
//			if (task.getSiteType().equals(CommonConst.SITE_DAUM.get())) {
//				curMobileDaumCount++;
//			}else if (task.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
//				curMobileNaverCount++;
//			}

			taskCount++;
		}//for (Task task
	}

	private void fillWebTaskList(TaskSchedule schedule, List<Task> taskWebList) {
		int taskCount = schedule.getJobList().split(CommonConst.TASK_LIST_DELIMITER.get()).length;
//		int curWebNaverCount = 0;
//		int curWebDaumCount = 0;
		for (Task task : taskWebList) {
			if (taskCount >= 60) break;

			if (task.getHourHitCount() <=  task.getTempHitCount()) {
				continue;
			}
			
//			if (task.getTaskType().equals(CommonConst.TASK_ROBOT.get())) {
//				Utils.addTaskToSchedule(schedule, task);
//				continue;
//			}
//			
//			if (task.getSiteType().equals(CommonConst.SITE_NAVER.get())
//					&& (curWebNaverCount > 40)) {
//				continue;
//			}
//			
//			if (task.getSiteType().equals(CommonConst.SITE_DAUM.get())
//					&& (curWebDaumCount > 40)) { 
//				continue;
//			}
			
			Utils.addTaskToSchedule(schedule, task);
			task.setTempHitCount(task.getTempHitCount()+1);
			
//			if (task.getSiteType().equals(CommonConst.SITE_DAUM.get())) {
//				curWebDaumCount++;
//			}else if (task.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
//				curWebNaverCount++;
//			}
			taskCount++;
		}//for (Task task
	}

	public void run() {
		Log.info("#####################################################");
		Log.info("generateTaskList Scheduler Started.다음시간대 생성");
		Log.info("#####################################################");
		generateTaskList(false);
		insertTaskSchedule();
		Log.info("#####################################################");
		Log.info("generateTaskList Scheduler Ended.");
		Log.info("#####################################################");
	}
	
	public void execute() {
		Log.info("#####################################################");
		Log.info("generateTaskList Scheduler Started.즉시 생성");
		Log.info("#####################################################");
		generateTaskList(true);
		insertTaskSchedule();
		Log.info("#####################################################");
		Log.info("generateTaskList Scheduler Ended.");
		Log.info("#####################################################");
	}
	
//	public static void main(String[] args) {
//		
//		TaskScheduler scheduler = new TaskScheduler();
//		scheduler.generateTaskList(false);
//		scheduler.insertTaskSchedule();
//	}
}
