package com.bgt.mybatis.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.bgt.mybatis.mapper.TaskStatusMapper;
import com.bgt.mybatis.vo.TaskStatus;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

@Service(value="taskStatusDao")
public class TaskStatusDao {

	@Resource(name="taskStatusMapper")
	TaskStatusMapper mapper;
	
	public TaskStatusDao() {
		// TODO Auto-generated constructor stub
	}

	public List<TaskStatus> selectAll() {
		return mapper.selectAll();
	}

	public TaskStatus selectOne(int taskId, String serverId, String workTime) {
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("taskId", taskId);
        map.put("serverId", serverId);
        map.put("workTime", workTime);
		return mapper.selectOne(map);
	}
	
	public int insert(TaskStatus taskStatus) {
		return mapper.insert(taskStatus);
	}
	
	public int update(TaskStatus taskStatus) {
		return mapper.update(taskStatus);
	}

	public String selectMaxDate() {
		return mapper.selectMaxDate();
	}

	public String selectCurDate() {
		return mapper.selectCurDate();
	}
	
	public String selectMaxWorkTime(String serverId) {
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("serverId", serverId);
        return mapper.selectMaxWorkTime(map);
	}
}

