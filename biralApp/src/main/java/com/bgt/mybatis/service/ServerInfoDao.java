package com.bgt.mybatis.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.bgt.mybatis.mapper.ServerInfoMapper;
import com.bgt.mybatis.vo.ServerInfo;
import com.bgt.mybatis.vo.TaskStatus;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

@Service(value="serverInfoDao")
public class ServerInfoDao {

	@Resource(name="serverInfoMapper")
	ServerInfoMapper mapper;
	
	public ServerInfoDao() {
		// TODO Auto-generated constructor stub
	}

	public List<ServerInfo> selectAll() {
		return mapper.selectAll();
	}

	public ServerInfo selectOne(String serverId) {
		return mapper.selectOne(serverId);
	}

	public List<ServerInfo> selectAvailable(List<String> serverList) {
		return mapper.selectAvailable(serverList);
	}

	public int setStop(String serverId) {
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("serverId", serverId);
        map.put("runStatus", "S");
		return mapper.update(map);
	}
	
	public int setRunning(String serverId) {
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("serverId", serverId);
        map.put("runStatus", "R");
		return mapper.update(map);
	}
	
}

