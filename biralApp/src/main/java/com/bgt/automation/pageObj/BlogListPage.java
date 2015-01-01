package com.bgt.automation.pageObj;

import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang.math.RandomUtils;
import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.impl.DaumElement;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class BlogListPage extends BasePage {

	static Logger Log = Logger.getLogger(BlogListPage.class);

	private String blogUrl = "";
	
	public BlogListPage(WebDriver driver, ServiceElement serviceElement,ActionItem item) throws Exception{
		super(driver, serviceElement, item);
		validateBlogUrl();
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
	public BlogPage findClickLink() throws Exception {
		BlogPage blogPage = null;
		if (item.getTargetUrl().contains(CommonConst.BLOG_DAUM.get())
				&&item.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
			this.clickDaumOnly();
		} else if (item.getTargetUrl().contains(CommonConst.BLOG_DAUM.get())
				&&item.getDeviceType().equals(CommonConst.DEVICE_WEB.get())) {
			this.clickTistoryOnly();
		} 
		for(int i = 0; i < 3; i++) {
			try {
				while (!_findClickLink()) {
					//6. 스크롤 다운
					//7. 다음페이지이동
					goBlogNextPage();
					Utils.waitRandomTime();
					scrollDownPage();
					Utils.waitRandomTime();
				}
				//8. link클릭 (new tab생성)
				//--new tab으로 블로그 열림
				goLastTab();
				blogPage = new BlogPage(driver, serviceElement, item);	
			} catch (org.openqa.selenium.StaleElementReferenceException sre) {
				Log.error("find and click a link",sre);
			} catch (Exception ex) {
				Log.error("find and click a link",ex);
			}
			if (blogPage != null) break;			
		}
		return blogPage;
	}

	/**
	 * 
	 */
    private void validateBlogUrl() throws Exception {
    	blogUrl = serviceElement.actualBlogUrl(item.getTargetUrl(), item.getPageId());
    }
    
	boolean _findClickLink() {
		boolean result = true;
		WebElement link = null;
		try {
			for (WebElement webElement : serviceElement.blogLinkList()) {
				Log.debug("링크 text: "+webElement.getText());
				Log.debug("링크: "+webElement.getAttribute("href"));
				if (blogUrl.equals(webElement.getAttribute("href"))) {
					link = webElement;
					break;
				}
			}
			//link = Utils.findLinkByHref(driver, this.blogUrl);
			
			if (link == null) {
				Log.debug("Link with text <" + this.blogUrl + "> not present");
				result = false;
			} else {
				Log.debug("Link with text <" + this.blogUrl + "> is present");
				link.click();
			}
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.debug("Link with text <" + this.blogUrl + "> not present");
			result = false;
		}
		return result;
	}
	
	private void clickDaumOnly() throws Exception {
		serviceElement.blogSearchOptionDaum().click();
	}
	
	private void clickTistoryOnly() throws Exception {
		serviceElement.blogSearchOptionTistory().click();
	}

	public void goBlogNextPage() throws Exception {
		serviceElement.blogNext().click();
	}
	
	public void goBlogPage(int pageNo)  throws Exception {
		serviceElement.blogPage(pageNo).click();
	}
	
	public void goBlogFirstLink() throws Exception {
		serviceElement.blogFirstLink().click();
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
