package com.bgt.automation.framework;

import static org.junit.Assert.*;

import java.util.List;

import org.apache.log4j.Logger;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.remote.BrowserType;

import com.bgt.automation.framework.pattern.Hangul;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.Task;

public class BrowserControllerTest {
	BrowserController ctrl;
	static Logger Log = Logger.getLogger(BrowserControllerTest.class);
	
	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testProxy() {
		boolean result = true;
		BrowserController ctrl2 = null;
		BrowserController ctrl3 = null;
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get()
					,"121.126.216.144:6185");

			ctrl2 = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get()
					,"124.198.27.146:6669");

			ctrl3 = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.go("http://www.youngip.net/service/myip/cur_ip_chk.php");
			for (int i = 0; i < 4; i++) {
				ctrl.go("http://www.youngip.net/service/myip/cur_ip_chk.php");
				ctrl2.go("http://www.youngip.net/service/myip/cur_ip_chk.php");
				ctrl3.go("http://www.youngip.net/service/myip/cur_ip_chk.php");
				Thread.sleep(5000);
			}
		} catch (Exception e) {
			Log.error(e);
			result = false;
		} finally {
			ctrl.closeBrowser();
			ctrl2.closeBrowser();
			ctrl3.closeBrowser();
		}
		assertTrue(result);
	}

	
	@Test
	public void testScrollDownMainPage() {
		boolean result = true;
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.scrollDownMainPage();
			Thread.sleep(10000);
			ctrl.scrollUpMainPage();
		} catch (Exception e) {
			Log.error(e);
			result = false;
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(result);
	}

	@Test
	public void testSearchKeyword() {
		boolean result = true;
		
		
		try {
			//입력: keyword, link
			//         login id/pwd
			//        공감갯수
			ActionItem item = new ActionItem();
			item.setBlogLikeCount(3);
			item.setKeyword1("미국 횡단기");
			item.setTargetUrl("http://blog.naver.com/motorklasse?Redirect=Log&logNo=80093191945");
			item.setActionType("B");
			item.setLoginId("jinnon");
			item.setLoginpwd("jessy182");
			String pageId = item.getTargetUrl().substring(item.getTargetUrl().lastIndexOf("/")+1);
			item.setPageId("80093191945");
			
			//1. 초기회면
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get(), item);
			//2. 검색어입력클릭
			ctrl.searchKeyword("미국 횡단기");
			//3. 검색화면
			ctrl.scrollDownMainPage();
			Utils.waitRandomTime();
			//4. section(see more) 선택
			ctrl.goBlogPage();
			Utils.waitRandomTime();
			
			//5. link 검색
			while (!ctrl.findClickLink()) {
				//6. 스크롤 다운
				//7. 다음페이지이동
				ctrl.goBlogNextPage();
				Utils.waitRandomTime();
				ctrl.scrollDownSearchedPage();
				Utils.waitRandomTime();
			}
			//8. link클릭 (new tab생성)
			//--new tab으로 블로그 열림
			ctrl.goLastTab();
			//ctrl.doCheck();
			Utils.waitRandomTime();
			//9. 스크롤다운
			ctrl.goBlogFrame();
			ctrl.scrollDownBlogPage();
			Utils.waitRandomTime();
			//10.공감갯수확인
			if (ctrl.needClickLike()) {
				//11.공감클릭(설정된 공감갯수보다 적으면)
				//12.로그인창 팝업
				//13.로그인클릭
				ctrl.goLastTab();
				Utils.waitRandomTime();
				ctrl.clickLoginPopup();	
				Utils.waitRandomTime();
				ctrl.goLastTab();
				Utils.waitRandomTime();
				ctrl.goBlogFrame();
				ctrl.needClickLike();
			}
			//14.스크롤 업
			//15.탭닫기
			Utils.waitRandomTime();
			ctrl.goLastTab();
			ctrl.scrollUpBlogPage();
			Utils.waitRandomTime();
			ctrl.closeTab();
			ctrl.goLastTab();
			Utils.waitRandomTime();
			ctrl.goMain();
			Utils.waitRandomTime();
		} catch (NoSuchElementException e) {
			e.printStackTrace();
			Log.error(e);
			result = false;
		} catch (Exception ex) {
			ex.printStackTrace();
			Log.error(ex);
			result = false;
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(result);
	}
	
	@Test
	public void testDoCheck() {
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.doCheck();
		} catch (NoSuchElementException e) {
			e.printStackTrace();
			Log.error(e);
		} catch (Exception ex) {
			ex.printStackTrace();
			Log.error(ex);
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(true);
	}
	
	@Test
	public void testMouseMoveToClick() {
		Log.info("firefox     start=============================================================");
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_FIREFOX.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.scrollByMouse();
			//ctrl.moveToClickElement();
		} catch (NoSuchElementException e) {
			e.printStackTrace();
			Log.error(e);
		} catch (Exception ex) {
			ex.printStackTrace();
			Log.error(ex);
		} finally {
			ctrl.closeBrowser();
		}
//		Log.info("firefox    end =============================================================");
//		Log.info("Iexplore start=============================================================");
//		try {
//			ctrl = new BrowserController(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SERVICE_NAVER.get());
//			ctrl.scrollByMouse();
//			//ctrl.moveToClickElement();
//		} catch (NoSuchElementException e) {
//			e.printStackTrace();
//			Log.error(e);
//		} catch (Exception ex) {
//			ex.printStackTrace();
//			Log.error(ex);
//		} finally {
//			ctrl.closeBrowser();
//		}
//		Log.info("Iexplore end =============================================================");
//		Log.info("safari     start=============================================================");
//
//		try {
//			ctrl = new BrowserController(CommonConst.BROWSER_SAFARI.get(), CommonConst.SERVICE_NAVER.get());
//			ctrl.scrollByMouse();
//			//ctrl.moveToClickElement();
//		} catch (NoSuchElementException e) {
//			e.printStackTrace();
//			Log.error(e);
//		} catch (Exception ex) {
//			ex.printStackTrace();
//			Log.error(ex);
//		} finally {
//			ctrl.closeBrowser();
//		}
//		Log.info("safari    end =============================================================");
//		Log.info("chrome start=============================================================");
//
//		try {
//			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
//			ctrl.scrollByMouse();
//			//ctrl.moveToClickElement();
//		} catch (NoSuchElementException e) {
//			e.printStackTrace();
//			Log.error(e);
//		} catch (Exception ex) {
//			ex.printStackTrace();
//			Log.error(ex);
//		} finally {
//			ctrl.closeBrowser();
//		}
//		Log.info("chrome end =============================================================");
		assertTrue(true);
	}
	
	@Test
	public void testKeyboard() {
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.hitKeyword("AC00:가\" ~ \"D7A3:힣\" 에 속한 글자면 분해");
/*			ctrl.hitKeyword("a");
			Thread.sleep(3000);
			List<Character> strList = Hangul.convertToKeys2("아름다운ㅁㅅㅛ agde");
			for (Character str : strList) {
				ctrl.hitKeyword(str.toString());
				Thread.sleep(3000);
			}*/
//			ctrl.hitKeyword(Keys.chord(Keys.SHIFT, Keys.ALT , "a"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, "ㄱ"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, "ㅜ"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord('ㄱ', 'ㅜ'));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, Keys.SHIFT, "s"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, Keys.SHIFT, "j"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, Keys.SHIFT, "k"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.BACK_SPACE));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, Keys.SHIFT, "e"));
//			Thread.sleep(1000);
//			ctrl.hitKeyword(Keys.chord(Keys.ALT, Keys.SHIFT, "r"));
//			Thread.sleep(3000);
//			ctrl.hitKeyword(Keys.chord("ㄴ"));
//			Thread.sleep(3000);
//			ctrl.hitKeyword(Keys.chord("ㅗ"));
//			Thread.sleep(3000);
//			ctrl.hitKeyword(Keys.chord("ㄴ"));
//			Thread.sleep(3000);

//			ctrl.hitKeyword(Keys.chord(Keys.BACK_SPACE));
			Thread.sleep(100000);
		} catch (NoSuchElementException e) {
			e.printStackTrace();
			Log.error(e);
		} catch (Exception ex) {
			ex.printStackTrace();
			Log.error(ex);
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(true);
	}
	
	@Test
	public void testDoRobot() {
		boolean result = true;
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.doRobot();
		} catch (Exception e) {
			Log.error(e);
			result = false;
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(result);
	}

	@Test
	public void testScrollUpMainPage() {
		boolean result = true;
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
			ctrl.scrollUpMainPage();
			Thread.sleep(10000);
			
		} catch (Exception e) {
			Log.error(e);
			result = false;
		} finally {
			ctrl.closeBrowser();
		}
		assertTrue(result);
	}

	@Test
	public void testScrollDownSearchedPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testScrollUpSearchedPage() {
		Log.info("firefox     start=============================================================");
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_CHROME.get(), CommonConst.SERVICE_NAVER.get());
		} catch (Exception ex) {
			Log.error("",ex);
		} finally {
			ctrl.closeBrowser();
		}
		try {
			ctrl = new BrowserController(CommonConst.BROWSER_IEXPLORER.get(), CommonConst.SERVICE_NAVER.get());
		} catch (Exception ex) {
			Log.error("",ex);
		} finally {
			ctrl.closeBrowser();
		}
		assert(true);
	}

	@Test
	public void testGoBlogNextPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testGoBlogPage() {
		fail("Not yet implemented");
	}

	@Test
	public void testGoBlogFirstLink() {
		fail("Not yet implemented");
	}

	@Test
	public void testGoMain() {
		fail("Not yet implemented");
	}

	@Test
	public void testGoBack() {
		fail("Not yet implemented");
	}

	@Test
	public void testFindClickTitle() {
		fail("Not yet implemented");
	}

	@Test
	public void testCloseBrowser() {
		fail("Not yet implemented");
	}

}
