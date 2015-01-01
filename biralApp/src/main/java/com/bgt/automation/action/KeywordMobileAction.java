package com.bgt.automation.action;

import org.apache.log4j.Logger;

import com.bgt.automation.pageObj.ExtWebPage;
import com.bgt.automation.pageObj.MainPage;
import com.bgt.automation.pageObj.SearchResultPage;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class KeywordMobileAction extends BaseAction {

	static Logger Log = Logger.getLogger(KeywordMobileAction.class);

	public KeywordMobileAction(ActionItem item)
			throws Exception {
		super(item);
		if (!CommonConst.DEVICE_MOBILE.get().equals(item.getDeviceType()) )
			throw new Exception("모바일작업인데 웹브라우저로 설정.");
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
			//webPage.close();
			mainPage = searchResultPage.goMain();
			//여기서 조금 딴짓을 하고 
			//몇번 반복한다.
		} catch (Exception e) {
			Log.error("doExecute",e);
		}
		Log.info(String.format("%s doExecute 종료.",this.getClass().getSimpleName()));
		Log.info("==================================================================================");
	}
	
}
