package com.bgt.automation.pageObj;

import java.util.List;
import java.util.Set;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class BasePage {
 
	static Logger Log = Logger.getLogger(BasePage.class);
	protected  WebDriver driver = null;

	protected ServiceElement serviceElement;
	protected ActionItem item;
	
	protected WebElement scrollElement;

    public  BasePage(WebDriver driver){
        this.driver = driver;
    }
 
    public  BasePage(WebDriver driver, ServiceElement serviceElement){
        this.driver = driver;
        this.serviceElement = serviceElement;
    }

    public  BasePage(WebDriver driver, ServiceElement serviceElement,ActionItem item){
    	this.driver = driver;
        this.serviceElement = serviceElement;
        this.item = item;
    }

    public void goDefault() {
    	driver.get(serviceElement.defaultPage());	
    }
    
//	public MainPage goMain() {
//		MainPage mainPage;
//		try {
//			mainPage = new MainPage(driver, serviceElement, item);
//			mainPage.goDefault();
//		} catch (Exception e) {
//			Log.error(e);
//			mainPage = null;
//		}
//		return mainPage;
//	}
	
	public void goFirstTab() throws Exception {
	    Set<String>tabList = driver.getWindowHandles();
	    String secondWindow = "";
	    for (String tab : tabList) {
	    	Log.debug("tab is "+tab);
	    	secondWindow = tab;
	    	break;
		}
    	driver.switchTo().window(secondWindow);	}

	public void goLastTab() throws Exception {
	    Set<String>tabList = driver.getWindowHandles();
	    String secondWindow = "";
	    for (String tab : tabList) {
	    	Log.debug("tab is "+tab);
	    	secondWindow = tab;
		}
    	driver.switchTo().window(secondWindow);
	}

	public void closeTab() throws Exception {
		driver.close();
		goLastTab();
	}
//	
//	public void scrollDownPage() {
//		try {
//			Utils.scrollDownList(scrollElement);
//		} catch (Exception ex ) {
//			Log.error("In Scroll down.",ex);
//		}
//	}
//	
//	public void scrollUpPage() {
//		try {
//			Utils.scrollUpList(scrollElement);
//		} catch (Exception ex ) {
//			Log.error("In Scroll up",ex);
//		}
//	}
	
	public void scrollDownPage() {
		Utils.scrollDown(driver);
	}

	public void scrollUpPage() {
		Utils.scrollUp(driver);
	}
	
	public void scrollReadDown() {
		Utils.scrollReadDown(driver);
	}

	
	public WebDriver getFrame(WebDriver driver) {
    	List<WebElement> frameset = driver.findElements(By.tagName("frame"));
		 if(frameset.size()>0) {  
			 for (WebElement framename : frameset){  
				 Log.debug("frameid: " + framename.getAttribute("name"));  
				 driver = driver.switchTo().frame(framename);
				 driver = getFrame(driver);
				 break;
			 }  
		 }  
		 else 
			 Log.debug("can not find any frame in HTML");  
		 return driver;
	}
	
}