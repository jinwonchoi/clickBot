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
import com.bgt.automation.util.ConstNaver;
import com.bgt.automation.util.ConstNaverMobile;
import com.bgt.automation.util.Utils;

public class NaverElement implements ServiceElement {

	static Logger Log = Logger.getLogger(NaverElement.class);
	WebDriver driver;
	
	public NaverElement(WebDriver driver) {
		this.driver = driver;
	}

	@Override
	public String defaultPage(){
		return ConstNaver.DEFAULT.get();
	}
	
	@Override
	public String introMainId() {
		return ConstNaver.INTRO_CONTAINER.get();
	}

	@Override
	public String searchMainId() {
		return ConstNaver.SEARCHED_CONTAINER.get();
	}
	
	@Override
	public WebElement introMainForScroll() {
		WebElement el;
		try {
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
			el = driver.findElement(By.name(ConstNaver.SEARCH_INPUT.get()));
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
			el = driver.findElement(By.id(ConstNaver.SEARCH_BUTTON.get()));
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
			el = driver.findElement(By.id(ConstNaver.SEARCHED_CONTAINER.get()));
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
			el = driver.findElement(By.id(ConstNaver.BLOG_CONTAINER.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_BLOG_SECTION.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_BLOG_SECTION.get()))
					.findElement(By.className(ConstNaver.SECTION_MORE.get()))
					.findElement(By.tagName("a"));
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
			el = driver.findElement(By.className(ConstNaver.SEARCHED_BLOG_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement blogPage(int idx) {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaver.SEARCHED_BLOG_PAGE.get()))
					.findElement(By.linkText(Integer.toString(idx)));
			
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}
	
	@Override
	public WebElement blogNext() {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaver.SEARCHED_BLOG_PAGE_NEXT.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}

	@Override
	public WebElement blogFirstLink() {
		WebElement el;
		try {
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_BLOG_FIRST.get()));
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
			el = driver.findElements(By.cssSelector(ConstNaver.SEARCHED_BLOG_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}
	
	@Override
	public int blogLikeCount(String blogId) {
		int count = 0;
		String likeTag ="";
		try {
	        //java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
			likeTag = String.format(ConstNaver.BLOG_LIKE_TAG.get(), blogId);
			WebElement like = driver.findElement(By.id(likeTag));
			Log.debug("like tag for pageId <" + likeTag + "> is present");
			String textName = like.getText().replace("공감 ", "");
			count = Integer.parseInt(textName);
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			Log.error("like tag for pageId <" + likeTag + "> not present");
			count = -1;
		}
		return count;
	}

	@Override
	public WebElement blogLikeButton(String blogId) {
		WebElement like;
		
		try {
			//like = driver.findElement(By.(String.format(ConstNaver.BLOG_LIKE_BUTTON.get(), blogId)));
			like = driver.findElement(By.partialLinkText(ConstNaver.BLOG_LIKE_BUTTON.get()));
			Log.debug("like button for pageId <" + blogId + "> is present");
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.error("not fount", ex);
			Log.error("like button for pageId <" + blogId + "> not present");
			like = null;
		}
		return like;
	}

	@Override
	public String actualBlogUrl(String tempUrl, String pageId) throws Exception {

		if (!tempUrl.contains(pageId)) 
			throw new Exception("블로그 페이지 id 불명확");
		if (tempUrl.lastIndexOf("/") == tempUrl.length() - 1)
			tempUrl = tempUrl.substring(0, tempUrl.length()-1);
		
		if (tempUrl.contains(CommonConst.BLOG_NAVER.get())) {
			tempUrl = tempUrl.replace("/"+pageId, "");
			//http://blog.naver.com/papatree11?Redirect=Log&logNo=220182272129
			return tempUrl +"?Redirect=Log&logNo="+pageId;
		} else {
			throw new Exception("블로그 주소 부정확");
		}
    }
	
	@Override
	public WebElement popupLoginId() {
		WebElement inputId;
		try {
			inputId = driver.findElement(By.id(ConstNaver.POPUP_LOGIN_ID.get()));
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
			inputPwd= driver.findElement(By.id(ConstNaver.POPUP_LOGIN_PWD.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			inputPwd = null;
		}
		return inputPwd;	}

	@Override
	public WebElement popupLoginButton() {
		WebElement buttonLogin;
		try {
			buttonLogin = driver.findElement(By.className(ConstNaver.POPUP_LOGIN_BUTTON.get()));
		} catch (NoSuchElementException ex) { 
			Log.error("not fount", ex);
			buttonLogin = null;
		}
		return buttonLogin;	}

	@Override
	public WebElement blogListForScroll() {
		WebElement el;
		try {
			el = driver.findElement(By.id(ConstNaver.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCH_BUTTON_ON_SEARCHED_PAGE.get()));
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
			el = driver.findElement(By.id(ConstNaver.BLOG_LIST_CONTAINER.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_SITE_SECTION.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_SITE_SECTION.get()));
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
			el = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_SITE_SECTION.get()))
					.findElement(By.className(ConstNaver.SECTION_MORE.get()))
					.findElement(By.tagName("a"));
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
			el = driver.findElement(By.className(ConstNaver.SEARCHED_SITE_FIRST.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}

	@Override
	public WebElement sitePage() {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaver.SEARCHED_SITE_PAGE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement sitePage(int idx) {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaver.SEARCHED_SITE_PAGE.get()))
					.findElement(By.linkText(Integer.toString(idx)));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;
	}

	@Override
	public WebElement siteNext() {
		WebElement el;
		try {
			el = driver.findElement(By.className(ConstNaver.SEARCHED_SITE_PAGE_NEXT.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
			el = null;
		}
		return el;	
	}

	@Override
	public int blogLikeCount() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public WebElement blogLikeButton() {
		// TODO Auto-generated method stub
		return null;
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
		return true;
	}

	@Override
	public List<WebElement> sectionListBlog() {
	
/*
	,SECTION_LIST_BLOG(".sh_blog_title._sp_each_url._sp_each_title") //class
	,SECTION_LIST_KIN("") //css
	,SECTION_LIST_CAFE("sh_cafe_title") //css
	,SECTION_LIST_SITE("") //css
	,SECTION_LIST_WEBDOC(".link.sh_web_title.sh_web_link") //css
	,SECTION_LIST_BOARD("") //class
	,SECTION_LIST_NEWS("._sp_each_url._sp_each_title") //css
*/		// TODO Auto-generated method stub
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_BLOG_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstNaver.SECTION_LIST_BLOG.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListCafe() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_CAFE_SECTION.get()));
			el = section.findElements(By.className(ConstNaver.SECTION_LIST_CAFE.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> sectionListNews() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_NEWS_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstNaver.SECTION_LIST_NEWS.get()));
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
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.id(ConstDaum.SEARCHED_SITE_SECTION.get()));
//			el = section.findElements(By.cssSelector(ConstDaum.SECTION_LIST_SITE.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListBoard() {
//		List<WebElement> el = null;
//		try {
//			WebElement section = driver.findElement(By.cssSelector(ConstDaum.SEARCHED_BOARD_SECTION.get()));
//			el = section.findElements(By.className(ConstDaum.SECTION_LIST_BOARD.get()));
//		} catch (Exception e) {
//			Log.error("not fount", e);
//		}
//		return el;	
		return sectionListNews();//null
	}

	@Override
	public List<WebElement> sectionListWebDoc() {
		List<WebElement> el = null;
		try {
			WebElement section = driver.findElement(By.cssSelector(ConstNaver.SEARCHED_WEBDOC_SECTION.get()));
			el = section.findElements(By.cssSelector(ConstNaver.SECTION_LIST_WEBDOC.get()));
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;	
	}

	@Override
	public List<WebElement> siteLinkList() {
		List<WebElement> el = null;
		try {
			el = driver.findElements(By.className(ConstNaver.SEARCHED_SITE_FIRST.get()));
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
			driver.findElement(By.className(ConstNaver.SEARCHED_MENU_MORE_CLICK.get())).click();;
			WebElement moreMenu = driver.findElement(By.id(ConstNaver.SEARCHED_MENU_MORE.get()));
			el = Utils.getLink(moreMenu, ConstNaver.SEARCHED_WHERE_SITE.get());
		} catch (Exception e) {
			Log.error("not fount", e);
		}
		return el;		
	}

}
