package com.bgt.automation.pageObj;

import java.util.Set;
import java.util.concurrent.TimeUnit;

import org.apache.commons.lang.math.RandomUtils;
import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;
import com.google.common.collect.Sets;

public class ExtWebPage extends BasePage {

	static Logger Log = Logger.getLogger(ExtWebPage.class);
    Set<String>tabList;
	//Set<String> ownList = Sets.newTreeSet();
	
	public ExtWebPage(WebDriver driver, ServiceElement serviceElement,ActionItem item, Set<String>tabList) throws Exception{
		super(driver, serviceElement, item);
		this.tabList = tabList;
	}
	
	public void getFocus() {
		try {
			goLastTab();
		} catch (Exception e) {
			Log.error("getFocus",e);
		}
	}
	
	public void close() {
		try {
			if (serviceElement.isTabPage()) {
				Set<String> currentList = driver.getWindowHandles();
				for (String handle : currentList) {
					if (tabList.contains(handle)) continue;
					else {
				    	driver.switchTo().window(handle);
						driver.close();
						Log.debug("current tab closed.==================>"+handle);
					}
				}
			}
			goLastTab();
		} catch (Exception e) {
			Log.error("in closing",e);
		}
	}
}
