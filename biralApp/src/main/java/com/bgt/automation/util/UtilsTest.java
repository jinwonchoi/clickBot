package com.bgt.automation.util;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.remote.BrowserType;

public class UtilsTest {

	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testOpenChromeBrowser() {
		try {
			Utils.openBrowser(BrowserType.CHROME);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		assertTrue(true);
	}
	
	@Test
	public void testOpenIExploreBrowser() {
		try {
			
			Utils.openBrowser(BrowserType.IEXPLORE);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		assertTrue(true);
	}

	@Test
	public void testOpenFireFoxBrowser() {
		try {
			Utils.openBrowser(BrowserType.FIREFOX);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		assertTrue(true);
	}

	@Test
	public void testOpenSafariBrowser() {
		try {
			Utils.openBrowser(BrowserType.SAFARI);

		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		assertTrue(true);
	}

	@Test
	public void testMouseHoverAction() {
		fail("Not yet implemented");
	}

	@Test
	public void testWaitForElement() {
		fail("Not yet implemented");
	}

}
