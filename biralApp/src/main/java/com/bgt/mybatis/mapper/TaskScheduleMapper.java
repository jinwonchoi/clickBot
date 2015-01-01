package com.bgt.mybatis.mapper;

import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.TaskSchedule;

@Repository(value="taskScheduleMapper")
public interface TaskScheduleMapper {

	public List<TaskSchedule> selectAll();
	public TaskSchedule selectOne(String serverId);
	public List<TaskSchedule> selectByDateTime(Map<String, Object> map);
	public TaskSchedule selectByServerId(TaskSchedule taskSchedule);
	public int insert(TaskSchedule taskSchedule);
	public int delete(TaskSchedule taskSchedule);
}
