package com.bgt.runner;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import javax.annotation.Resource;

import org.apache.log4j.Logger;
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

public class DummyTimerTask extends TimerTask {

	static Logger Log = Logger.getLogger(DummyTimerTask.class);


	public DummyTimerTask() {
		System.out.println("bbb");
	}


	@Override
	public void run() {
		//Log.debug("aaa");
		System.out.println("aaa");
	}

	public static void main(String[] args) {
		Calendar timeToSet = Calendar.getInstance();
		Calendar now = Calendar.getInstance();
		timeToSet.set(Calendar.MINUTE, 45); //===> 매시 55분
		System.out.println("45=====>"+timeToSet.getTime().toString());
		System.out.println("now=====>"+now.getTime().toString());
		Timer aTimer = new Timer(); 

		DummyTimerTask taskExecutor = new DummyTimerTask();
		
		if (timeToSet.getTimeInMillis() > now.getTimeInMillis()) {
			System.out.println("set 45");
			aTimer.schedule(taskExecutor,   timeToSet.getTime(), 50000);		
		} else {
			long delayTime = 3600*1000-now.getTimeInMillis() + timeToSet.getTimeInMillis();
			System.out.println("set diff:"+delayTime);
			aTimer.schedule(taskExecutor,  delayTime, 50000);		
		}
	}

}
