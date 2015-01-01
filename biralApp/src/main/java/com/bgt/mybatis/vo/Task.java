package com.bgt.mybatis.vo;

import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;

enum TaskType {
	KEYWORD("K"),
	TOPSITE("T"),
	BLOG("B");
	
	private String value;
	
	private TaskType(String str) {
		value = str;
	}

	public boolean equalValues(String str) {
		return (str == null)? false:value.equals(str);
	}
	
	public String get() {
		return value;
	}
	
}

public class Task {

	public Task() {
	}

	public Task(Task taskNormal, String siteType, String executeDate, int hitCount) {
		int random = Utils.randInt(1, 4);
		
		if (taskNormal.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())
				&& siteType.equals(CommonConst.SITE_NAVER.get())) {
			this.taskId = CommonConst.TASK_ID_MOBILE_NAVER_00.val()+random;
		} else if (taskNormal.getDeviceType().equals(CommonConst.DEVICE_WEB.get())
				&& siteType.equals(CommonConst.SITE_NAVER.get())) {
			this.taskId = CommonConst.TASK_ID_WEB_NAVER_00.val()+random;
		} else if (taskNormal.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())
				&& siteType.equals(CommonConst.SITE_DAUM.get())) {
			this.taskId = CommonConst.TASK_ID_MOBILE_NAVER_00.val()+random;
		} else if (taskNormal.getDeviceType().equals(CommonConst.DEVICE_WEB.get())
				&& siteType.equals(CommonConst.SITE_DAUM.get())) {
			this.taskId = CommonConst.TASK_ID_WEB_DAUM_00.val()+random;
		}

		//TODO
		//this.taskType = CommonConst.TASK_ROBOT.get();
		if (taskId%4 == 1) {
			this.taskType = CommonConst.TASK_BLOG.get();
		} else if (taskId%4 == 2) {
			this.taskType = CommonConst.TASK_BLOG.get();
		} else if (taskId%4 == 3) {
			this.taskType = CommonConst.TASK_KEYWORD.get();
		} else if (taskId%4 == 0) {
			this.taskType = CommonConst.TASK_TOPSITE.get();
		}
		this.deviceType = taskNormal.getDeviceType();
		this.siteType = siteType;
		this.startDate = executeDate;
		this.endDate = executeDate;
		this.dailyHitCount = CommonConst.MAX_TASK_ACTIVITY_PER_MIN.val();
		this.hourHitCount = hitCount;
	}
	
	// TODO Auto-generated constructor stub
	//task_id int(8) NOT NULL auto_increment,
	int taskId;
	//server_id varchar(3) NOT NULL,
	int purchaseId;
	//start_date varchar(8) NOT NULL,
	String deviceType;
	String siteType;
	String startDate;
	//end_date varchar(8) NOT NULL,
	String endDate;
	//task_type varchar(1) DEFAULT NULL comment 'keyword:K, topsite:T, blog:B',
	String taskType; 
	//target_url varchar(4092) DEFAULT NULL,
	String targetUrl;
	//target_name varchar(200) DEFAULT NULL,
	String targetName;
	//keyword1 varchar(200) DEFAULT NULL,
	String pageId;
	String keyword1;
	//keyword2 varchar(200) DEFAULT NULL,
	String keyword2;
	//keyword3 varchar(200) DEFAULT NULL,
	String keyword3;
	//keyword4 varchar(200) DEFAULT NULL,
	String keyword4;
	int blogLikeCount;
	//daily_hit_count int(5) DEFAULT 0,
	int dailyHitCount;
	int hourHitCount;
	int tempHitCount;
/*	
	int hour01HitCount;
	int hour02HitCount;
	int hour03HitCount;
	int hour04HitCount;
	int hour05HitCount;
	int hour06HitCount;
	int hour07HitCount;
	int hour08HitCount;
	int hour09HitCount;
	int hour10HitCount;
	int hour11HitCount;
	int hour12HitCount;
	int hour13HitCount;
	int hour14HitCount;
	int hour15HitCount;
	int hour16HitCount;
	int hour17HitCount;
	int hour18HitCount;
	int hour19HitCount;
	int hour20HitCount;
	int hour21HitCount;
	int hour22HitCount;
	int hour23HitCount;
	int hour24HitCount;*/
	//create_date varchar(14) NOT NULL,
	String createDate;
	//update_date varchar(14) NOT NULL,
	String updateDate;
	
	public int getTaskId() {
		return taskId;
	}
	public void setTaskId(int taskId) {
		this.taskId = taskId;
	}
	public int getPurchaseId() {
		return purchaseId;
	}
	public void setPurchaseId(int purchaseId) {
		this.purchaseId = purchaseId;
	}
	public String getDeviceType() {
		return deviceType;
	}
	public void setDeviceType(String deviceType) {
		this.deviceType = deviceType;
	}
	public String getSiteType() {
		return siteType;
	}
	public void setSiteType(String siteType) {
		this.siteType = siteType;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
	public String getTaskType() {
		return taskType;
	}
	public void setTaskType(String taskType) {
		this.taskType = taskType;
	}
	public String getTargetUrl() {
		return targetUrl;
	}
	public void setTargetUrl(String targetUrl) {
		this.targetUrl = targetUrl;
	}
	public String getTargetName() {
		return targetName;
	}
	public void setTargetName(String targetName) {
		this.targetName = targetName;
	}
	public String getPageId() {
		return pageId;
	}
	public void setPageId(String pageId) {
		this.pageId = pageId;
	}
	public String getKeyword1() {
		return keyword1;
	}
	public void setKeyword1(String keyword1) {
		this.keyword1 = keyword1;
	}
	public String getKeyword2() {
		return keyword2;
	}
	public void setKeyword2(String keyword2) {
		this.keyword2 = keyword2;
	}
	public String getKeyword3() {
		return keyword3;
	}
	public void setKeyword3(String keyword3) {
		this.keyword3 = keyword3;
	}
	public String getKeyword4() {
		return keyword4;
	}
	public void setKeyword4(String keyword4) {
		this.keyword4 = keyword4;
	}
	public int getBlogLikeCount() {
		return blogLikeCount;
	}
	public void setBlogLikeCount(int blogLikeCount) {
		this.blogLikeCount = blogLikeCount;
	}
	public int getDailyHitCount() {
		return dailyHitCount;
	}
	public void setDailyHitCount(int dailyHitCount) {
		this.dailyHitCount = dailyHitCount;
	}
	public int getHourHitCount() {
		return hourHitCount;
	}
	public void setHourHitCount(int hourHitCount) {
		this.hourHitCount = hourHitCount;
	}
	public int getTempHitCount() {
		return tempHitCount;
	}
	public void setTempHitCount(int tempHitCount) {
		this.tempHitCount = tempHitCount;
	}
	/*
	public int getHour01HitCount() {
		return hour01HitCount;
	}
	public void setHour01HitCount(int hour01HitCount) {
		this.hour01HitCount = hour01HitCount;
	}
	public int getHour02HitCount() {
		return hour02HitCount;
	}
	public void setHour02HitCount(int hour02HitCount) {
		this.hour02HitCount = hour02HitCount;
	}
	public int getHour03HitCount() {
		return hour03HitCount;
	}
	public void setHour03HitCount(int hour03HitCount) {
		this.hour03HitCount = hour03HitCount;
	}
	public int getHour04HitCount() {
		return hour04HitCount;
	}
	public void setHour04HitCount(int hour04HitCount) {
		this.hour04HitCount = hour04HitCount;
	}
	public int getHour05HitCount() {
		return hour05HitCount;
	}
	public void setHour05HitCount(int hour05HitCount) {
		this.hour05HitCount = hour05HitCount;
	}
	public int getHour06HitCount() {
		return hour06HitCount;
	}
	public void setHour06HitCount(int hour06HitCount) {
		this.hour06HitCount = hour06HitCount;
	}
	public int getHour07HitCount() {
		return hour07HitCount;
	}
	public void setHour07HitCount(int hour07HitCount) {
		this.hour07HitCount = hour07HitCount;
	}
	public int getHour08HitCount() {
		return hour08HitCount;
	}
	public void setHour08HitCount(int hour08HitCount) {
		this.hour08HitCount = hour08HitCount;
	}
	public int getHour09HitCount() {
		return hour09HitCount;
	}
	public void setHour09HitCount(int hour09HitCount) {
		this.hour09HitCount = hour09HitCount;
	}
	public int getHour10HitCount() {
		return hour10HitCount;
	}
	public void setHour10HitCount(int hour10HitCount) {
		this.hour10HitCount = hour10HitCount;
	}
	public int getHour11HitCount() {
		return hour11HitCount;
	}
	public void setHour11HitCount(int hour11HitCount) {
		this.hour11HitCount = hour11HitCount;
	}
	public int getHour12HitCount() {
		return hour12HitCount;
	}
	public void setHour12HitCount(int hour12HitCount) {
		this.hour12HitCount = hour12HitCount;
	}
	public int getHour13HitCount() {
		return hour13HitCount;
	}
	public void setHour13HitCount(int hour13HitCount) {
		this.hour13HitCount = hour13HitCount;
	}
	public int getHour14HitCount() {
		return hour14HitCount;
	}
	public void setHour14HitCount(int hour14HitCount) {
		this.hour14HitCount = hour14HitCount;
	}
	public int getHour15HitCount() {
		return hour15HitCount;
	}
	public void setHour15HitCount(int hour15HitCount) {
		this.hour15HitCount = hour15HitCount;
	}
	public int getHour16HitCount() {
		return hour16HitCount;
	}
	public void setHour16HitCount(int hour16HitCount) {
		this.hour16HitCount = hour16HitCount;
	}
	public int getHour17HitCount() {
		return hour17HitCount;
	}
	public void setHour17HitCount(int hour17HitCount) {
		this.hour17HitCount = hour17HitCount;
	}
	public int getHour18HitCount() {
		return hour18HitCount;
	}
	public void setHour18HitCount(int hour18HitCount) {
		this.hour18HitCount = hour18HitCount;
	}
	public int getHour19HitCount() {
		return hour19HitCount;
	}
	public void setHour19HitCount(int hour19HitCount) {
		this.hour19HitCount = hour19HitCount;
	}
	public int getHour20HitCount() {
		return hour20HitCount;
	}
	public void setHour20HitCount(int hour20HitCount) {
		this.hour20HitCount = hour20HitCount;
	}
	public int getHour21HitCount() {
		return hour21HitCount;
	}
	public void setHour21HitCount(int hour21HitCount) {
		this.hour21HitCount = hour21HitCount;
	}
	public int getHour22HitCount() {
		return hour22HitCount;
	}
	public void setHour22HitCount(int hour22HitCount) {
		this.hour22HitCount = hour22HitCount;
	}
	public int getHour23HitCount() {
		return hour23HitCount;
	}
	public void setHour23HitCount(int hour23HitCount) {
		this.hour23HitCount = hour23HitCount;
	}
	public int getHour24HitCount() {
		return hour24HitCount;
	}
	public void setHour24HitCount(int hour24HitCount) {
		this.hour24HitCount = hour24HitCount;
	}*/
	public String getCreateDate() {
		return createDate;
	}
	public void setCreateDate(String createDate) {
		this.createDate = createDate;
	}
	public String getUpdateDate() {
		return updateDate;
	}
	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}

	public String toString() {
		return String.format("taskId[%d]purchaseId[%d]taskType[%s]targetUrl[%s]targetName[%s]dailyHitCount[%d]hourHitCount[%d]", 
				taskId,purchaseId,taskType,targetUrl,targetName,dailyHitCount,hourHitCount);
	}
}
