package com.bgt.mybatis.vo;

import org.openqa.selenium.WebDriver;

public class ActionItem {

	public ActionItem() {
	}
	String serverId;
	String ipAddress;
	boolean useProxy;
	String browserType;
	String deviceType;
	WebDriver driver;
	String actionType; //blog:B, topsite:T, keyword:K
	String siteType; //naver:N, daum:D
	int taskId;
	String targetUrl;
	String targetName;
	String keyword1;
	String keyword2;
	String loginId;
	String loginpwd;
	String pageId;
	int blogLikeCount;
	
	public String toString() {
		return String.format("serverId[%s], ipAddress[%s],taskId[%s], browserType[%s], deviceType[%s], actionType[%s], siteType[%s]", serverId, ipAddress,taskId, browserType, deviceType, actionType, siteType);
	}
	
	public String getPageId() {
		return pageId;
	}
	public void setPageId(String pageId) {
		this.pageId = pageId;
	}
	public String getActionType() {
		return actionType;
	}
	public void setActionType(String actionType) {
		this.actionType = actionType;
	}
	public String getSiteType() {
		return siteType;
	}
	public void setSiteType(String siteType) {
		this.siteType = siteType;
	}
	public String getLoginId() {
		return loginId;
	}
	public void setLoginId(String loginId) {
		this.loginId = loginId;
	}
	public String getLoginpwd() {
		return loginpwd;
	}
	public void setLoginpwd(String loginpwd) {
		this.loginpwd = loginpwd;
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
	public boolean isUseProxy() {
		return useProxy;
	}
	public void setUseProxy(boolean useProxy) {
		this.useProxy = useProxy;
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
	public WebDriver getWebDriver() {
		return driver;
	}
	public void setWebDriver(WebDriver driver) {
		this.driver = driver;
	}
	public int getTaskId() {
		return taskId;
	}
	public void setTaskId(int taskId) {
		this.taskId = taskId;
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
	public int getBlogLikeCount() {
		return blogLikeCount;
	}
	public void setBlogLikeCount(int blogLikeCount) {
		this.blogLikeCount = blogLikeCount;
	}
}
