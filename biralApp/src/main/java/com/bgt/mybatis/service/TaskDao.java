package com.bgt.mybatis.service;

import java.util.List;

import com.bgt.mybatis.mapper.TaskMapper;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.Task;
import javax.annotation.Resource;
import org.springframework.stereotype.Service;

@Service(value="taskDao")
public class TaskDao {

	@Resource(name="taskMapper")
	TaskMapper mapper;
	
	public TaskDao() {
		// TODO Auto-generated constructor stub
	}

	public List<Task> selectAllTask() {
		return mapper.selectAll();
	}
	
	public Task selectTask(int taskId) {
		return mapper.selectOne( taskId);
	}

	public List<Task> selectAvailMobileList(int workHour) {
		return mapper.selectAvailMobileList(workHour);
	}

	public List<Task> selectAvailWebList(int workHour) {
		return mapper.selectAvailWebList(workHour);
	}
	
}
