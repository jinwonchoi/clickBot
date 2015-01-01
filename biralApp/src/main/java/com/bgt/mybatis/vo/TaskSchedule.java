package com.bgt.mybatis.vo;

public class TaskSchedule {

	String serverId;
	String ipAddress;
	/**
	 * default 'I' comment 'ie:I, chrome:C, firefox:F, safari:S',
	 */
	String browserType;
	String deviceType;
	String executeDate;
	int workHour;
	String jobList = "";
	String updateDate;
	
	public TaskSchedule() {
		// TODO Auto-generated constructor stub
	}

	public TaskSchedule(String serverId, IpInfo ipInfo, String executeDate, int workHour ) {
		this.serverId = serverId;
		this.ipAddress = ipInfo.getIpAddress();
		this.browserType = ipInfo.browserType;
		this.deviceType = ipInfo.deviceType;
		this.executeDate = executeDate;
		this.workHour = workHour;
	}
	
	public String getServerId() {
		return serverId;
	}
	public void setServerId(String serverId) {
		this.serverId = serverId;
	}
	public String getIpAddress() {
		return ipAddress;
	}
	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
	}
	public String getBrowserType() {
		return browserType;
	}
	public void setBrowserType(String browserType) {
		this.browserType = browserType;
	}
	public String getDeviceType() {
		return deviceType;
	}
	public void setDeviceType(String deviceType) {
		this.deviceType = deviceType;
	}
	public String getExecuteDate() {
		return executeDate;
	}
	public void setExecuteDate(String executeDate) {
		this.executeDate = executeDate;
	}
	public int getWorkHour() {
		return workHour;
	}
	public void setWorkHour(int workHour) {
		this.workHour = workHour;
	}
	public String getJobList() {
		return jobList;
	}
	public void setJobList(String jobList) {
		this.jobList = jobList;
	}
	public String getUpdateDate() {
		return updateDate;
	}
	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}
}
