package com.bgt.mybatis.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.bgt.mybatis.mapper.ServerInfoMapper;
import com.bgt.mybatis.mapper.TaskScheduleMapper;
import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.mybatis.vo.TaskSchedule;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

@Service(value="taskScheduleDao")
public class TaskScheduleDao {

	@Resource(name="taskScheduleMapper")
	TaskScheduleMapper mapper;
	
	public TaskScheduleDao() {
		// TODO Auto-generated constructor stub
	}

	public List<TaskSchedule> selectAll() {
		return mapper.selectAll();
	}

	public List<TaskSchedule> selectByDateTime(String executeDate, int workHour) {
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("executeDate", executeDate);
        map.put("workHour", workHour);

		return mapper.selectByDateTime(map);
	}

	public TaskSchedule selectByServerIdDateTime(TaskSchedule taskSchedule) {
		return mapper.selectByServerId(taskSchedule);
	}
	
	public TaskSchedule selectOne(String serverId) {
		return mapper.selectOne(serverId);
	}

	public int insert(TaskSchedule taskSchedule) {
		return mapper.insert(taskSchedule);
	}
	public int delete(TaskSchedule taskSchedule) {
		return mapper.delete(taskSchedule);
	}
}

