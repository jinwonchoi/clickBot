package com.bgt.automation.framework;

import java.awt.Point;
import java.awt.Robot;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.interactions.HasInputDevices;
import org.openqa.selenium.interactions.KeyDownAction;
import org.openqa.selenium.interactions.Mouse;
import org.openqa.selenium.interactions.touch.TouchActions;
import org.openqa.selenium.internal.Locatable;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import scala.annotation.meta.getter;

import com.bgt.automation.framework.impl.DaumElement;
import com.bgt.automation.framework.impl.NaverElement;
import com.bgt.automation.framework.pattern.Hangul;
import com.bgt.automation.framework.pattern.TypingCmd;
import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class BrowserController {

	static Logger Log = Logger.getLogger(BrowserController.class);
	public WebDriver driver = null;

	ServiceElement serviceElement;
	ActionItem item;
	
	public BrowserController(String browserType, String serviceType, ActionItem item) throws Exception {
		this(browserType, serviceType);
		this.item = item;
	}

	public BrowserController(String browserType, String serviceType) throws Exception {
		driver = Utils.openBrowser(browserType);

		if (serviceType.equals(CommonConst.SERVICE_NAVER.get())) {
			serviceElement = new NaverElement(driver);
		} else if (serviceType.equals(CommonConst.SERVICE_NAVER.get())) {
			serviceElement = new DaumElement(driver);
		}
		driver.get(serviceElement.defaultPage());
	}
	
	public BrowserController(String browserType, String serviceType, String proxy) throws Exception {
		driver = Utils.openBrowser(browserType, proxy);

		if (serviceType.equals(CommonConst.SERVICE_NAVER.get())) {
			serviceElement = new NaverElement(driver);
		} else if (serviceType.equals(CommonConst.SERVICE_NAVER.get())) {
			serviceElement = new DaumElement(driver);
		}
		driver.get(serviceElement.defaultPage());
	}
	
	public void searchKeyword(String keyword )  throws Exception {
		//java.util.List<WebElement>  inputs = Utils.getInput(driver);
		serviceElement.searchInput().sendKeys(keyword);
		serviceElement.searchButton().click();
	}
	
	public void go(String url) {
		driver.get(url);
	}

	public void moveToClickElement()  throws Exception {
		//Create an action object called myMouse
/*		Actions myMouse = new Actions(driver); 

		//there is a slight delay before each mouse movement hence the "Thread.sleep" statement
		myMouse.moveToElement(serviceElement.searchInput()).build().perform();   //Shows link
*/
		//driver.get("http://www.espncricinfo.com/"); 
//		Actions act = new Actions(driver);	
//		WebElement mainMenu = driver.findElement(By.linkText("Features")); 
//		act.moveToElement(mainMenu).build().perform();

		Locatable hoverItem = (Locatable) serviceElement.searchButton();

		Log.debug("getMouse=======================================");
		Mouse mouse = ((HasInputDevices) driver).getMouse();
		Log.debug("getCoordinates=================================");
		mouse.mouseMove(hoverItem.getCoordinates());
		Log.debug("MouseMove=========================================");
		Thread.sleep(5000L);
		
//		Point coordinates = serviceElement.getLocation(); 
//		Robot robot = new Robot(); 
//		robot.mouseMove(coordinates.getX(),coordinates.getY()+120); 
		//
//		Point coordinates = mainMenu.getLocation();//driver.findElement(By.id("ctl00_portalmaster_txtUserName")).getLocation();
//		  Robot robot = new Robot();
//		  robot.mouseMove(coordinates.getX(),coordinates.getY()+120);
//		Thread.sleep(5000L);
	}
	
	public void hitKeyword(String keyword) throws Exception {
		List<String> resultList = Hangul.convertToKeys(keyword);
		String result = "";
		for (String str : resultList) {
			//result += str;
			serviceElement.searchInput().sendKeys(str);
			Thread.sleep(Utils.randInt(1, 6)*500);
		}	

		if (Utils.randInt(1, 3)%3 == 1) {
			serviceElement.searchInput().click();
		} else {
			serviceElement.searchInput().sendKeys(Keys.ENTER);
//			if (serviceElement.searchInput() != null) {
//				Action action=new Actions(driver).keyUp(serviceElement.searchInput(),Keys.ENTER).build();
//				action.perform();
//			}
		}

	}
	
	public void hitKeyword(CharSequence... key)  throws Exception {
		serviceElement.searchInput().sendKeys(Keys.chord(key));

		if (Utils.randInt(1, 3)%3 == 1) {
			serviceElement.searchInput().click();
		} else {
			serviceElement.searchInput().sendKeys(Keys.ENTER);
//			if (serviceElement.searchInput() != null) {
//				Action action=new Actions(driver).keyUp(serviceElement.searchInput(),Keys.ENTER).build();
//				action.perform();
//			}
		}
	}

	
	
	public void scrollDownMainPage() throws Exception {
		WebElement el;
		try {
			el = serviceElement.introMainForScroll();
			if (el == null) {
				el = serviceElement.searchedMainForScroll();
			}
			if (el == null) {
				el = serviceElement.blogMainForScroll();
			}

			for (int i = 0; i < 20; i++) {
				el.sendKeys(Keys.ARROW_DOWN);
				Thread.sleep(100);
			}
		} catch (InterruptedException e) {
			Log.error(e);
		} catch (Exception ex) {
			Log.error(ex);
		}
/*		
		int x = 0;
		while((Long) jse
				.executeScript("return document.body.getElementById('"+serviceElement.introContent()+"').getBoundingClientRect().top") > 0 )
		{
			x = x + 2;
			jse.executeScript("window.scrollByLines(2)");
			Log.debug("Client top is = " + (Long) jse.executeScript("return document.body.getElementById('"+serviceElement.introContent()+"').getBoundingClientRect().top"));            
		}
		Log.debug("Element is visible after  " + x + " scrolls");
*/		
	}

	public boolean findClickLink() {
		boolean result = true;
		WebElement link;
		try {
			link = Utils.findLinkByHref(driver,  item.getTargetUrl()); 
					//(new WebDriverWait(driver, 2))
					 // .until(ExpectedConditions.presenceOfElementLocated(By.linkText(item.getTargetUrl()))); 
					//driver.findElement(By.linkText(item.getTargetUrl()));
			if (link == null) {
				Log.debug("Link with text <" + item.getTargetUrl() + "> not present");
				result = false;
			} else {
				Log.debug("Link with text <" + item.getTargetUrl() + "> is present");
				link.click();
			}
		} catch (NoSuchElementException ex) { 
			/* do nothing, link is not present, assert is passed */
			Log.debug("Link with text <" + item.getTargetUrl() + "> not present");
			result = false;
		}

		return result;
	}

	public boolean goBlogFrame() throws Exception {
		boolean result = true;
		try {
			driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
			driver = getFrame(driver);
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS);
		}
		return result;
	}
	/**
	 * 블로그 공감 찾아서 클릭건수 확인
	 * @return
	 * @throws Exception
	 */
	public boolean needClickLike() throws Exception {
		boolean result = true;
		
		try {
	        java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
	        
	        Log.debug(links.size());
//	        for (int i = 0; i<links.size()-1; i++)
//	        	Log.debug(links.get(i).getText());
	        
			int likeCount = serviceElement.blogLikeCount(item.getPageId());
			if (likeCount < item.getBlogLikeCount()) {
				serviceElement.blogLikeButton(item.getPageId()).click();
			}
		} catch (NoSuchElementException ex) { 
			Log.error(String.format("blog id[%s] like click failed", item.getPageId()),ex);
			result = false;
		}
		return result;
	}
	
	public boolean clickLoginPopup() throws Exception {
		boolean result = true;
		
		try {
			TypingCmd.execute(serviceElement.popupLoginId(), item.getLoginId());
			TypingCmd.execute(serviceElement.popupLoginPwd(), item.getLoginpwd());
			
			serviceElement.popupLoginButton().click();
		} catch (NoSuchElementException ex) { 
			Log.error("popup login failed.",ex);
			result = false;
		}
		return result;
	}
	
	public void scrollByMouse() throws Exception {
	
//		JavascriptExecutor jsx = (JavascriptExecutor)driver;
//		jsx.executeScript("window.scrollBy(0,450)", "");
//		Point coordinates = serviceElement.getLocation();
		org.openqa.selenium.Dimension dimension = driver.manage().window().getSize();
		org.openqa.selenium.Point coordinates = driver.manage().window().getPosition();
		Robot robot = new Robot();
		robot.mouseMove(coordinates.getX()+dimension.getWidth()/2,coordinates.getY()+dimension.getHeight()/2);
		for (int i = 0; i < 10; i++) {
			robot.mouseWheel(3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
			Thread.sleep(1000L);
		}
		
		for (int i = 0; i < 10; i++) {
			robot.mouseWheel(-3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
			Thread.sleep(500L);
		}
		
		for (int i = 0; i < 10; i++) {
			robot.mouseWheel(3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
			Thread.sleep(1000L*Utils.randInt(3, 5));
		}
		
//		Point coordinates = mainMenu.getLocation();//driver.findElement(By.id("ctl00_portalmaster_txtUserName")).getLocation();
//		Robot robot = new Robot();
//		robot.mouseMove(coordinates.getX(),coordinates.getY()+120);
	}
	
	public void scrollUpMainPage() throws Exception {
		WebElement el;
		try {
			el = driver.findElement(By.tagName("body"));
			if (el == null) {
				el = serviceElement.searchedMainForScroll();
			}
			if (el == null) {
				el = serviceElement.blogMainForScroll();
			}

			for (int i = 0; i < 20; i++) {
				//serviceElement.searchedContentForScroll()
				el.sendKeys(Keys.ARROW_UP);
				Thread.sleep(100);
			}
		} catch (InterruptedException e) {
			Log.error(e);
		} catch (Exception ex ) {
			Log.error(ex);
		}
	}
	
	public void scrollDownBlogPage() throws Exception {
		WebElement el;
		try {
			el = driver.findElement(By.tagName("body"));
			if (el == null) {
				el = serviceElement.searchedMainForScroll();
			}
			if (el == null) {
				el = serviceElement.blogMainForScroll();
			}
			for (int i = 0; i < 20; i++) {
				el.sendKeys(Keys.ARROW_DOWN);
				Thread.sleep(100);
			}
		} catch (InterruptedException e) {
			Log.error(e);
		} catch (Exception ex ) {
			Log.error(ex);
		}
	}
	
	public void scrollUpBlogPage() throws Exception {
		WebElement el;
		try {
			el = driver.findElement(By.tagName("body"));
			if (el == null) {
				el = serviceElement.searchedMainForScroll();
			}
			if (el == null) {
				el = serviceElement.blogMainForScroll();
			}

			for (int i = 0; i < 20; i++) {
				el.sendKeys(Keys.ARROW_UP);
				Thread.sleep(100);
			}
		} catch (InterruptedException e) {
			Log.error(e);
		} catch (Exception ex ) {
			Log.error(ex);
		}

	}
	
	public void doRobot() throws Exception {
		Point p = RobotCalibration.calibrate(driver);
		Log.debug("Left offset: " + p.x + ", top offset: " + p.y);
	}
	
	public void goFirstTab() throws Exception {
	    Set<String>tabList = driver.getWindowHandles();
	    String secondWindow = "";
	    for (String tab : tabList) {
	    	Log.debug("tab is "+tab);
	    	secondWindow = tab;
	    	break;
		}
    	driver.switchTo().window(secondWindow);	}

	public void goLastTab() throws Exception {
	    Set<String>tabList = driver.getWindowHandles();
	    String secondWindow = "";
	    for (String tab : tabList) {
	    	Log.debug("tab is "+tab);
	    	secondWindow = tab;
		}
    	driver.switchTo().window(secondWindow);
	}

	public void closeTab() throws Exception {
		driver.close();
		goLastTab();
	}
	
	public WebDriver getFrame(WebDriver driver) {
    	List<WebElement> frameset = driver.findElements(By.tagName("frame"));
		 if(frameset.size()>0) {  
			 for (WebElement framename : frameset){  
				 Log.debug("frameid: " + framename.getAttribute("name"));  
				 driver = driver.switchTo().frame(framename);
				 driver = getFrame(driver);
				 break;
			 }  
		 }  
		 else 
			 Log.debug("can not find any frame in HTML");  
		 return driver;
	}
	
	public void doCheck() {
		try {
			driver.get("http://section.blog.naver.com/main/DirectoryPostList.nhn?option.directorySeq=35");
			
			driver.findElement(By.partialLinkText("필리핀어학연수 비용 무이자 카드결제 제도")).click();

		    Set<String>tabList = driver.getWindowHandles();
		    String secondWindow = "";
		    for (String tab : tabList) {
		    	Log.debug("tab is "+tab);
		    	secondWindow = tab;
			}
	    	driver.switchTo().window(secondWindow);
	    	driver = getFrame(driver);

			WebElement sympathy = driver.findElement(By.xpath("//*[@id='printPost1']/tbody/tr/td[2]/div[4]/p/span/a"));
			System.out.println(sympathy.getText());
			sympathy.click();
			//			//driver.switchTo().defaultContent();
//		    java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
//		    
//	        Log.debug(links.size());
//	        for (int i = 0; i<links.size(); i=i+1)
//	        	Log.debug(links.get(i).getText());
	        
/*	        java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
	        
	        Log.debug(links.size());
	        for (int i = 1; i<=links.size(); i=i+1)
	        	Log.debug(links.get(i).getText());
*/
/*		    Set<String>tabList = driver.getWindowHandles();
		    for (String tab : tabList) 
		    	Log.debug("tab is "+tab);
		    driver.findElement(By.linkText("회사소개")).click();
		    Set<String>tabList2 = driver.getWindowHandles();
		    String secondWindow = driver.getWindowHandles().iterator().next();
		    Log.debug("secondWindow is "+secondWindow);
		    driver.switchTo().window(secondWindow);
	    	Log.debug("=======================================================");
		    //Log.debug(driver.getWindowHandle());

		    Set<String>tabList3 = driver.getWindowHandles();
		    for (String tab : tabList3) 
		    	Log.debug("tab is "+tab);
*/
//		    java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
//	    
//	        Log.debug(links.size());
//	        for (int i = 1; i<=links.size(); i=i+1)
//	        	Log.debug(links.get(i).getText());
	        
			//Log.info("blog class "+driver.findElement(By.cssSelector(".blog.section._blogBase")).isDisplayed());
			//Log.info("kin class "+driver.findElement(By.cssSelector(".kinn.section._kinBase")).isDisplayed());
		} catch (Exception ex) {
			ex.printStackTrace();
			Log.error(ex);
		}
	}
	
	public boolean isDisplayed() {
		return serviceElement.blogSection().isDisplayed();
	}
	
	public void scrollDownSearchedPage() throws Exception {
		scrollDownMainPage();
	}
	
	public void scrollUpSearchedPage() throws Exception {
		scrollUpMainPage();
	}
	
	public void goBlogPage() throws Exception {
		serviceElement.blogSectionMore().click();
	}
	
	public void goBlogNextPage() throws Exception {
		serviceElement.blogNext().click();
	}
	
	public void goBlogPage(int pageNo)  throws Exception {
		serviceElement.blogPage(pageNo).click();
	}
	
	public void goBlogFirstLink() throws Exception {
		serviceElement.blogFirstLink().click();
	}
	
	public void goMain() throws Exception {
		driver.navigate().to(serviceElement.defaultPage());
	}
	
	public void goBack() throws Exception {
		driver.navigate().back();
	}
	
	public boolean findClickTitle(String title) throws Exception {
		try {
			serviceElement.searchedMainForScroll().findElement(By.partialLinkText(title)).click();
		} catch (Exception ex) {
			Log.error(String.format("no link[%s]", title),ex);
			return false;
		}
		return true;
	}
	
	public void closeBrowser() {
		if (driver instanceof FirefoxDriver) {
			driver.close();
	        try {
	            Thread.sleep(5000);
	        } catch(Exception e) {
	        }
		}
		try {
	    if (driver != null) 
	    	driver.quit();
		} catch (Exception e) {}
	}
}
