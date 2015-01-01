package com.bgt.automation.pageObj;

import java.util.List;

import org.apache.log4j.Logger;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.pattern.Hangul;
import com.bgt.automation.framework.pattern.TypingCmd;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class MainPage extends BasePage {
	static Logger Log = Logger.getLogger(MainPage.class);
	//@FindBy(id="")
	WebElement searchInput;
	WebElement searchButton;
	public MainPage(WebDriver driver, ServiceElement serviceElement,ActionItem item){
		super(driver, serviceElement, item);
	}
	
	public SearchResultPage searchKeyword(String keyword) {
		SearchResultPage searchResultPage;
		try {
		searchInput = serviceElement.searchInput();
		searchButton = serviceElement.searchButton(); 

		TypingCmd.execute(searchInput,keyword);
		searchButton.click();
		searchResultPage = new SearchResultPage(driver, serviceElement, item);
		} catch (Exception e) {
			Log.error("in search a keyword",e);
			searchResultPage = null;
		}
		return searchResultPage;
	}

	public SearchResultPage doAutoCompleteKeyword(String keyword) {
		SearchResultPage searchResultPage;
		try {
			searchInput = serviceElement.searchInput();
			searchButton = serviceElement.searchButton(); 

			//TypingCmd.execute(searchInput,keyword);

			List<String> resultList = Hangul.convertToKeys(keyword);
			String result = "";
			for (String str : resultList) {
				//result += str;
				searchInput.click();
				searchInput.sendKeys(str);
				Thread.sleep(Utils.randInt(1, 3)*100);
			}	
			if (searchButton != null)
				searchButton.click();
			else 
				searchInput.sendKeys(Keys.ENTER);

//			if (Utils.randInt(1, 3)%3 == 1) {
//				if (searchButton != null)
//					searchButton.click();
//				else 
//					searchInput.sendKeys(Keys.ENTER);
//			} else {
//				searchInput.sendKeys(Keys.ENTER);
//			}
			searchResultPage = new SearchResultPage(driver, serviceElement, item);
		} catch (Exception e) {
			e.printStackTrace();
			Log.error("doing auto complete keyword",e);
			searchResultPage = null;
		}
		return searchResultPage;
	}
	
	public void getFocus() {
		try {
			goFirstTab();
		} catch (Exception e) {
			Log.error("to get focus",e);
		}
	}
	
	
//	public void scrollDownPage() {
//		WebElement el;
//		try {
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
