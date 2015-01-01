package com.bgt.mybatis.mapper;

import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.TaskStatus;

@Repository(value="taskStatusMapper")
public interface TaskStatusMapper {

	public List<TaskStatus> selectAll();
	public TaskStatus selectOne(Map<String, Object> map);
	public int insert(TaskStatus taskStatus);
	public int update(TaskStatus taskStatus);
	public String selectMaxDate();
	public String selectCurDate();
	public String selectMaxWorkTime(Map<String, Object> map);
}
