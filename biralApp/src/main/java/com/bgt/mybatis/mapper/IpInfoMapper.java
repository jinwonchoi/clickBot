package com.bgt.mybatis.mapper;

import java.util.List;

import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.IpInfo;

@Repository(value="ipInfoMapper")
public interface IpInfoMapper {

	public List<IpInfo> selectAll();
	public IpInfo selectOne(String ipAddress);
	public List<IpInfo> selectByDeviceType(String deviceType);
}
