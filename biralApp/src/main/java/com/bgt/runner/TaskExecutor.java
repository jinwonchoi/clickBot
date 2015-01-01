package com.bgt.runner;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.TimerTask;

import javax.annotation.Resource;

import org.apache.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.core.env.Environment;

import com.bgt.automation.action.AutoCompleteMobileAction;
import com.bgt.automation.action.AutoCompleteWebAction;
import com.bgt.automation.action.BaseAction;
import com.bgt.automation.action.BlogMobileAction;
import com.bgt.automation.action.BlogWebAction;
import com.bgt.automation.action.KeywordMobileAction;
import com.bgt.automation.action.KeywordWebAction;
import com.bgt.automation.action.RobotMobileAction;
import com.bgt.automation.action.RobotWebAction;
import com.bgt.automation.action.TopsiteMobileAction;
import com.bgt.automation.action.TopsiteWebAction;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.automation.util.event.TaskEvent;
import com.bgt.automation.util.event.TaskEventListener;
import com.bgt.automation.util.event.TaskResult;
import com.bgt.mybatis.service.IpInfoDao;
import com.bgt.mybatis.service.ServerInfoDao;
import com.bgt.mybatis.service.TaskDao;
import com.bgt.mybatis.service.TaskScheduleDao;
import com.bgt.mybatis.service.TaskStatusDao;
import com.bgt.mybatis.vo.ActionItem;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.mybatis.vo.Task;
import com.bgt.mybatis.vo.TaskSchedule;
import com.bgt.mybatis.vo.TaskStatus;
import com.bgt.runner.exception.NoMoreServerIdException;
import com.bgt.runner.exception.NoScheduleDataException;

public class TaskExecutor extends TimerTask {

	static Logger Log = Logger.getLogger(TaskExecutor.class);
	static boolean instanceRunning = false;
	static int inc = 0;
	String serverId;
	List<TaskSchedule> taskScheduleList;
	boolean forcedRun = false;
	boolean useMonkey = false;
	boolean useProxy = false;
	
	ApplicationContext cxt;

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

	private ArrayList<TaskEventListener> taskEventListenerList = new ArrayList<TaskEventListener>();
	
	public TaskExecutor(ApplicationContext cxt, String serverId) {
		this.cxt = cxt;
		this.serverId = serverId;
		initialize();
	}
	
	/**
	 * 옵션정보는  main.properties 에서만 받음
	 * 인자값은 main.properties 위치를 알수 있는 경로(app_home)정보만 받는다.
	 * 
	 */
	private void initialize() {
		taskDao = (TaskDao)cxt.getBean("taskDao");
		taskStatusDao = (TaskStatusDao)cxt.getBean("taskStatusDao");
		ipInfoDao = (IpInfoDao)cxt.getBean("ipInfoDao");
		serverInfoDao = (ServerInfoDao)cxt.getBean("serverInfoDao");
		taskScheduleDao = (TaskScheduleDao)cxt.getBean("taskScheduleDao");
		
		AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(  
				AppConfig.class);  
		context.registerShutdownHook();  
		Environment environment = context.getBean(Environment.class);  
		//forced=true|false
		String forcedRunStr = environment.getProperty("forced");
		if (forcedRunStr != null && !forcedRunStr.equals("")) {
			forcedRun = forcedRunStr.equals("yes");
		}

		String useProxStr = environment.getProperty("use_proxy");
		if (useProxStr != null && !useProxStr.equals("")) {
			useProxy = useProxStr.equals("yes");
		}
		
		String useMonkeyStr = environment.getProperty("use_monkey");
		if (useMonkeyStr != null && !useMonkeyStr.equals("")) {
			useMonkey= useMonkeyStr.equals("yes");
		}

		Log.info("server_id    : "+environment.getProperty("server_id"));
		Log.info("use_proxy   :"+environment.getProperty("use_proxy"));
		Log.info("use_monkey:"+environment.getProperty("use_monkey"));
		Log.info("forced         :"+environment.getProperty("forced"));
	}

	/**
	 * 전제: 스케쥴러가 먼저 돌아서 다음 시간분을 생성해둔 상태
	 * 0. 현재시간 이후의 이력을 가져옴
	 *     이력이 없으면 현재시간을 이력으로 지정
	 * 1. 이력이후의 일정을 가져옴
	 *     일정이 없으면 에러-->스케쥴러를 다시 돌려야 함.
	 *     
	 *  if (forced)
	 *  -이력이 있어도 현재시간을 지정    
	 *  
	 * @throws NoScheduleDataException
	 */
	public TaskSchedule selectTaskList() throws NoScheduleDataException, Exception {
		String maxWorkTime = taskStatusDao.selectMaxWorkTime(serverId);
		String nextWorkTime = "";
		String executeDate = "";
		int workHour = 0;
		
		Log.info("maxWorkTime="+maxWorkTime);
		
		//현재시간으로 실행한 이력이 있거나 (최초실행이면서 강제실행모드(forcedRun))가 아니면 이력마지막 시간의 다음시간
		// 아니면 현재시간으로 지정
		if (maxWorkTime != null && !maxWorkTime.equals("") && (!forcedRun||inc > 0)) {
			nextWorkTime = Utils.getDateStrNextHour(maxWorkTime);
		} else {
			nextWorkTime =  new java.text.SimpleDateFormat("yyyyMMddHH").format(Calendar.getInstance().getTime());
		}
		executeDate = nextWorkTime.substring(0,8);
		workHour = Integer.parseInt(nextWorkTime.substring(8));

		//new NoScheduleDataException("No maxWorkTime");
		TaskSchedule paramSchedule = new TaskSchedule();
		paramSchedule.setServerId(serverId);
		paramSchedule.setExecuteDate(executeDate);
		paramSchedule.setWorkHour(workHour);
		TaskSchedule taskSchedule = taskScheduleDao.selectByServerIdDateTime(paramSchedule);
		if (taskSchedule == null)
			throw new NoScheduleDataException("예정된 스케쥴일정없음.");
		return taskSchedule;
	}
	
	/**
	 * 
	 * @param event
	 */
	private void processTaskEvent(TaskEvent event) {
		ArrayList<TaskEventListener> tempEventListenerList;
		
		synchronized (this) {
			if (taskEventListenerList.size() == 0) return;
			tempEventListenerList = (ArrayList<TaskEventListener>) taskEventListenerList.clone();
		}
		
		for (TaskEventListener listener : tempEventListenerList) {
			if (event.getTaskResult() == TaskResult.NormalRunning) {
				listener.scheduleNormalTask(event);
			} else if (event.getTaskResult() == TaskResult.NeedRetry) {
				listener.scheduleRetryTask(event);
			} else {
				listener.scheduleNextPeriodTask(event);
			}
		}
	}

	public synchronized void addTaskEventListener(TaskEventListener listener) {
		if (!taskEventListenerList.contains(listener)) {
			taskEventListenerList.add(listener);
		}
	}
	
	public void updateTaskStatus(Task task, TaskSchedule schedule) {
		String workTime = String.format("%s%02d",schedule.getExecuteDate(), schedule.getWorkHour());
		TaskStatus oldStatus = taskStatusDao.selectOne(task.getTaskId(),schedule.getServerId(),  workTime);
		TaskStatus newStatus = new TaskStatus();
		newStatus.setWorkTime(workTime);
		newStatus.setTaskId(task.getTaskId());
		newStatus.setServerId(schedule.getServerId());
		newStatus.setIpAddress(schedule.getIpAddress());

		if (oldStatus == null) {
			newStatus.setCurHitCount(1);
			newStatus.setDayHitCount(task.getDailyHitCount());
			taskStatusDao.insert(newStatus);
		} else {
			newStatus.setCurHitCount(oldStatus.getCurHitCount()+1);
			newStatus.setDayHitCount(oldStatus.getDayHitCount());
			taskStatusDao.update(newStatus);
		}
	}
	
	private WebDriver getDriver(TaskSchedule schedule) throws Exception {
		WebDriver driver = null;
		if (useProxy)
			driver = Utils.openBrowser(schedule.getBrowserType(), schedule.getIpAddress());
		else
			driver = Utils.openBrowser(schedule.getBrowserType());

		return driver;
	}
	
	/**
	 * 1. taskStatus조회 현재시간이후 가장 빠른 시간치를 조회
	 *   - 데이터가 없는 경우 
	 *   - 데이터가 있으나 그다음시간 스케쥴데이터가 없는 경우
	 *      ==> 다음 스케쥴까지 대기
	 *   - 정상
	 *      ==> 현재시간이후의 데이터 다음 시간
	 * 2. 목록을 가져와서 순서대로 수행
	 * 3. 완료
	 * @throws NoScheduleDataException 
	 */
	public void doExecute() throws NoScheduleDataException, Exception {
		TaskSchedule schedule = selectTaskList();
		List<Integer> taskIdList =  Utils.getTaskList(schedule.getJobList());
		WebDriver driver = null;

		try {
			driver = getDriver(schedule);

			for (int taskId : taskIdList) {
				//장애발생시 driver재생성
				if (driver == null)
					driver = getDriver(schedule);
				
				Task task = taskDao.selectTask(taskId);
				IpInfo ipInfo = ipInfoDao.selectOne(schedule.getIpAddress()); 

				ActionItem item = new ActionItem();
				item.setWebDriver(driver);
				item.setServerId(this.serverId);
				item.setUseProxy(useProxy);
				item.setIpAddress(schedule.getIpAddress());
				item.setBrowserType(schedule.getBrowserType());
				item.setActionType(task.getTaskType());
				item.setDeviceType(task.getDeviceType());
				item.setSiteType(task.getSiteType());
				item.setTaskId(taskId);
				item.setTargetUrl(task.getTargetUrl());
				item.setKeyword1(task.getKeyword1());
				item.setKeyword2(task.getKeyword2());
				if (task.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
					item.setLoginId(ipInfo.getLoginIdNaver());
					item.setLoginpwd(ipInfo.getLoginPwdNaver());
				} else {
					item.setLoginId(ipInfo.getLoginIdDaum());
					item.setLoginpwd(ipInfo.getLoginPwdDaum());
				}
				item.setPageId(task.getPageId());
				item.setBlogLikeCount(task.getBlogLikeCount());

				/*
				 * 	String serverId;
						String ipAddress;
						String browserType;
						String mobileYN;
						String actionType; //blog:B, topsite:T, keyword:K
						String taskId;
						String targetUrl;
						String targetName;
						String keyword1;
						String keyword2;
						String loginId;
						String loginpwd;
						String pageId;
						int blogLikeCount;
				 * 
				 */
				BaseAction action = null;
				try {
					Log.debug(item.toString());
					Utils.waitRandomTime();
					//TODO
					if (task.getTaskType().equals(CommonConst.TASK_BLOG.get())&&task.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
						action = new BlogMobileAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_BLOG.get())&&task.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
						action = new BlogWebAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_KEYWORD.get())&&task.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
						action = new KeywordMobileAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_KEYWORD.get())&&task.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
						action = new KeywordWebAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_TOPSITE.get())&&task.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
						action = new TopsiteMobileAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_TOPSITE.get())&&task.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
						action = new TopsiteWebAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_AUTOCOMP.get())&&task.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
						action = new AutoCompleteMobileAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_AUTOCOMP.get())&&task.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
						action = new AutoCompleteWebAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_ROBOT.get())&&task.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
						action = new RobotMobileAction(item);
						action.doExecute();
					} else if (task.getTaskType().equals(CommonConst.TASK_ROBOT.get())&&task.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
						action = new RobotWebAction(item);
						action.doExecute();
					}

					//5. TaskAction 수행후 수행이력 
					//task_status update
					updateTaskStatus(task, schedule);
				} catch (java.net.ConnectException|org.openqa.selenium.NoSuchWindowException ce) {
					Log.error("doExecute",ce);
					cleanDriver(driver);
				} catch (Exception e) {
					Log.error("doExecute",e);
					//drive close는 schedule 마지막단계로 변경 
//				} finally {
//					if (action != null)
//						action.quit();
				}
			}//for
		} catch (Exception e) {
			Log.error("driver 생성 및 task 반복작업",e);
		} finally {
			cleanDriver(driver);
		}
	}
	
	private void cleanDriver(WebDriver driver) {
		try {
			if (driver != null && driver instanceof FirefoxDriver) {
				driver.close();
				Thread.sleep(5000);
			}
			if (driver != null) 
				driver.quit();
		} catch (Exception e) {}
	}

	public void execute() {
		try {
			Log.debug("instanceRunning="+instanceRunning + "    inc="+inc);
			
			if (instanceRunning) {
				processTaskEvent(new TaskEvent(this, TaskResult.NeedRetry));
			} else {
				instanceRunning = true;

				doExecute();
				
				processTaskEvent(new TaskEvent(this, TaskResult.NormalRunning));
				inc++;
			}			
		} catch (NoScheduleDataException ne) {
			Log.error("예정스케쥴없어 대기",ne);
			processTaskEvent(new TaskEvent(this, TaskResult.NoMoreScheduleData));
			inc++;
		} catch (Exception e) {
			Log.error("TaskExecutor실행중 에러",e);
		} finally {
			instanceRunning = false;
		}		
	}
	
	public void run() {
		execute();
	}

	/**
	 *  0. argument :
	 *     - server_id
	 * 1. IP선택 
	 * 2. TaskList 분할
	 * 3. TaskAction 호출 by mobile/web, browser type, blog/topsite/keyword/autocomplete
	 * 4. TaskAction 수행
	 * 5. TaskAction 수행후 수행이력 update
	 */
	public static void main(String[] args) {

	}

}
