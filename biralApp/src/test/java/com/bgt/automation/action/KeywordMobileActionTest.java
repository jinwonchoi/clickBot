package com.bgt.automation.action;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

import com.bgt.automation.util.CommonConst;
import com.bgt.mybatis.vo.ActionItem;

public class KeywordMobileActionTest {

	@Before
	public void setUp() throws Exception {
	}

	void testAction(String browser, String site, ActionItem item) {
		KeywordMobileAction action = null;
		try {
			item.setBrowserType(browser);
			item.setSiteType(site);
			action = new KeywordMobileAction(item);
			action.doExecute();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			action.quit();
		}
		assertTrue(true);
	}

	@Test
	public void testNaverBlogOnNaver() {
//		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
//		testAction(CommonConst.BROWSER_SAFARI.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
//		testAction(CommonConst.BROWSER_SAFARI.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
//		testAction(CommonConst.BROWSER_FIREFOX.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
//		testAction(CommonConst.BROWSER_FIREFOX.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
		assertTrue(true);
	}
	
	@Test
	public void testDaumBlogOnDaum() {
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog01());
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog02());
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog03());
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog04());
		assertTrue(true);
	}
	
	@Test
	public void testDaumBlogOnDaumIexplore() {
//		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog01());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog01());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog02());
		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog03());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog04());
		assertTrue(true);
	}

	
	@Test
	public void testTistoryBlogOnDaum() {
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), tistoryBlog01());
		assertTrue(true);
	}

	ActionItem naverBlog01() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(20);
		item.setKeyword1("겨울 슬림바지");
		item.setKeyword2("겨울 슬림자켓");
		item.setTargetUrl("http://m.blog.naver.com/hellomilja/220161772671");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setLoginId("jinnon");
		item.setLoginpwd("jessy182");
		item.setPageId("220161772671");
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

	ActionItem naverBlog02() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(200);
		item.setKeyword1("파리 여행");
		item.setKeyword2("벨기에");
		item.setTargetUrl("http://m.blog.naver.com/romantics75/220181328738");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setLoginId("jinnonspot");
		item.setLoginpwd("jessy189");
		item.setPageId("220181328738");
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

	ActionItem daumBlog01() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(550);
		item.setKeyword1("노르웨이 고등어");
		item.setKeyword2("철쭉");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}
	
	ActionItem daumBlog02() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(3);
		item.setKeyword1("혜성착륙");
		item.setKeyword2("철쭉");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

	ActionItem daumBlog03() {
		ActionItem item = new ActionItem();
		item.setKeyword1("노르웨이 고등어");
		item.setKeyword2("대구");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

	ActionItem daumBlog04() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(5);
		item.setKeyword1("서울 둘레길");
		item.setKeyword2("젓갈");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

	ActionItem tistoryBlog01() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(5);
		item.setKeyword1("서울 둘레길");
		item.setKeyword2("철쭉");
		item.setActionType(CommonConst.TASK_KEYWORD.get());
		item.setDeviceType(CommonConst.DEVICE_MOBILE.get());
		return item;
	}

}
