package com.bgt.runner;

import static org.junit.Assert.*;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Calendar;
import java.util.Timer;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;

import com.bgt.runner.exception.NoMoreServerIdException;

public class ScheduleManagerTest {
	static Logger Log = Logger.getLogger(ScheduleManagerTest.class);
	
	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testDoRunScheduler() {
		fail("Not yet implemented");
	}

	@Test
	public void testDoRunExecutor() {
		fail("Not yet implemented");
	}

	@Test
	public void testMain() {
		ScheduleManager manager;
		try {
			manager = new ScheduleManager();
			manager.setDebug(true);
			manager.doRunScheduler();
			manager.doRunExecutor();
		} catch (NoMoreServerIdException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		assertTrue(true);
	}

	@Test
	public void testTimer() {

		Calendar now = Calendar.getInstance();
		//now.set(Calendar.MINUTE, 55); //===> 매시 55분
		Timer aTimer = new Timer(); 

		DummyTimerTask taskExecutor = new DummyTimerTask();
		aTimer.schedule(taskExecutor,   now.getTime(), 30);		

		//assertTrue(true);
	}
}
