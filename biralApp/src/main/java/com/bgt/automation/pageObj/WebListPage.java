package com.bgt.automation.pageObj;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

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

public class WebListPage extends BasePage {

	static Logger Log = Logger.getLogger(WebListPage.class);

	
	public WebListPage(WebDriver driver, ServiceElement serviceElement,ActionItem item){
		super(driver, serviceElement, item);
		scrollElement = serviceElement.blogListForScroll();
	}
	
	public void getFocus() {
		try {
			goLastTab();
		} catch (Exception e) {
			Log.error("while to get Focus",e);
		}
	}
	
	/**
	 * 블로그목록에서 목표링크를 찾고, 없으면 다음페이지로 이동
	 * 찾으면 목표링크를 클릭한다.
	 * @return
	 */
	public ExtWebPage findClickLink() {
		ExtWebPage webPage;
	    Set<String>tabList = driver.getWindowHandles();
		try {
			while (!_findClickLink()) {
				//6. 스크롤 다운
				//7. 다음페이지이동
				goNextPage();
				Utils.waitRandomTime();
				scrollDownPage();
				Utils.waitRandomTime();
			}
			//8. link클릭 (new tab생성)
			//--new tab으로 블로그 열림
			goLastTab();
			webPage = new ExtWebPage(driver, serviceElement, item, tabList);	
		} catch (org.openqa.selenium.StaleElementReferenceException sre) {
			Log.error("find and click a link",sre);
			webPage = null;
		} catch (Exception ex) {
			Log.error("find and click a link",ex);
			webPage = null;
		}
		return webPage;
	}
	
	boolean _findClickLink() {
		boolean result = true;
		WebElement link;
		try {
			link = Utils.findLinkByHref(driver, item.getTargetUrl());
			
			if (link == null) {
				Log.debug("Link with text <" + item.getTargetUrl() + "> not present");
				result = false;
			} else {
				Log.debug("Link with text <" + item.getTargetUrl() + "> is present");
				link.click();
			}
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.debug("Link with text <" + item.getTargetUrl() + "> not present");
			result = false;
		}
		return result;
	}

	public ExtWebPage clickMonkeyLink() {
		ExtWebPage webPage = null;
		try {
		    Set<String>tabList = driver.getWindowHandles();

			getCandidLinks().click();
			webPage = new ExtWebPage(driver, serviceElement, item, tabList);
		} catch (Exception e) {
			Log.error("_findClickMonkeyLink", e);
		}
		return webPage;
	}
	
	WebElement getCandidLinks() {
		WebElement candidLink = null;
		List<WebElement> linkList = new ArrayList<WebElement>();
		WebElement webListFrame = serviceElement.siteListSection();//driver.findElement(By.className(".webdoc section"));
		
		linkList = webListFrame.findElements(By.tagName("a"));

		int candidNo = Utils.randInt(0, linkList.size()-1);
		int i = 0;
		for (WebElement webElement : linkList) {
			if (i == candidNo) {
				candidLink = webElement;
				break;
			}
			i++;
		}
		return candidLink;
	}
	
	public void goNextPage() throws Exception {
		serviceElement.siteNext().click();
	}
	
	public void goPage(int pageNo)  throws Exception {
		serviceElement.sitePage(pageNo).click();
	}
	
//	public void scrollDownPage() {
//		WebElement el;
//		try {
//			el = serviceElement.siteListForScroll();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_DOWN);
//				Thread.sleep(100);
//			}
//		} catch (InterruptedException e) {
//			Log.error("in scrollDownPage",e);
//		} catch (Exception ex ) {
//			Log.error("in scrollDownPage",ex);
//		}
//	}
//	
//	public void scrollUpPage() {
//		WebElement el;
//		try {
//			el = serviceElement.siteListForScroll();
//
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_UP);
//				Thread.sleep(100);
//			}
//		} catch (InterruptedException e) {
//			Log.error("in scrollUpPage",e);
//		} catch (Exception ex ) {
//			Log.error("in scrollUpPage",ex);
//		}
//	}

}
