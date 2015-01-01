package com.bgt.runner;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.Timer;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.FutureTask;
import java.util.concurrent.ScheduledExecutorService;

import javax.annotation.Resource;

import org.apache.james.mime4j.field.datetime.DateTime;
import org.apache.log4j.Logger;
import org.h2.util.DateTimeUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.core.env.Environment;

import com.bgt.automation.util.Utils;
import com.bgt.automation.util.event.TaskEvent;
import com.bgt.automation.util.event.TaskEventListener;
import com.bgt.mybatis.service.ServerInfoDao;
import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.runner.exception.NoMoreServerIdException;

/**
 * serverId를 argument로 받음.
 * 1. Task Scheduler를 매시 50분마다 기동
 * 2. Task Executor를 50~10분마다 기동
 *   - 수행중이면 3~6분이후 재시도
 *   - 해당시간 이후 가장 빠른 스케줄을 수행
 *   - 이전시간 스케줄은 skip 
 *   최초: 
 *   스케줄데이터 있는지 확인
 *      없으면 현재시간 생성
 *      -> 다음 50분
 *   즉시 수행 -> 다음은 50분후 아직 수행중이면 3~6분후 재시도
 *   
 * @author jinnonsbox
 * 생성일 : 2014. 11. 4.
 */
public class ScheduleManager {
	//TODO
	public static boolean DEBUG = true; 
	static Logger Log = Logger.getLogger(ScheduleManager.class);
	
	@Autowired ApplicationContext cxt = new ClassPathXmlApplicationContext("config/launch-config.xml");

	Timer schedulerTimer = new Timer(); // Instantiate Timer Object
	Timer executorTimer = new Timer(); // Instantiate Timer Object
	Queue<Timer> executeTimerList = new LinkedList<Timer>();
	
	//TaskExecutor taskExecutor; // Instantiate SheduledTask class
	TaskScheduler taskScheduler;
	
	TaskExecutorListener listener = new TaskExecutorListener();
	
	String serverId;
	@Resource(name = "ServerInfoDao")
	public ServerInfoDao serverInfoDao = (ServerInfoDao)cxt.getBean("serverInfoDao");
	
	public ScheduleManager() throws NoMoreServerIdException, Exception {
		initializeProperty();
	}
	
	public void setDebug(boolean debug) {
		DEBUG = debug;
	}
	
	public void initializeProperty() throws NoMoreServerIdException, Exception {
		AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(  
				AppConfig.class);  
		context.registerShutdownHook();  
		Environment environment = context.getBean(Environment.class);  
		String serverStr = environment.getProperty("server_id");
		String[] serverIdArray = serverStr.split(",");
		List<ServerInfo>serverInfoList = this.serverInfoDao.selectAvailable(Arrays.asList(serverIdArray));

		if (serverInfoList != null && serverInfoList.size()>0) {
			this.serverId = serverInfoList.get(0).getServerId();
			System.setProperty("server_id", serverId);
			lockServerId();
		} else {
			throw new NoMoreServerIdException("서버 id 모두 사용중.");
		}
		//log4j.xml파일의 파일명설정에 server_id를 적용
		org.springframework.util.Log4jConfigurer.shutdownLogging();
		org.springframework.util.Log4jConfigurer.initLogging("classpath:log4j.xml");

		Log.info("##########################################################");
		Log.info("main.properties파일 정보일기");
		Log.info("##########################################################");
		Log.info("server_id    : "+environment.getProperty("server_id"));
		Log.info("use_proxy   :"+environment.getProperty("use_proxy"));
		Log.info("use_monkey:"+environment.getProperty("use_monkey"));
		Log.info("forced         :"+environment.getProperty("forced"));
		Log.info("##########################################################");

	}
	
	private void lockServerId() {
		this.serverInfoDao.setRunning(serverId);
	}
	
	private void releaseServerId() {
		this.serverInfoDao.setStop(serverId);
	}
	
	public void finalize() {
		Log.info("프로그램 종료 및 자원해제");
//		if (executorTimer != null )
//			executorTimer.cancel();
		for(Iterator<Timer> it=executeTimerList.iterator(); it.hasNext(); ) {
	        Timer qTimer = it.next();
	        qTimer.cancel();
	        it.remove(); 
	    }
		if (schedulerTimer != null)
			schedulerTimer.cancel();

		releaseServerId();
	}
	
	/**
	 * Task Scheduler를 매시 50분마다 기동
	 * 최초: 
	 * 스케줄데이터 있는지 확인
	 * 					    없으면 현재시간 생성
	 *      -> 다음 50분
	 */
	public void doRunScheduler() {
		taskScheduler = new TaskScheduler(cxt);
		taskScheduler.execute();
		Calendar now = Calendar.getInstance();
		now.set(Calendar.MINUTE, 50);
		if (DEBUG) {
			schedulerTimer.schedule(taskScheduler,  now.getTime(), 180*1000);
			Log.info(String.format("실행미완료 대기후 다음 시간 실행 예정 : %s 분후/  주기 : 3분", Utils.getFullDateStr(now.getTime())));
		} else {
			schedulerTimer.schedule(taskScheduler,  now.getTime(), 3600*1000);
			Log.info(String.format("실행미완료 대기후 다음 시간 실행 예정 : %s 분후/  주기 : 1시간", Utils.getFullDateStr(now.getTime())));
		}
	}
	
	/**
	 *   즉시 수행 -> 다음은 즉시수행. 아직 수행중이면 3~6분후 재시도
	 */
	public void doRunExecutor() {
		TaskExecutor taskExecutor = new TaskExecutor(cxt, serverId); // Instantiate SheduledTask class
		taskExecutor.addTaskEventListener(listener);
		taskExecutor.execute();
	}
	
	private TaskExecutor getExecTask() {
		TaskExecutor taskExecutor = new TaskExecutor(cxt, serverId); // Instantiate SheduledTask class
		taskExecutor.addTaskEventListener(listener);
		return taskExecutor;
	}
	
	private class TaskExecutorListener implements TaskEventListener {

		/**
		 * 아직 수행중일때 3~6분이후 수행
		 */
		@Override
		public void scheduleRetryTask(TaskEvent e) {
			Log.info("scheduleRetryTask");
			
			//executorTimer.cancel();
			Timer oldTimer = executeTimerList.peek();
			if (oldTimer != null) {
				oldTimer.cancel();
				executeTimerList.remove();
			}
				
			//executorTimer = new Timer();
			Timer newTimer = new Timer();
			executeTimerList.add(newTimer);
			if (DEBUG) {
				int delayMinute = Utils.randInt(2, 3); //===> 2,3분 
				newTimer.schedule(getExecTask(), delayMinute*60*1000 /*now.getTime()*/, 600*1000);
				Log.info(String.format("실행미완료 대기후 다음 시간 실행 예정 : %d 분후/  주기 : 10분", delayMinute));
			} else {
				int delayMinute = Utils.randInt(3, 6); //===> 3,6분 
				newTimer.schedule(getExecTask(), delayMinute*60*1000 /*now.getTime()*/, 3600*1000);
				Log.info(String.format("실행미완료 대기후 다음 시간 실행 예정 : %d 분후/  주기 : 1시간", delayMinute));
			}
		}

		/**
		 * 정상 종료이면 다음은 즉시 
		 */
		@Override
		public void scheduleNormalTask(TaskEvent e) {
			Log.info("scheduleNormalTask");

			Calendar now = Calendar.getInstance();
			
			//executorTimer.cancel();
			Timer oldTimer = executeTimerList.peek();
			if (oldTimer != null) { 
				oldTimer.cancel();
				//taskExecutor.cancel();
				executeTimerList.remove();
			}
			
			//executorTimer = new Timer();
			Timer newTimer = new Timer();
			executeTimerList.add(newTimer);
			if (DEBUG) {
				newTimer.schedule(getExecTask(),   now.getTime(), 600*1000);		
				Log.info(String.format("정상종료후 즉시 실행 : %s/ 주기 : 10분", Utils.getFullDateStr(now.getTime())));
			} else {
				newTimer.schedule(getExecTask(),   now.getTime(), 3600*1000);
				Log.info(String.format("정상종료후 즉시 실행 : %s/ 주기 : 1시간", Utils.getFullDateStr(now.getTime())));
			}
		}

		/**
		 * 준비된 스케쥴데이터가 없으면 다음 스케쥴이후까지 대기
		 * ===> 매시 55분
		 */
		@Override
		public void scheduleNextPeriodTask(TaskEvent e) {
			Log.info("scheduleNextPeriodTask");

			Calendar now = Calendar.getInstance();
			Calendar timeToSet = Calendar.getInstance();
			if (DEBUG) {
				int min = DateTimeUtils.getDatePart(timeToSet.getTime(),Calendar.MINUTE);
				min = min - min%10 + 7;
				timeToSet.set(Calendar.MINUTE, min); //===> 매 10분중 7분
			} else {
				timeToSet.set(Calendar.MINUTE, 55); //===> 매시 55분
			}
			//executorTimer.cancel();
			Timer oldTimer = executeTimerList.peek();
			if (oldTimer != null) {
				oldTimer.cancel();
				//taskExecutor.cancel();
				executeTimerList.remove();
			}

			//executorTimer = new Timer();
			Timer newTimer = new Timer();
			executeTimerList.add(newTimer);
			/**
			 * 알람시간이 현재이후이면
			 * 한시간뒤시간을 지정하고, 
			 * 이전이면 지정한 알람시간(timeToSet)을 스케쥴한다.
			 */
			//알람시간이 지나서 한시간 이후 발생
			if (now.getTimeInMillis() < timeToSet.getTimeInMillis()) {
				if (DEBUG) {
					newTimer.schedule(getExecTask(),   timeToSet.getTime(), 600*1000);
					Log.info(String.format("대기후 다음 시간 실행 예정 : %s/ 주기 : 10분", Utils.getFullDateStr(timeToSet.getTime())));
				} else {
					newTimer.schedule(getExecTask(),   timeToSet.getTime(), 3600*1000);
					Log.info(String.format("대기후 다음 시간 실행 예정 : %s/ 주기 : 1시간", Utils.getFullDateStr(timeToSet.getTime())));
				}
			//알람시간이 한시간 이내 발생	
			} else {
				if (DEBUG) {
					long delayTime = 600*1000 - (timeToSet.getTimeInMillis() - now.getTimeInMillis()); 
					newTimer.schedule(getExecTask(),   delayTime, 600*1000);		
					Log.info(String.format("대기후 다음 시간 실행 예정 : %s==>%d 분후/  주기 : 10분", Utils.getFullDateStr(now.getTime()), delayTime/(60*1000)));
				} else {
					long delayTime = 3600*1000 - (timeToSet.getTimeInMillis() - now.getTimeInMillis()); 
					newTimer.schedule(getExecTask(),   delayTime, 3600*1000);
					Log.info(String.format("대기후 다음 시간 실행 예정 : %s==>%d 분후/  주기 : 1시간", Utils.getFullDateStr(now.getTime()), delayTime/(60*1000)));
				}
			}
		}		
	}
	
	//A static inner class Runnable.
    private static class ProcessFinalizer implements Runnable {
        private ScheduleManager remain;
        
        private ProcessFinalizer(ScheduleManager remain)
        {
            this.remain = remain;
        }
        
        public void run()
        {
            try
            {
                remain.finalize();
            }
            catch(Exception ce)
            {
                Log.error("프로그램 종료처리중 에러 발생",ce);
            }
        }    
    }

    //Inside the Cache class:
    private ProcessFinalizer remain = new ProcessFinalizer(this);

    public Runnable getShutdownRunnable() {
    	return remain;
    }

	public static void main(String[] args) throws InterruptedException {
 
//		String serverId;
//		if (args.length > 1) {
//			serverId = args[0];
//		} else {
//	        System.err.println("실행인자 serverId 누락됨.");
//	        System.err.println("프로그램 종료.");
//	        System.exit(1);
//	        return;
//		}
		
		ScheduleManager manager = null;
		try {
			manager = new ScheduleManager();
			
			//종료시 종료처리
			Thread hook = new Thread(manager.getShutdownRunnable());
	        Runtime.getRuntime().addShutdownHook(hook);

	        manager.doRunScheduler();
			manager.doRunExecutor();
			
			//for demo only.
			while (true) {
				System.out.println("Biral application scheduler is running.");
				System.out.print("To stop it, enter 'quit':");
				BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
				
				String cmd;
				try {
					cmd = br.readLine();
				} catch (IOException e) {
					Log.error("main part",e);
					cmd = null;
				}
				
				if (cmd!=null && "quit".equals(cmd.toLowerCase())) {
					System.out.println("process stopped.");
					break;
				} else {
					System.out.println("incorrect command.");
				}
			}			
		} catch (NoMoreServerIdException e1) {
			Log.error("실행할 id가 모두 할당 상태",e1);
		} catch (Exception ex) {
			Log.error("오류발생", ex);
		} finally {
			if (manager != null)
				manager.finalize();
			System.exit(0);
		}
	}
}
