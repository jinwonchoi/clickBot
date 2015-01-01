package com.bgt.automation.framework.impl;

import java.util.List;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.ConstDaumMobile;
import com.bgt.automation.util.ConstNaverMobile;
import com.bgt.automation.util.Utils;

public class DaumMobileElement implements ServiceElement {

	static Logger Log = Logger.getLogger(DaumMobileElement.class);
	WebDriver driver;
	
	public DaumMobileElement(WebDriver driver) {
		this.driver = driver;
	}
	
	@Override
	public String defaultPage(){
		return ConstDaumMobile.DEFAULT.get();
	}

	@Override
	public String introMainId() {
		return ConstDaumMobile.INTRO_CONTAINER.get();
	}

	@Override
	public String searchMainId() {
		return ConstDaumMobile.SEARCHED_CONTAINER.get();
	}

	@Override
	public WebElement introMainForScroll() {
		WebElement el;
		try {
//			 el = driver.findElement(By.tagName(ConstNaver.DEFAULT_BODY.get()))
//			 .findElement((By.id("daumWrap")))
//			 .findElement(By.id(ConstDaum.INTRO_CONTAINER.get()));
			el = driver.findElement(By.tagName(ConstDaumMobile.DEFAULT_BODY.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement searchInput() {
		WebElement el;
		try {
			el = driver.findElement(By.name(ConstDaumMobile.SEARCH_INPUT.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement searchButton() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstDaumMobile.SEARCH_BUTTON.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement searchButtonOnSearchedPage() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstDaumMobile.SEARCH_BUTTON_ON_SEARCHED_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;		
	}

	@Override
	public WebElement searchedMainForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_CONTAINER.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}


	@Override
	public WebElement blogListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.BLOG_LIST_CONTAINER.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement blogMainForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.BLOG_CONTAINER.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement blogSection() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_BLOG_SECTION.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement blogSectionMore() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_BLOG_SECTION.get()))
					.findElement(By.className(ConstDaumMobile.SECTION_MORE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

		@Override
	public WebElement blogPage() {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstDaumMobile.SEARCHED_BLOG_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	private WebElement page(int idx) {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstDaumMobile.SEARCHED_BLOG_PAGE.get()))
					.findElement(By.linkText(Integer.toString(idx)));			
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}
	
	@Override
	public WebElement blogPage(int idx) {
		return page(idx);
	}

	private WebElement pageNext() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstDaumMobile.SEARCHED_BLOG_PAGE_NEXT.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}

	@Override
	public WebElement blogNext() {
		return pageNext();	
	}

	@Override
	public WebElement blogFirstLink() {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstDaumMobile.SEARCHED_BLOG_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}
	
	@Override
	public List<WebElement> blogLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElements(By.className(ConstDaumMobile.SEARCHED_BLOG_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}
	
	@Override
	public int blogLikeCount(String blogId) {
		int count = 0;
		try {
			String likeCount = driver.findElement(By.cssSelector(ConstDaumMobile.BLOG_LIKE_COUNT.get())).getText();
			if (likeCount != null && !likeCount.equals("")) {
				count = Integer.parseInt(likeCount);
			}
		} catch (Exception ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("Count not available", ex);
			count = -1;
		}
		return count;
	}

	@Override
	public WebElement blogLikeButton(String blogId) {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstDaumMobile.BLOG_LIKE_BUTTON.get()));
		} catch (Exception e) {
			Log.error("Button not available", e);
			el = null;
		}
		return el;	
	}

	@Override
	public String actualBlogUrl(String url, String pageId) throws Exception {

		String tempUrl = url.replace("//m.", "//");

		if (!tempUrl.contains(pageId)) 
			throw new Exception("블로그 페이지 id 불명확");
		if (tempUrl.lastIndexOf("/") == tempUrl.length() - 1)
			tempUrl = tempUrl.substring(0, tempUrl.length()-1);
		
		if (tempUrl.contains(CommonConst.BLOG_TISTORY.get())) {
			return tempUrl;
		} else if (tempUrl.contains(CommonConst.BLOG_NAVER.get())) {
			//tempUrl = tempUrl.replace("/"+pageId, "");
			//http://blog.naver.com/papatree11?Redirect=Log&logNo=220182272129
			//http://m.blog.naver.com/sunwly/90185851748
			//==>http://blog.naver.com/PostView.nhn?blogId=sunwly&logNo=90185851748
			tempUrl = tempUrl.replace("/"+pageId, "");
			String blogId = tempUrl.substring(tempUrl.lastIndexOf('/')+1);
			return String.format("http://blog.naver.com/PostView.nhn?blogId=%s&logNo=%s",blogId, pageId);
		} else if (url.contains(CommonConst.BLOG_DAUM.get())) {
			//blogUrl = url.replace("/"+item.getPageId(), "");
			return tempUrl;
		} else {
			throw new Exception("블로그 주소 부정확");
		}
    }
	
	@Override
	public WebElement popupLoginId() {
		WebElement inputId;
		try {
			inputId = driver.findElement(By.id(ConstDaumMobile.POPUP_LOGIN_ID.get()));
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			inputId = null;
		}
		return inputId;
	}

	@Override
	public WebElement popupLoginPwd() {
		WebElement inputPwd;
		try {
			inputPwd= driver.findElement(By.id(ConstDaumMobile.POPUP_LOGIN_PWD.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			inputPwd = null;
		}
		return inputPwd;	
	}
	
	@Override
	public WebElement popupLoginButton() {
		WebElement buttonLogin;
		try {
			buttonLogin = driver.findElement(By.id(ConstDaumMobile.POPUP_LOGIN_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			buttonLogin = null;
		}
		return buttonLogin;	
	}
	
	@Override
	public WebElement siteListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.BLOG_LIST_CONTAINER.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteListSection() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_SITE_SECTION.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteSection() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_SITE_SECTION.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteSectionMore() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaumMobile.SEARCHED_SITE_SECTION.get()))
					.findElement(By.className(ConstDaumMobile.SECTION_MORE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteFirstLink() {
		WebElement el = null;
		try {
			el = driver.findElement(By.cssSelector(ConstDaumMobile.SEARCHED_SITE_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public WebElement sitePage() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public WebElement sitePage(int idx) {
		return page(idx);
	}

	@Override
	public WebElement siteNext() {
		return pageNext();	
	}

	@Override
	public int blogLikeCount() {
		int count = 0;
		try {
			String likeCount = driver.findElement(By.cssSelector(ConstDaumMobile.BLOG_LIKE_COUNT.get())).getText();
			count = Integer.parseInt(likeCount);
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			count = -1;
		}
		return count;
	}

	@Override
	public WebElement blogLikeButton() {
		WebElement like = null;
		
		try {
			//like = driver.findElement(By.(String.format(ConstNaver.BLOG_LIKE_BUTTON.get(), blogId)));
			like = driver.findElement(By.cssSelector(ConstDaumMobile.BLOG_LIKE_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
		}
		return like;
	}

	@Override
	public WebElement blogSearchOptionDaum() {
		return null;
	}

	@Override
	public WebElement blogSearchOptionTistory() {
		return null;
	}

	@Override
	public WebElement blogSearchOptionNaver() {
		return null;
	}

	@Override
	public boolean isTabPage() {
		return false;
	}

	@Override
	public List<WebElement> sectionListBlog() {
	
/*
  		,SEARCHED_BLOG_SECTION("blogColl") //id
		,SEARCHED_KIN_SECTION("knowColl") //id
		,SEARCHED_CAFE_SECTION("cafeColl") //id
		,SEARCHED_SITE_SECTION("siteColl") //id
		,SEARCHED_WEBDOC_SECTION("webdocColl") //id
		,SEARCHED_BOARD_SECTION("boardColl") //id
		,SEARCHED_NEWS_SECTION("newsColl") //id
		//랜덤 서핑용
		,SECTION_LIST_BLOG("f_link_bu") //class
		,SECTION_LIST_KIN("") //css
		,SECTION_LIST_CAFE(".f_link_bu.f_l") //css
		,SECTION_LIST_SITE(".f_link_bu.f_l") //css
		,SECTION_LIST_WEBDOC(".f_link_bu.f_l") //css
		,SECTION_LIST_BOARD("f_link_bu") //class
		,SECTION_LIST_NEWS(".f_link_bu.f_l") //css
*/		// TODO Auto-generated method stub
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_BLOG_SECTION.get()));
			el = section.findElements(By.className(ConstDaumMobile.SECTION_LIST_BLOG.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListCafe() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_CAFE_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaumMobile.SECTION_LIST_CAFE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListNews() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_NEWS_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaumMobile.SECTION_LIST_NEWS.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListKin() {
		// TODO Auto-generated method stub
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListSite() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_SITE_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaumMobile.SECTION_LIST_SITE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListBoard() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_BOARD_SECTION.get()));
			el = section.findElements(By.className(ConstDaumMobile.SECTION_LIST_BOARD.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListWebDoc() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaumMobile.SEARCHED_WEBDOC_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaumMobile.SECTION_LIST_WEBDOC.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> siteLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElements(By.className(ConstDaumMobile.SEARCHED_SITE_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public WebElement searchedMenuMore() {
		// TODO Auto-generated method stub
		return null;
	}

}
