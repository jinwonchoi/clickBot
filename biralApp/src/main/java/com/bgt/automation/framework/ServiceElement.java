package com.bgt.automation.framework;

import java.util.List;

import org.openqa.selenium.WebElement;

public interface ServiceElement {

	public String defaultPage();
	public boolean isTabPage();
	public String introMainId();
	public String searchMainId();
	public WebElement introMainForScroll();
	public WebElement searchInput();
	public WebElement searchButton();
	public WebElement searchButtonOnSearchedPage();
	public WebElement searchedMainForScroll();
	public WebElement searchedMenuMore();
	public WebElement blogListForScroll();
	public WebElement blogMainForScroll();
	public WebElement blogSection();
	public WebElement blogSectionMore();
	public WebElement blogFirstLink();
	public List<WebElement> blogLinkList();
	public WebElement blogPage();
	public WebElement blogPage(int idx);
	public WebElement blogNext();
	public int blogLikeCount(String blogId);
	public int blogLikeCount();
	public WebElement blogLikeButton(String blogId);
	public WebElement blogLikeButton();
	public WebElement blogSearchOptionDaum();
	public WebElement blogSearchOptionTistory();
	public WebElement blogSearchOptionNaver();
	public String actualBlogUrl(String url, String pageId) throws Exception;
	
	public WebElement popupLoginId();
	public WebElement popupLoginPwd();
	public WebElement popupLoginButton();

	public WebElement siteListForScroll();
	public WebElement siteListSection();
	public WebElement siteSection();
	public WebElement siteSectionMore();
	public WebElement siteFirstLink();
	public List<WebElement> siteLinkList();
	public WebElement sitePage();
	public WebElement sitePage(int idx);
	public WebElement siteNext();
	
	public List<WebElement> sectionListBlog();
	public List<WebElement> sectionListCafe();
	public List<WebElement> sectionListNews();
	public List<WebElement> sectionListKin();
	public List<WebElement> sectionListSite();
	public List<WebElement> sectionListBoard();
	public List<WebElement> sectionListWebDoc();
}
