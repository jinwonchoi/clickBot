package com.bgt.mybatis.vo;

public class ServerInfo {

	String serverId;
	String serverName;
	String realIpAddress;
	String runStatus;
	
	public String getServerId() {
		return serverId;
	}

	public void setServerId(String serverId) {
		this.serverId = serverId;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public String getRealIpAddress() {
		return realIpAddress;
	}

	public void setRealIpAddress(String realIpAddress) {
		this.realIpAddress = realIpAddress;
	}

	public String getRunStatus() {
		return runStatus;
	}

	public void setRunStatus(String runStatus) {
		this.runStatus = runStatus;
	}
}
