package com.bgt.mybatis.mapper;

import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.mybatis.vo.TaskStatus;

@Repository(value="serverInfoMapper")
public interface ServerInfoMapper {

	public List<ServerInfo> selectAll();
	public ServerInfo selectOne(String serverId);
	public List<ServerInfo> selectAvailable(List<String> serverList);
	public int update(Map<String, Object> map);

}
