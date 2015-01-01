package com.bgt.automation.pageObj;

import java.util.concurrent.TimeUnit;

import org.apache.commons.lang.math.RandomUtils;
import org.apache.log4j.Logger;
import org.openqa.selenium.Alert;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.impl.DaumElement;
import com.bgt.automation.framework.impl.DaumMobileElement;
import com.bgt.automation.framework.impl.NaverElement;
import com.bgt.automation.framework.impl.NaverMobileElement;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class BlogPage extends BasePage {

	static Logger Log = Logger.getLogger(BlogPage.class);
	
	public BlogPage(WebDriver driver, ServiceElement serviceElement,ActionItem item) throws Exception{
		super(driver, serviceElement, item);
		setServiceElement();
		goBlogFrame();
		//scrollElement = serviceElement.blogMainForScroll();
	}

	void setServiceElement() {
		if (item.getTargetUrl().contains(CommonConst.BLOG_NAVER.get())) {
			if (CommonConst.DEVICE_MOBILE.get().equals(item.getDeviceType())) {
				serviceElement = new NaverMobileElement(driver);
			} else {
				serviceElement = new NaverElement(driver);
			}
		} else {
		//} else if (CommonConst.BLOG_TISTORY.get().equals(item.getTargetUrl())) {
		//} else if (CommonConst.BLOG_DAUM.get().equals(item.getTargetUrl())) {
			if (CommonConst.DEVICE_MOBILE.get().equals(item.getDeviceType())) {
				serviceElement = new DaumMobileElement(driver);
			} else {
				serviceElement = new DaumElement(driver);
			}
		}			 
	}
	
	boolean goBlogFrame() throws Exception {
		boolean result = true;
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
			driver = getFrame(driver);
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS);
		}
		return result;
	}
	
	public void getFocus() {
		try {
			goLastTab();
			goBlogFrame();
		} catch (Exception e) {
			Log.error("getFocus",e);
		}
	}
	
	/**
	 * 블로그 공감 찾아서 클릭건수 확인
	 * @return
	 * @throws Exception
	 */
	public boolean needClickLike() throws Exception {
		boolean result = true;
		
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
	        java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
	        
	        Log.debug("needClickLike"+links.size());
//	        for (int i = 0; i<links.size()-1; i++)
//	        	Log.debug(links.get(i).getText());
			int likeCount = serviceElement.blogLikeCount(item.getPageId());
			//
			if (likeCount < item.getBlogLikeCount()
				//	&& (RandomUtils.nextInt(4)%3 > 1)
					&& (item.getLoginId() != null && !item.getLoginId().equals("")
							&&item.getLoginpwd() != null && !item.getLoginpwd().equals("")
							)
				) {
				result = true;
			} else 
				result = false;
			
		} catch (NoSuchElementException ex) { 
			Log.error(String.format("blog id[%s] like click failed", item.getPageId()),ex);
			result = false;
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS); 
		}
		return result;
	}
	
	LoginPopUpPage _clickLike()  throws Exception {
		String currentWindowHandle = driver.getWindowHandle();
		Utils.waitRandomTime();
		serviceElement.blogLikeButton(item.getPageId()).click();
		Utils.waitRandomTime();
		if (Utils.doAlertPresent(driver)) {
			return new LoginPopUpPage(driver, serviceElement, item);
		}
		String tempWindowHandle = "";
		for (String handle : driver.getWindowHandles()) {
			tempWindowHandle = handle;
		}
		if (currentWindowHandle.equals(tempWindowHandle)) {
			return null;
		} else {
			return new LoginPopUpPage(driver, serviceElement, item);
		}
	}
	
	public void clickLike() {
		LoginPopUpPage loginPopUp = null;
		try {
			if (needClickLike()) {
				Log.debug("needClickLike");
				loginPopUp = _clickLike();
				if (loginPopUp != null) {
					loginPopUp.getFocus();
					loginPopUp.clickLogin();
					Utils.waitRandomTime();
					this.getFocus();
					serviceElement.blogLikeButton(item.getPageId()).click();
				}
			} else {
				Log.debug("needClickLike 필요없음.");
			}
		} catch (Exception e) {
			Log.error("click Likes",e);
		}
	}
	
	WebElement getScrollElement() {
		WebElement el = null;
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);

			el = driver.findElement(By.tagName("body"));
			if (el == null) {
				el = serviceElement.blogMainForScroll();
			}
		} catch (Exception ex ) {
			Log.error("in getScrollElement",ex);
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS); 
		}
		return el;
	}
	
//	public void scrollDownPage() {
//		WebElement el;
//		try {
//			el = getScrollElement();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_DOWN);
//				Log.debug("scrollDownPage");
//				Thread.sleep(100);
//			}
//		} catch (InterruptedException e) {
//			Log.error("in scrollDownPage",e);
//		} catch (Exception ex ) {
//			Log.error("in scrollDownPage",ex);
//		}
//	}
	
//	public void scrollUpPage() {
//		WebElement el;
//		try {
//			el = getScrollElement();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_UP);
//				Log.debug("scrollUpPage");
//				Thread.sleep(100);
//			}
//		} catch (InterruptedException e) {
//			Log.error("in scrollUpPage",e);
//		} catch (Exception ex ) {
//			Log.error("in scrollUpPage",ex);
//		}
//	}
	
	public void close() {
		try {
			if (serviceElement.isTabPage())
				driver.close();
			goLastTab();
		} catch (Exception e) {
			Log.error("in closing",e);
		}
	}
}
