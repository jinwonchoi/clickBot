package com.bgt.automation.action;

import org.apache.log4j.Logger;
import org.openqa.selenium.remote.BrowserType;

import com.bgt.automation.framework.BrowserController;
import com.bgt.automation.pageObj.BlogListPage;
import com.bgt.automation.pageObj.BlogPage;
import com.bgt.automation.pageObj.MainPage;
import com.bgt.automation.pageObj.SearchResultPage;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class BlogWebAction extends BaseAction {

	static Logger Log = Logger.getLogger(BlogWebAction.class);

	public BlogWebAction(ActionItem item)
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
			//1. 초기회면
			mainPage.goDefault();
			//2. 검색어입력클릭
			SearchResultPage searchResultPage = mainPage.doAutoCompleteKeyword(item.getKeyword1());
			//3. 검색화면
			searchResultPage.scrollDownPage();
			Utils.waitRandomTime();
			//4. section(see more) 선택
			BlogListPage blogListPage = searchResultPage.goBlogList();
			//5. link 검색
			//6. 스크롤 다운
			//7. 다음페이지이동
			//8. link클릭 (new tab생성)
			BlogPage blogPage = blogListPage.findClickLink();
			//9. 스크롤다운
			blogPage.scrollDownPage();
			//10.공감갯수확인
			//11.공감클릭(설정된 공감갯수보다 적으면)
			//12.로그인창 팝업
			//13.로그인클릭
			blogPage.clickLike();
			//14.스크롤 업
			blogPage.scrollUpPage();
			//15.탭닫기
			blogPage.close();
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
	
	/**
	 * 메인 화면에 뉴스 2회, 유머 2회 를 랜덤으로
	 * 
	 */
	public void doMonkey() {
		
	}

}
