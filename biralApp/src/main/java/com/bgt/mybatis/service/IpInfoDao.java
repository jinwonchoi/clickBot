package com.bgt.mybatis.service;

import java.util.List;

import com.bgt.mybatis.mapper.IpInfoMapper;
import com.bgt.mybatis.mapper.TaskMapper;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.Task;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

@Service(value="ipInfoDao")
public class IpInfoDao {

	@Resource(name="ipInfoMapper")
	IpInfoMapper mapper;
	
	public IpInfoDao() {
		// TODO Auto-generated constructor stub
	}

	public List<IpInfo> selectAllIpInfo() {
		return mapper.selectAll();
	}

	public IpInfo selectOne(String ipAddress) {
		return mapper.selectOne(ipAddress);
	}
	
	public List<IpInfo> selectMobileList() {
		return mapper.selectByDeviceType("M");
	}
	
	public List<IpInfo> selectWebList() {
		return mapper.selectByDeviceType("W");
	}
}
