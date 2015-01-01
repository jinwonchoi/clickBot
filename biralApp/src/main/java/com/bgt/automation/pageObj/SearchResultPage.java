package com.bgt.automation.pageObj;

import java.util.List;
import java.util.Set;
import java.util.concurrent.TimeUnit;

import org.apache.commons.lang.math.RandomUtils;
import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.pattern.Hangul;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class SearchResultPage extends BasePage {
	static Logger Log = Logger.getLogger(MainPage.class);

	WebElement searchInput;
	WebElement searchButton;

	public SearchResultPage(WebDriver driver, ServiceElement serviceElement,ActionItem item){
		super(driver, serviceElement, item);
	}

	public BlogListPage goBlogList() {
		BlogListPage listPage;
		try {
			scrollDownPage();
			Utils.waitRandomTime();
			serviceElement.blogSectionMore().click();
			listPage = new BlogListPage(driver, serviceElement, item);
		} catch (Exception ex) {
			Log.error("going blog list",ex);
			listPage = null;
		}
		return listPage;
	}
	
	public WebListPage goWebList() {
		WebListPage listPage;
		try {
			scrollDownPage();
			Utils.waitRandomTime();
			serviceElement.siteSectionMore().click();
			listPage = new WebListPage(driver, serviceElement, item);
		} catch (Exception ex) {
			Log.error("going site list",ex);
			listPage = null;
		}
		return listPage;
	}
	
	public SiteListPage goSiteList() {
		SiteListPage listPage;
		try {
			scrollDownPage();
			Utils.waitRandomTime();
			serviceElement.siteSectionMore().click();
			listPage = new SiteListPage(driver, serviceElement, item);
		} catch (Exception ex) {
			Log.error("going site list",ex);
			listPage = null;
		}
		return listPage;
	}

	public void removeKeyword(String keyword) throws Exception {
		searchInput = serviceElement.searchInput();
		//String str = searchInput.getAttribute("value");
		searchInput.click();
		searchInput.sendKeys(Keys.END);
		for (int i = 0; i < keyword.length(); i++) {
			searchInput.sendKeys(Keys.BACK_SPACE);
			Thread.sleep(Utils.randInt(1, 3)*20);
		}	
	}
	
	public SearchResultPage doAutoCompleteKeyword(String keyword) {
		SearchResultPage searchResultPage;
		try {
			searchInput = serviceElement.searchInput();
			searchButton = serviceElement.searchButtonOnSearchedPage(); 

			//TypingCmd.execute(searchInput,keyword);

			List<String> resultList = Hangul.convertToKeys(keyword);
			String result = "";
			for (String str : resultList) {
				//result += str;
				searchInput.click();
				searchInput.sendKeys(str);
				Thread.sleep(Utils.randInt(1, 6)*100);
			}	

			if (Utils.randInt(1, 3)%3 == 1) {
				if (searchButton != null)
					searchButton.click();
				else 
					searchInput.sendKeys(Keys.ENTER);
			} else {
				searchInput.sendKeys(Keys.ENTER);
			}
			searchResultPage = new SearchResultPage(driver, serviceElement, item);
		} catch (Exception e) {
		
			Log.error("doing auto complete keyword",e);
			searchResultPage = null;
		}
		return searchResultPage;
	}
	
//	public void scrollDownPage() {
////		scrollElement = serviceElement.searchedMainForScroll();
////		super.scrollDownPage();
//		
//		WebElement el;
//		try {
//			el = serviceElement.introMainForScroll();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_DOWN);
//				if (RandomUtils.nextInt(4)%3 == 1) {
//					Utils.waitRandomTime();
//				}
//			}
//		} catch (Exception ex ) {
//			Log.error("in scrollDownPage",ex);
//		}
//
//	}
//	
//	public void scrollUpPage() {
////		scrollElement = serviceElement.searchedMainForScroll();
////		super.scrollUpPage();
//		WebElement el;
//		try {
//			el = serviceElement.introMainForScroll();
//			for (int i = 0; i < 20; i++) {
//				el.sendKeys(Keys.ARROW_UP);
//				if (RandomUtils.nextInt(4)%3 == 1) {
//					Utils.waitRandomTime();
//				}
//			}
//		} catch (Exception ex ) {
//			Log.error("in scrollDownPage",ex);
//		}
//	
//	}
	
	public ExtWebPage goRandomPage() throws Exception {
		List<WebElement> webList = null;
		ExtWebPage webPage = null;
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
			
			for (int i = 0; i < 3; i++) {
				int random = Utils.randInt(1, 7);
				switch (random) {
				case 1:
					webList = serviceElement.sectionListBlog();
					break;
				case 2:
					webList = serviceElement.sectionListCafe();
					break;
				case 3:
					webList = serviceElement.sectionListNews();
					break;
				case 4:
					webList = serviceElement.sectionListKin();
					break;
				case 5:
					webList = serviceElement.sectionListSite();
					break;
				case 6:
					webList = serviceElement.sectionListBoard();
					break;
				case 7:
					webList = serviceElement.sectionListWebDoc();				
					break;
	
				default:
					break;
				}
				if (webList !=null) break;
			}
			if (webList != null && webList.size() > 0) {
			    Set<String>tabList = driver.getWindowHandles();
				int randomNo = Utils.randInt(1, webList.size());
				webList.get(randomNo-1).click();
				webPage = new ExtWebPage(driver, serviceElement, item, tabList);
			}
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS);
		}
		return webPage;
	}
	
	public MainPage goMain() {
		MainPage mainPage;
		try {
			mainPage = new MainPage(driver, serviceElement, item);
			mainPage.goDefault();
		} catch (Exception e) {
			Log.error("in going main",e);
			mainPage = null;
		}
		return mainPage;
	}
	
	
	
	
}
