package com.bgt.automation.action;

import java.util.List;

import org.apache.log4j.Logger;
import org.hibernate.jpa.criteria.expression.SearchedCaseExpression;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.pattern.Hangul;
import com.bgt.automation.pageObj.BlogPage;
import com.bgt.automation.pageObj.ExtWebPage;
import com.bgt.automation.pageObj.MainPage;
import com.bgt.automation.pageObj.SearchResultPage;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class KeywordWebAction extends BaseAction {

	static Logger Log = Logger.getLogger(KeywordWebAction.class);

	public KeywordWebAction(ActionItem item)
			throws Exception {
		super(item);
		if (!CommonConst.DEVICE_WEB.get().equals(item.getDeviceType()) )
			throw new Exception("웹작업인데 모바일브라우저로 설정.");
		Log.info(String.format("%s created. siteType[%s], browserType[%s]",this.getClass().getSimpleName(),item.getSiteType(), item.getBrowserType()));
		Log.info(item.toString());
	}

	@Override
	public void doExecute() {
		Log.info("==================================================================================");
		Log.info(String.format("%s doExecute 시작.",this.getClass().getSimpleName()));
		MainPage mainPage = null;
		try {
			mainPage = new MainPage(this.driver, this.serviceElement, this.item);
			mainPage.goDefault();
			SearchResultPage searchResultPage = mainPage.doAutoCompleteKeyword(item.getKeyword1());
			searchResultPage.scrollReadDown();
			searchResultPage.scrollUpPage();
			searchResultPage.removeKeyword(item.getKeyword1());
			searchResultPage.doAutoCompleteKeyword(item.getKeyword2());
			searchResultPage.scrollReadDown();
			searchResultPage.scrollUpPage();
			ExtWebPage webPage = searchResultPage.goRandomPage();
			webPage.getFocus();
			webPage.scrollReadDown();
			webPage.close();
			mainPage = searchResultPage.goMain();
			//여기서 조금 딴짓을 하고 
			//몇번 반복한다.
		} catch (Exception e) {
			Log.error("doExecute",e);
		}
		Log.info(String.format("%s doExecute 종료.",this.getClass().getSimpleName()));
		Log.info("==================================================================================");
	}
	
	public void hitKeyword(String keyword) throws Exception {
		List<String> resultList = Hangul.convertToKeys(keyword);
		String result = "";
		for (String str : resultList) {
			//result += str;
			serviceElement.searchInput().sendKeys(str);
			Thread.sleep(Utils.randInt(1, 6)*100);
		}	

		if (Utils.randInt(1, 3)%3 == 1) {
			serviceElement.searchInput().click();
		} else {
			serviceElement.searchInput().sendKeys(Keys.ENTER);
		}

	}
}
