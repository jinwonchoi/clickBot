package com.bgt.mybatis.vo;

enum BrowserType {
	IE("I"),
	CHROME("C"),
	FIREFOX("F"),
	SAFARI("S");
	
	private String value;
	
	private BrowserType(String str) {
		value = str;
	}

	public boolean equalValues(String str) {
		return (str == null)? false:value.equals(str);
	}
	
	public String get() {
		return value;
	}
	
}

public class IpInfo {

	public IpInfo() {
		// TODO Auto-generated constructor stub
	}
	String ipAddress;
	String browserType; //IE:I, chrome:C, firefox:F, safari:S
	String deviceType; //W,M
	String useType; //normal:N, login:L
	String loginIdNaver;
	String loginPwdNaver;
	String loginIdDaum;
	String loginPwdDaum;
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
	public String getUseType() {
		return useType;
	}
	public void setUseType(String useType) {
		this.useType = useType;
	}
	public String getLoginIdNaver() {
		return loginIdNaver;
	}
	public void setLoginIdNaver(String loginIdNaver) {
		this.loginIdNaver = loginIdNaver;
	}
	public String getLoginPwdNaver() {
		return loginPwdNaver;
	}
	public void setLoginPwdNaver(String loginPwdNaver) {
		this.loginPwdNaver = loginPwdNaver;
	}
	public String getLoginIdDaum() {
		return loginIdDaum;
	}
	public void setLoginIdDaum(String loginIdDaum) {
		this.loginIdDaum = loginIdDaum;
	}
	public String getLoginPwdDaum() {
		return loginPwdDaum;
	}
	public void setLoginPwdDaum(String loginPwdDaum) {
		this.loginPwdDaum = loginPwdDaum;
	}
	
	public String toString() {
		return String.format("IpInfo:ipAddress[%s],browserType[%s],deviceType[%s],useType[%s]",
				ipAddress,browserType,deviceType,useType);
	}
}
