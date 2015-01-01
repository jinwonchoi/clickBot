package com.bgt.mybatis;

import javax.annotation.Resource;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.bgt.mybatis.service.TaskStatusService;

public class AppMain {

	static Logger LOGGER = Logger.getLogger(AppMain.class);

	@Autowired
	ApplicationContext cxt = new ClassPathXmlApplicationContext("config/launch-config.xml");
	
	//@Resource
	private transient TaskStatusService taskStatusService;
	
	public AppMain() {
		// TODO Auto-generated constructor stub
	}
	
	public void doService() {
		taskStatusService= (TaskStatusService) cxt.getBean("taskStatusService"); 
		LOGGER.info(taskStatusService.getClass());		
	}

	public static void main( String[] args )
	{
		AppMain appMain = new AppMain();
		
		appMain.doService();

		LOGGER.info("Running App...");
	}
}
