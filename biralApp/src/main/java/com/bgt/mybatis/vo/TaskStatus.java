package com.bgt.mybatis.vo;

public class TaskStatus {

/*
 CREATE TABLE task_status (
	task_id int(8) NOT NULL,
	rank int(4) NOT NULL,
	day_hit_count int(5) NOT NULL,
	cur_hit_count int(5) NOT NULL comment 'hit count at current hour',
	ip_address varchar(15) NOT NULL,
	update_date varchar(14) NOT NULL,
	PRIMARY KEY (task_id),
	KEY idx_T_task_status01 (ip_address)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=euckr;
 */
	private int taskId;
	private String serverId;
	private String workTime;
	private int rank;
	private int dayHitCount;
	private int curHitCount;
	private String ipAddress;
	private String updateDate;	
	
	public TaskStatus() {
		// TODO Auto-generated constructor stub
	}
	public int getTaskId() {
		return taskId;
	}
	public void setTaskId(int taskId) {
		this.taskId = taskId;
	}
	public String getServerId() {
		return serverId;
	}
	public void setServerId(String serverId) {
		this.serverId = serverId;
	}
	public String getWorkTime() {
		return workTime;
	}
	public void setWorkTime(String workTime) {
		this.workTime = workTime;
	}
	public int getRank() {
		return rank;
	}
	public void setRank(int rank) {
		this.rank = rank;
	}
	public int getDayHitCount() {
		return dayHitCount;
	}
	public void setDayHitCount(int dayHitCount) {
		this.dayHitCount = dayHitCount;
	}
	public int getCurHitCount() {
		return curHitCount;
	}
	public void setCurHitCount(int curHitCount) {
		this.curHitCount = curHitCount;
	}
	public String getIpAddress() {
		return ipAddress;
	}
	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
	}
	public String getUpdateDate() {
		return updateDate;
	}
	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}
}
