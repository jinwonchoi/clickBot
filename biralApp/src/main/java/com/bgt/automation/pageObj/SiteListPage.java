package com.bgt.automation.pageObj;

import java.util.Set;
import java.util.TreeSet;

import org.apache.log4j.Logger;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class SiteListPage extends BasePage {

	static Logger Log = Logger.getLogger(SiteListPage.class);

	private String siteUrl = "";
	
	public SiteListPage(WebDriver driver, ServiceElement serviceElement,ActionItem item) throws Exception{
		super(driver, serviceElement, item);
		siteUrl = item.getTargetUrl();
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
	public ExtWebPage findClickLink() throws Exception {
		ExtWebPage sitePage = null;
	    Set<String>tempList = driver.getWindowHandles();
	    Set<String>tabList = new TreeSet<String>();
	    tabList.addAll(tempList);
		for(int i = 0; i < 3; i++) {
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
				sitePage = new ExtWebPage(driver, serviceElement, item, tabList);	
			} catch (org.openqa.selenium.StaleElementReferenceException sre) {
				Log.error("find and click a link",sre);
			} catch (Exception ex) {
				Log.error("find and click a link",ex);
			}
			if (sitePage != null) break;			
		}
		return sitePage;
	}

	boolean _findClickLink() {
		boolean result = true;
		WebElement link = null;
		try {
			for (WebElement webElement : serviceElement.siteLinkList()) {
				Log.debug("링크 text: "+webElement.getText());
				Log.debug("링크: "+webElement.getAttribute("href"));
				if (siteUrl.equals(webElement.getAttribute("href"))) {
					link = webElement;
					break;
				}
			}
			//link = Utils.findLinkByHref(driver, this.blogUrl);
			
			if (link == null) {
				Log.debug("Link with text <" + this.siteUrl + "> not present");
				result = false;
			} else {
				Log.debug("Link with text <" + this.siteUrl + "> is present");
				link.click();
			}
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.debug("Link with text <" + this.siteUrl + "> not present");
			result = false;
		}
		return result;
	}
	
	public void goNextPage() throws Exception {
		serviceElement.siteNext().click();
	}
	
	public void goExtWebPage(int pageNo)  throws Exception {
		serviceElement.sitePage(pageNo).click();
	}
	
	public void goFirstLink() throws Exception {
		serviceElement.siteFirstLink().click();
	}
	
//	public void scrollDownPage() {
//		WebElement el;
//		try {
//			//el = serviceElement.blogListForScroll();
//			el = serviceElement.introMainForScroll();
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
//			//el = serviceElement.blogListForScroll();
//			el = serviceElement.introMainForScroll();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_UP);
//				Thread.sleep(100);
//			}
//		} catch (InterruptedException e) {
//			Log.error("in scrollUpPage",e);
//		} catch (Exception ex ) {
//			Log.error("in scrollUpPage",ex);
//		}
//
//	}


}
