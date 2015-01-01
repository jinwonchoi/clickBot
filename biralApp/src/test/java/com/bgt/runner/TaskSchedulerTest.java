package com.bgt.runner;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class TaskSchedulerTest {
	@Autowired ApplicationContext cxt = new ClassPathXmlApplicationContext("config/launch-config.xml");

	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testGenerateTaskList() {
		fail("Not yet implemented");
	}

	@Test
	public void testExecute() {
		TaskScheduler scheduler = new TaskScheduler(cxt);
		scheduler.execute();
		assert(true);
	}

	@Test
	public void testRun() {
		TaskScheduler scheduler = new TaskScheduler(cxt);
		scheduler.run();
		assert(true);
	}
}
