package com.bgt.automation.framework.impl;

import static org.junit.Assert.*;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;
public class DaumMobileElementTest {

	static Logger Log = Logger.getLogger(DaumMobileElementTest.class);
	
	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testDaumMobileElement() {
		fail("Not yet implemented");
	}

	@Test
	public void testDefaultPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testIntroMainId() {
		fail("Not yet implemented");
	}

	@Test
	public void testSearchMainId() {
		fail("Not yet implemented");
	}

	@Test
	public void testIntroMainForScroll() {
		fail("Not yet implemented");
	}

	@Test
	public void testSearchInput() {
		fail("Not yet implemented");
	}

	@Test
	public void testSearchButton() {
		fail("Not yet implemented");
	}

	@Test
	public void testSearchButtonOnSearchedPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testSearchedMainForScroll() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogListForScroll() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogMainForScroll() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogSection() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogSectionMore() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogPageInt() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogNext() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogFirstLink() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogLinkList() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogLikeCountString() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogLikeButtonString() {
		fail("Not yet implemented");
	}

	@Test
	public void testActualBlogUrl() {
		DaumMobileElement element = new DaumMobileElement(null);
		try {
			String result  = element.actualBlogUrl("http://m.blog.naver.com/sunwly/90185851748","90185851748");
			Log.debug("result ====>"+result);
			Log.debug("ex: http://blog.naver.com/PostView.nhn?blogId=sunwly&logNo=90185851748");
			
			String result2  = element.actualBlogUrl("http://m.blog.daum.net/prettymom201/16153469","16153469");
			Log.debug("result ====>"+result2);
			Log.debug("ex: http://blog.daum.net/prettymom201/16153469");

		} catch (Exception e) {
			Log.debug("sss");
		}

		NaverMobileElement element2 = new NaverMobileElement(null);
		try {
			String result  = element2.actualBlogUrl("http://m.blog.naver.com/sunwly/90185851748","90185851748");
			Log.debug("result ====>"+result);
			Log.debug("ex: http://blog.naver.com/PostView.nhn?blogId=sunwly&logNo=90185851748");
			
		} catch (Exception e) {
			Log.debug("sss");
		}
		//==>http://blog.naver.com/PostView.nhn?blogId=sunwly&logNo=90185851748
		assert(true);
	}
	

	@Test
	public void testPopupLoginId() {
		fail("Not yet implemented");
	}

	@Test
	public void testPopupLoginPwd() {
		fail("Not yet implemented");
	}

	@Test
	public void testPopupLoginButton() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteListForScroll() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteListSection() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteSection() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteSectionMore() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteFirstLink() {
		fail("Not yet implemented");
	}

	@Test
	public void testSitePage() {
		fail("Not yet implemented");
	}

	@Test
	public void testSitePageInt() {
		fail("Not yet implemented");
	}

	@Test
	public void testSiteNext() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogLikeCount() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogLikeButton() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogSearchOptionDaum() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogSearchOptionTistory() {
		fail("Not yet implemented");
	}

	@Test
	public void testBlogSearchOptionNaver() {
		fail("Not yet implemented");
	}

	@Test
	public void testIsTabPage() {
		fail("Not yet implemented");
	}

}
