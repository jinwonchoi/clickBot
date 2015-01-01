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
import com.bgt.automation.util.ConstDaum;
import com.bgt.automation.util.ConstNaver;
import com.bgt.automation.util.ConstNaverMobile;
import com.bgt.automation.util.Utils;

public class DaumElement implements ServiceElement {

	static Logger Log = Logger.getLogger(DaumElement.class);
	WebDriver driver;
	
	public DaumElement(WebDriver driver) {
		this.driver = driver;
	}
	
	@Override
	public String defaultPage(){
		return ConstDaum.DEFAULT.get();
	}

	@Override
	public String introMainId() {
		return ConstDaum.INTRO_CONTAINER.get();
	}

	@Override
	public String searchMainId() {
		return ConstDaum.SEARCHED_CONTAINER.get();
	}
	
	@Override
	public WebElement introMainForScroll() {
		WebElement el;
		try {
//			 el = driver.findElement(By.tagName(ConstNaver.DEFAULT_BODY.get()))
//			 .findElement((By.id("daumWrap")))
//			 .findElement(By.id(ConstDaum.INTRO_CONTAINER.get()));
			el = driver.findElement(By.tagName(ConstNaver.DEFAULT_BODY.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCH_INPUT.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCH_BUTTON.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCHED_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstDaum.BLOG_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCHED_BLOG_SECTION.get()));
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
			el = driver.findElement(By.id(ConstDaum.BLOG_SECTION_MORE.get()));
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
			el = driver.findElement(By.className(ConstDaum.SEARCHED_BLOG_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	private WebElement page(int idx) {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstDaum.SEARCHED_BLOG_PAGE.get()))
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
			el = driver.findElement(By.cssSelector(ConstDaum.SEARCHED_BLOG_PAGE_NEXT.get()));
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
			el = driver.findElement(By.className(ConstDaum.SEARCHED_BLOG_FIRST.get()));
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
			el = driver.findElements(By.className(ConstDaum.SEARCHED_BLOG_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}
	
	@Override
	public int blogLikeCount(String blogId) {
		int count = 0;
		try {
			WebElement iframe = driver.findElement(By.id(String.format("if_b_%s",blogId)));
			driver = driver.switchTo().frame(iframe);

			String likeCount = driver.findElement(By.cssSelector(ConstDaum.BLOG_LIKE_COUNT.get())).getText();
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
			el = driver.findElement(By.cssSelector(ConstDaum.BLOG_LIKE_BUTTON.get()));
		} catch (Exception e) {
			Log.error("Button not available", e);
			el = null;
		}
		return el;	
	}

	@Override
	public String actualBlogUrl(String tempUrl, String pageId) throws Exception {

		if (!tempUrl.contains(pageId)) 
			throw new Exception("블로그 페이지 id 불명확");
		if (tempUrl.lastIndexOf("/") == tempUrl.length() - 1)
			tempUrl = tempUrl.substring(0, tempUrl.length()-1);
		
		if (tempUrl.contains(CommonConst.BLOG_TISTORY.get())) {
			return tempUrl;
		} else if (tempUrl.contains(CommonConst.BLOG_NAVER.get())) {
			tempUrl = tempUrl.replace("/"+pageId, "");
			String blogId = tempUrl.substring(tempUrl.lastIndexOf('/')+1);
			//http://blog.naver.com/papatree11/220182272129
			//==>http://blog.naver.com/PostView.nhn?blogId=yoonpia&logNo=220181049771
			return String.format("http://blog.naver.com/PostView.nhn?blogId=%s&logNo=%s",blogId, pageId);
		} else if (tempUrl.contains(CommonConst.BLOG_DAUM.get())) {
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
			inputId = driver.findElement(By.id(ConstDaum.POPUP_LOGIN_ID.get()));
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
			inputPwd= driver.findElement(By.id(ConstDaum.POPUP_LOGIN_PWD.get()));
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
			buttonLogin = driver.findElement(By.id(ConstDaum.POPUP_LOGIN_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			buttonLogin = null;
		}
		return buttonLogin;	
	}

	@Override
	public WebElement blogListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstDaum.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCH_BUTTON_ON_SEARCHED_PAGE.get()));
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
			el = driver.findElement(By.id(ConstDaum.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCHED_SITE_SECTION.get()));
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
			el = driver.findElement(By.id(ConstDaum.SEARCHED_SITE_SECTION.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteSectionMore() {
		WebElement el = null;
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
			el = driver.findElement(By.id(ConstDaum.SITE_SECTION_MORE.get()));
		} catch (Exception e) {
			Log.error("not fount 메뉴에서 찾기시도", e);
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS); 
		}
		if (el == null)
			el = searchedMenuMore();
		return el;
	}

	@Override
	public WebElement siteFirstLink() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstDaum.SEARCHED_SITE_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
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
	public int blogLikeCount() {
		int count = 0;
		try {
			String likeCount = driver.findElement(By.cssSelector(ConstDaum.BLOG_LIKE_COUNT.get())).getText();
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
			like = driver.findElement(By.cssSelector(ConstDaum.BLOG_LIKE_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
		}
		return like;
	}

	@Override
	public WebElement blogSearchOptionDaum() {
		WebElement el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCH_BLOG_OPTION.get()));
			el = Utils.getLink(section, ConstDaum.SEARCH_BLOG_OPTION_DAUM.get());
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;
	}

	@Override
	public WebElement blogSearchOptionTistory() {
		//,SEARCH_BLOG_OPTION("sourceOption") //id  tistory, daum, naver
		//,SEARCH_BLOG_OPTION_DAUM("SA=daumsec") //linkText 다음
		//,SEARCH_BLOG_OPTION_TISTORY("SA=tistory") //linkText 티스토리
		WebElement el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCH_BLOG_OPTION.get()));
			el = Utils.getLink(section, ConstDaum.SEARCH_BLOG_OPTION_TISTORY.get());
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;
	}

	@Override
	public WebElement blogSearchOptionNaver() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean isTabPage() {
		return true;
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
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_BLOG_SECTION.get()));
			el = section.findElements(By.className(ConstDaum.SECTION_LIST_BLOG.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListCafe() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_CAFE_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_CAFE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListNews() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_NEWS_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_NEWS.get()));
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
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_SITE_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_SITE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListBoard() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_BOARD_SECTION.get()));
			el = section.findElements(By.className(ConstDaum.SECTION_LIST_BOARD.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListWebDoc() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_WEBDOC_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_WEBDOC.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> siteLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElements(By.cssSelector(ConstDaum.SEARCHED_SITE_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;		

	}

	@Override
	public WebElement searchedMenuMore() {
		WebElement el = null;
		try {
			Utils.scrollUp(driver);
			driver.findElement(By.id(ConstDaum.SEARCHED_MENU_MORE_CLICK.get())).click();;
			el = driver.findElement(By.cssSelector(ConstDaum.SEARCHED_MENU_MORE_SITE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;		
	}

}
