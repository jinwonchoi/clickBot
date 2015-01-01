package com.bgt.mybatis.mapper;

import java.util.List;

import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Select;
import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.Task;

@Repository(value="taskMapper")
public interface TaskMapper {

	//@Select("select * from task")
	public List<Task> selectAll();
	
	//@Select("select * from ipinfo")
	public Task selectOne(int taskId);
	
	public List<Task> selectAvailMobileList(@Param("workHour") int workHour);
	public List<Task> selectAvailWebList(@Param("workHour") int workHour);
	
}
