package com.bgt.automation.action;

import org.apache.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.impl.DaumElement;
import com.bgt.automation.framework.impl.DaumMobileElement;
import com.bgt.automation.framework.impl.NaverElement;
import com.bgt.automation.framework.impl.NaverMobileElement;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public abstract class BaseAction {

	static Logger Log = Logger.getLogger(BaseAction.class);
	protected WebDriver driver = null;

	ServiceElement serviceElement;
	ActionItem item;

	public BaseAction(ActionItem item) throws Exception {
		this.item = item;
		driver = item.getWebDriver();
			
		if (item.getSiteType().equals(CommonConst.SITE_NAVER.get())) {
			if (item.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
				serviceElement = new NaverMobileElement(driver);
			} else if (item.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
				serviceElement = new NaverElement(driver);
			}
		} else if (item.getSiteType().equals(CommonConst.SITE_DAUM.get())) {
			if (item.getDeviceType().equals(CommonConst.DEVICE_MOBILE.get())) {
				serviceElement = new DaumMobileElement(driver);
			} else if (item.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
				serviceElement = new DaumElement(driver);
			}
		}
		Log.info(String.format("%s created. siteType[%s], browserType[%s]",this.getClass().getSimpleName(),item.getSiteType(), item.getBrowserType()));
	}
	
	abstract public void doExecute();
	
	public void quit() {
		if (driver instanceof FirefoxDriver) {
			driver.close();
	        try {
	            Thread.sleep(5000);
	        } catch(Exception e) {
	        }
		}
		try {
	    if (driver != null) 
	    	driver.quit();
		} catch (Exception e) {}
	}
}
