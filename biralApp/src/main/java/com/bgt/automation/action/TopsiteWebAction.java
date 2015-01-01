package com.bgt.automation.action;

import org.apache.log4j.Logger;

import com.bgt.automation.pageObj.ExtWebPage;
import com.bgt.automation.pageObj.MainPage;
import com.bgt.automation.pageObj.SearchResultPage;
import com.bgt.automation.pageObj.SiteListPage;
import com.bgt.automation.pageObj.WebListPage;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class TopsiteWebAction extends BaseAction {

	static Logger Log = Logger.getLogger(TopsiteWebAction.class);

	public TopsiteWebAction(ActionItem item)
			throws Exception {
		super(item);
		if (!CommonConst.DEVICE_WEB.get().equals(item.getDeviceType()) )
			throw new Exception("웹작업인데 모바일브라우저로 설정.");
		Log.info(String.format("%s created. siteType[%s], browserType[%s]",this.getClass().getSimpleName(),item.getSiteType(), item.getBrowserType()));
		Log.info(item.toString());
	}

	/**
	 * 1. 검색어로 검색
	 * 2. 링크를 찾는다.
	 * 3. 검색페이지에 있으면 클릭한다.
	 * 4. 없으면 웹페이지보기 클릭
	 * 5. 1,2회 다른 페이지 클릭
	 * 6. 나올때까지 다음페이지로 이동
	 */
	@Override
	public void doExecute() {
		Log.info("==================================================================================");
		Log.info(String.format("%s doExecute 시작.",this.getClass().getSimpleName()));
		MainPage mainPage = null;
		try {
			mainPage = new MainPage(this.driver, this.serviceElement, this.item);
			//1. 초기회면
			mainPage.goDefault();
			//2. 검색어입력클릭
			SearchResultPage searchResultPage = mainPage.doAutoCompleteKeyword(item.getKeyword1());
			//3. 검색화면
			searchResultPage.scrollDownPage();
			Utils.waitRandomTime();
			//4. section(see more) 선택
			SiteListPage siteListPage = searchResultPage.goSiteList();
			//5. link 검색
			//6. 스크롤 다운
			//7. 다음페이지이동
			//8. link클릭 (new tab생성)
			ExtWebPage webPage = siteListPage.findClickLink();
			//9. 스크롤다운
			webPage.scrollReadDown();
			//10.공감갯수확인
			//11.공감클릭(설정된 공감갯수보다 적으면)
			//12.로그인창 팝업
			//13.로그인클릭
			//14.스크롤 업
			webPage.scrollUpPage();
			//15.탭닫기
			webPage.close();
			//
			mainPage.goDefault();
			Utils.waitRandomTime();
			mainPage.scrollDownPage();
			Utils.waitRandomTime();
			
		} catch (Exception e) {
			Log.error("doExecute",e);
		}
		Log.info(String.format("%s doExecute 종료.",this.getClass().getSimpleName()));
		Log.info("==================================================================================");
	}
	
	void doMonkey(WebListPage webListPage) {
		//5. link 검색
		//6. 스크롤 다운
		//7. 다음페이지이동
		//8. link클릭 (new tab생성)
//		ExtWebPage webPage = null;
//		try {
//			for (int i = 0; i < Utils.randInt(1, 2); i++) {
//				webListPage.goSiteNextPage();
//				Utils.waitRandomTime();
//			}
//			webPage = webListPage.clickMonkeyLink();
//			//9. 스크롤다운
//			webPage.getFocus();
//			Utils.waitLongRandomTime();
//			//15.탭닫기
//			webPage.close();
//		} catch (Exception e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		} 
	}
	
}
