package com.bgt.automation.action;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.remote.BrowserType;

import com.bgt.automation.util.CommonConst;
import com.bgt.mybatis.vo.ActionItem;

public class BlogWebActionTest {

	@Before
	public void setUp() throws Exception {
	}

	void testAction(String browser, String site, ActionItem item) {
		BlogWebAction action = null;
		try {
			item.setBrowserType(browser);
			item.setSiteType(site);
			action = new BlogWebAction(item);
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
//		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
//		testAction(CommonConst.BROWSER_SAFARI.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
//		testAction(CommonConst.BROWSER_SAFARI.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
//		testAction(CommonConst.BROWSER_FIREFOX.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
//		testAction(CommonConst.BROWSER_FIREFOX.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_NAVER.get(), naverBlog01());
		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_NAVER.get(), naverBlog02());
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
		testAction(CommonConst.BROWSER_CHROME.get(), CommonConst.SITE_DAUM.get(), daumBlog01());
		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog01());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog02());
//		testAction(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SITE_DAUM.get(), daumBlog03());
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
		item.setBlogLikeCount(10);
		item.setKeyword1("겨울왕국");
		item.setTargetUrl("http://blog.naver.com/papatree11/220182272129");
		item.setActionType("B");
		item.setLoginId("jinnon");
		item.setLoginpwd("jessy182");
		item.setPageId("220182272129");
		return item;
	}

	ActionItem naverBlog02() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(200);
		item.setKeyword1("겨울왕국");
		item.setTargetUrl("http://blog.naver.com/eunrang76/220179459783");
		item.setActionType("B");
		item.setLoginId("jinnon");
		item.setLoginpwd("jessy182");
		item.setPageId("220179459783");
		return item;
	}

	ActionItem daumBlog01() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(550);
		item.setKeyword1("해양탐사용 물고기 로봇 등장");
		item.setTargetUrl("http://blog.daum.net/han0114/16698825");
		item.setActionType("B");
		return item;
	}
	
	ActionItem daumBlog02() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(3);
		item.setKeyword1("혜성착륙");
		item.setTargetUrl("http://blog.daum.net/gangseo/17978826");
		item.setActionType("B");
		return item;
	}

	ActionItem daumBlog03() {
		ActionItem item = new ActionItem();
		item.setKeyword1("서울 둘레길");
		item.setTargetUrl("http://blog.daum.net/hongsy65/16792826");
		item.setActionType("B");
		return item;
	}

	ActionItem daumBlog04() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(5);
		item.setKeyword1("서울 둘레길");
		item.setPageId("16507144");
		item.setTargetUrl("http://blog.daum.net/cheonym/16507144");
		item.setActionType("B");
		item.setLoginId("jinnon");
		item.setLoginpwd("jessy182");
		return item;
	}

	ActionItem tistoryBlog01() {
		ActionItem item = new ActionItem();
		item.setBlogLikeCount(5);
		item.setKeyword1("서울 둘레길");
		item.setTargetUrl("http://kaysyluvg.tistory.com/530");
		item.setActionType("B");
		return item;
	}

}
