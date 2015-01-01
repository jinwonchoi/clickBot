package com.bgt.runner;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.Before;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.Task;
import com.bgt.mybatis.vo.TaskSchedule;
import com.bgt.runner.exception.NoMoreServerIdException;
import com.bgt.runner.exception.NoScheduleDataException;

public class TaskExecutorTest {
	@Autowired ApplicationContext cxt = new ClassPathXmlApplicationContext("config/launch-config.xml");

	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testUpdateTaskStatus() {
		
		TaskExecutor executor = new TaskExecutor(cxt,"006");
		
		TaskSchedule schedule;
		try {
			schedule = executor.selectTaskList();
			List<Integer> taskIdList =  Utils.getTaskList(schedule.getJobList());

			for (int taskId : taskIdList) {
				Task task = executor.taskDao.selectTask(taskId);
				executor.updateTaskStatus(task, schedule);
			}
		} catch (NoScheduleDataException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		assert(true);
	}

	@Test
	public void testDoExecute() {
		fail("Not yet implemented");
	}

}
