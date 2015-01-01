package com.bgt.automation.framework.impl;

import java.util.List;
import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.ConstNaverMobile;
import com.bgt.automation.util.Utils;

public class NaverMobileElement implements ServiceElement {

	static Logger Log = Logger.getLogger(NaverMobileElement.class);
	WebDriver driver;
	
	public NaverMobileElement(WebDriver driver) {
		this.driver = driver;
	}

	@Override
	public String defaultPage(){
		return ConstNaverMobile.DEFAULT.get();
	}
	
	@Override
	public String introMainId() {
		return ConstNaverMobile.INTRO_CONTAINER.get();
	}

	@Override
	public String searchMainId() {
		return ConstNaverMobile.SEARCHED_CONTAINER.get();
	}
	
	@Override
	public WebElement introMainForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.tagName(ConstNaverMobile.DEFAULT_BODY.get()));
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
			el = driver.findElement(By.name(ConstNaverMobile.SEARCH_INPUT.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement searchButton() {
//		WebElement el;
//		try {
//			el = driver.findElement(By.id(ConstNaverMobile.SEARCH_BUTTON.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//			el = null;
//		}
//		return el;
		return null;
	}

	@Override
	public WebElement searchedMainForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstNaverMobile.SEARCHED_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstNaverMobile.BLOG_CONTAINER.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}
	
	@Override
	public WebElement blogSection() {
		return section();
	}

	@Override
	public WebElement blogSectionMore() {
		return sectionMore();
	}
	
	private WebElement section() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstNaverMobile.SEARCHED_SECTION.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}
	
	private WebElement sectionMore() {
		WebElement el;
		try {
//			WebElement section = driver.findElement(By.tagName("header")) 
//					.findElement(By.id(ConstNaverMobile.SEARCHED_SCH_TAB.get()))
//					.findElement(By.className(ConstNaverMobile.SEARCHED_LST_SCH.get()));
			WebElement section = driver.findElement(By.id(ConstNaverMobile.SEARCHED_SCH_TAB.get()))
					.findElement(By.className(ConstNaverMobile.SEARCHED_LST_SCH.get()));
			el = Utils.getLink(section, ConstNaverMobile.SEARCHED_BLOG_SECTION.get());
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement blogPage() {
		return null;
	}

	@Override
	public WebElement blogPage(int idx) {
		return page(idx);
	}
	
	private WebElement page(int idx) {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaverMobile.SEARCHED_PAGE_IDX.get()))
					.findElement(By.linkText(Integer.toString(idx)));
			
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

	private WebElement pageNext() {
		WebElement el = null;
		try {
			List<WebElement> webList = driver.findElements(By.className(ConstNaverMobile.SEARCHED_PAGE_NEXT_BTN.get()));
			driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
			for (WebElement web : webList) {
				try {
					el = web.findElement(By.className(ConstNaverMobile.SEARCHED_PAGE_NEXT_BTN_CLS.get()));
					Log.debug("found class pg2b_next");
				} catch (NoSuchElementException nse) {
					Log.debug("check not class pg2b_next");
				}
				if (el != null) break;
			}
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS); 
		}
		return el;	
	}

	private WebElement firstLink() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstNaverMobile.SEARCHED_BLOG_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}
	
	@Override
	public WebElement blogFirstLink() {
		return firstLink();	
	}

	@Override
	public List<WebElement> blogLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElement(By.cssSelector(ConstNaverMobile.SEARCHED_BLOG_FIRST.get()))
					.findElements(By.tagName("a"));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}
	
	@Override
	public int blogLikeCount(String blogId) {
		return blogLikeCount();
	}


	@Override
	public int blogLikeCount() {
		int count = 0;
		try {
			String likeCount = driver.findElement(By.id(ConstNaverMobile.BLOG_LIKE_COUNT.get())).getText();
			count = Integer.parseInt(likeCount);
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			count = -1;
		}
		return count;
	}

	@Override
	public WebElement blogLikeButton(String blogId) {
		return blogLikeButton();
	}
	
	@Override
	public WebElement blogLikeButton() {
		WebElement like;
		
		try {
			//like = driver.findElement(By.(String.format(ConstNaver.BLOG_LIKE_BUTTON.get(), blogId)));
			like = driver.findElement(By.cssSelector(ConstNaverMobile.BLOG_LIKE_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			like = null;
		}
		return like;
	}

	@Override
	public String actualBlogUrl(String tempUrl, String pageId) throws Exception {

		if (!tempUrl.contains("//m."))
			tempUrl = tempUrl.replace("//", "//m.");

		if (!tempUrl.contains(pageId)) 
			throw new Exception("블로그 페이지 id 불명확");
		if (tempUrl.lastIndexOf("/") == tempUrl.length() - 1)
			tempUrl = tempUrl.substring(0, tempUrl.length()-1);
		
		if (tempUrl.contains(CommonConst.BLOG_NAVER.get())) {
			//tempUrl = tempUrl.replace("/"+pageId, "");
			//http://blog.naver.com/papatree11?Redirect=Log&logNo=220182272129
			//return tempUrl +"?Redirect=Log&logNo="+pageId;
			return tempUrl;
		} else {
			throw new Exception("블로그 주소 부정확");
		}
    }

	
	@Override
	public WebElement popupLoginId() {
		WebElement inputId;
		try {
			inputId = driver.findElement(By.id(ConstNaverMobile.POPUP_LOGIN_ID.get()));
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
			inputPwd= driver.findElement(By.id(ConstNaverMobile.POPUP_LOGIN_PWD.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			inputPwd = null;
		}
		return inputPwd;	}

	@Override
	public WebElement popupLoginButton() {
		WebElement buttonLogin;
		try {
			buttonLogin = driver.findElement(By.className(ConstNaverMobile.POPUP_LOGIN_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			buttonLogin = null;
		}
		return buttonLogin;	}

	@Override
	public WebElement blogListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstNaverMobile.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstNaverMobile.SEARCH_BUTTON_ON_SEARCHED_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;		
	}

	@Override
	public WebElement siteListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstNaverMobile.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaverMobile.SEARCHED_SITE_SECTION.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaverMobile.SEARCHED_SITE_SECTION.get()));
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
//			WebElement section = driver.findElement(By.tagName("header")) 
//					.findElement(By.id(ConstNaverMobile.SEARCHED_SCH_TAB.get()))
//					.findElement(By.className(ConstNaverMobile.SEARCHED_LST_SCH.get()));
			WebElement section = driver.findElement(By.id(ConstNaverMobile.SEARCHED_SCH_TAB.get()))
					.findElement(By.className(ConstNaverMobile.SEARCHED_LST_SCH.get()));
			el = Utils.getLink(section, ConstNaverMobile.SEARCHED_SITE_SECTION.get());
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	}

	@Override
	public WebElement siteFirstLink() {
		return firstLink();	
	}

	@Override
	public WebElement sitePage() {
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
	public WebElement blogSearchOptionDaum() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public WebElement blogSearchOptionTistory() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public WebElement blogSearchOptionNaver() {
		// TODO Auto-generated method stub
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
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_BLOG_SECTION.get()));
//			el = section.findElements(By.className(ConstDaum.SECTION_LIST_BLOG.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListCafe() {
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_CAFE_SECTION.get()));
//			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_CAFE.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListNews() {
		List<WebElement> el = null;
		try {
			//WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_NEWS_SECTION.get()));
			el = driver.findElements(By.cssSelector(ConstNaverMobile.SECTION_LIST_NEWS.get()));
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
			//WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_SITE_SECTION.get()));
			el = driver.findElements(By.className(ConstNaverMobile.SECTION_LIST_SITE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListBoard() {
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_BOARD_SECTION.get()));
//			el = section.findElements(By.className(ConstDaum.SECTION_LIST_BOARD.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListWebDoc() {
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_WEBDOC_SECTION.get()));
//			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_WEBDOC.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> siteLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElements(By.className(ConstNaverMobile.SEARCHED_SITE_FIRST.get()));
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
