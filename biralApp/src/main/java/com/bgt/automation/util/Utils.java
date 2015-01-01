package com.bgt.automation.util;

import java.awt.AWTException;
import java.awt.Robot;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.Random;
import java.util.concurrent.TimeUnit;

import org.apache.commons.lang.math.RandomUtils;
import org.apache.log4j.Logger;
import org.openqa.selenium.Alert;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoAlertPresentException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.remote.BrowserType;
import org.openqa.selenium.remote.CapabilityType;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.safari.SafariDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.bgt.mybatis.vo.Task;
import com.bgt.mybatis.vo.TaskSchedule;

public class Utils {

	static Logger Log = Logger.getLogger(Utils.class);
	//public static WebDriver driver = null;
	
	public static WebDriver openBrowser(String  type) throws Exception{
		return openBrowser(type, "");
	}

	public static WebDriver openBrowser(String  type, String proxyStr) throws Exception{
		WebDriver driver = null;

		try{
			//proxyStr = "121.126.216.144:6185";

			org.openqa.selenium.Proxy proxy = null;

			if (proxyStr != null && !proxyStr.equals("")) {
				proxy = new org.openqa.selenium.Proxy();
				proxy.setHttpProxy(proxyStr)
				     .setFtpProxy(proxyStr)
				     .setSslProxy(proxyStr);
			}			

			if (type.equals(CommonConst.BROWSER_CHROME.get())) {
				
				//System.setProperty("webdriver.chrome.driver", "/java/selenium/selenium-2.43.1/chromedriver.exe");
				String appHome = System.getProperty("app_home");
				System.setProperty("webdriver.chrome.driver", appHome+"/bin/chromedriver.exe");
				ChromeOptions options = new ChromeOptions();
				options.addArguments("chrome.switches","--disable-extensions");
				//System.setProperty("webdriver.chrome.driver",(System.getProperty("user.dir") + "//src//test//resources//chromedriver_new.exe"));

				DesiredCapabilities capabilities = DesiredCapabilities.chrome();
				capabilities.setCapability(ChromeOptions.CAPABILITY, options);
				if (proxy != null) {
					capabilities.setCapability(CapabilityType.PROXY, proxy);
				}
				driver = new ChromeDriver(capabilities);
				//ChromeOptions options = new ChromeOptions();
				//options.addArguments("window-size=800,600");
			} else if (type.equals(CommonConst.BROWSER_IEXPLORER.get())) {
				/**
				 *   argument : -port=5555 -silent -host=172.0.0.1
				 *   
				 *   property  :
				 *   webdriver.ie.driver	The location of the IE driver binary.
				 *   webdriver.ie.driver.host	Specifies the IP address of the host adapter on which the IE driver will listen.
				 *   webdriver.ie.driver.loglevel	Specifies the level at which logging messages are output. Valid values are FATAL, ERROR, WARN, INFO, DEBUG, and TRACE. Defaults to FATAL.
				 *   webdriver.ie.driver.logfile	Specifies the full path and file name of the log file.
				 *   webdriver.ie.driver.silent	Suppresses diagnostic output when the IE driver is started.
				 *   webdriver.ie.driver.extractpath	Specifies the full path to the directory used to extract supporting files used by the server. Defaults to the TEMP directory if not specified.
				 *    
				 */
				//System.setProperty("webdriver.ie.driver", "/java/selenium/selenium-2.43.1/IEDriverServer.exe");
				String appHome = System.getProperty("app_home");
				System.setProperty("webdriver.ie.driver", appHome+"/bin/IEDriverServer.exe");
				DesiredCapabilities capabilities = DesiredCapabilities.internetExplorer();
				if (proxy != null) {
					capabilities.setCapability(CapabilityType.PROXY, proxy);
				}
				driver = new InternetExplorerDriver(capabilities);

			} else if (type.equals(CommonConst.BROWSER_SAFARI.get())) {
				DesiredCapabilities capabilities = DesiredCapabilities.safari();
				if (proxy != null) {
					capabilities.setCapability(CapabilityType.PROXY, proxy);
				}
				driver = new SafariDriver(capabilities);
			} else if (type.equals(CommonConst.BROWSER_FIREFOX.get())) {
				DesiredCapabilities capabilities = DesiredCapabilities.firefox();
				if (proxy != null) {
					capabilities.setCapability(CapabilityType.PROXY, proxy);
				}
				driver = new FirefoxDriver(capabilities);
			}

			Log.info(driver.getClass().getName()+"-New driver instantiated");
			Log.info("Web application launched successfully");
		}catch (Exception e){

			Log.error("openBrowser ",e);
		} finally {
			driver.manage().timeouts().implicitlyWait(CommonConst.WEB_DEFAULT_WAITING_SEC.val(), TimeUnit.SECONDS); 
		}
		return driver;
	}
	
	public static boolean isIexplorer(WebDriver driver) {
		return (driver instanceof InternetExplorerDriver);
	}
	
	public static void waitRandomTime() {
		try {
			int random = RandomUtils.nextInt(4);
			Log.debug("Sleep for "+random+"sec.");
			Thread.sleep(1000*random);
		} catch (InterruptedException e) {
			Log.error("waitRandomTime", e);
		}
	}
	
	public static void scrollDown(WebDriver driver) {
		org.openqa.selenium.Dimension dimension = driver.manage().window().getSize();
		org.openqa.selenium.Point coordinates = driver.manage().window().getPosition();
		Robot robot;
		try {
			robot = new Robot();
			robot.mouseMove(coordinates.getX()+dimension.getWidth()/2,coordinates.getY()+dimension.getHeight()/2);
			for (int i = 0; i < 5; i++) {
				robot.mouseWheel(3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
				Thread.sleep(1000L);
			}
		} catch (Exception e) {
			Log.error("Scroll Down", e);
		}
	}
	
	public static void scrollUp(WebDriver driver) {
		org.openqa.selenium.Dimension dimension = driver.manage().window().getSize();
		org.openqa.selenium.Point coordinates = driver.manage().window().getPosition();

		Robot robot;
		try {
			robot = new Robot();
			robot.mouseMove(coordinates.getX()+dimension.getWidth()/2,coordinates.getY()+dimension.getHeight()/2);
			for (int i = 0; i < 5; i++) {
				robot.mouseWheel(-3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
				Thread.sleep(500L);
			}
		} catch (Exception e) {
			Log.error("Scroll Up", e);
		}
	}

	public static void scrollReadDown(WebDriver driver) {
		org.openqa.selenium.Dimension dimension = driver.manage().window().getSize();
		org.openqa.selenium.Point coordinates = driver.manage().window().getPosition();

		Robot robot;
		try {
			robot = new Robot();
			robot.mouseMove(coordinates.getX()+dimension.getWidth()/2,coordinates.getY()+dimension.getHeight()/2);
			for (int i = 0; i < 5; i++) {
				robot.mouseWheel(3*Utils.randInt(1, 4));//mouseMove(coordinates.getX(),coordinates.getY()+120); 
				Thread.sleep(1000L*Utils.randInt(3, 5));
			}
		} catch (Exception e) {
			Log.error("Scroll Up", e);
		}
	}


	public static void waitLongRandomTime() {
		try {
			int random = Utils.randInt(5, 10);
			Log.debug("Sleep for "+random+"sec.");
			Thread.sleep(1000*random);
		} catch (InterruptedException e) {
			Log.error("waitRandomTime", e);
		}
	}
	
	public static void generateRandomHit24() {
		String str = RandomUtils.nextInt(8)+"";
		int sum = 0;
		for (int i = 0; i<23; i++) {
			int output = RandomUtils.nextInt(8);
			sum += output;
			str += ","+ output;
		}
		System.out.println(sum+","+str);
	}

	public static int randInt(int min, int max) {

	    // NOTE: Usually this should be a field rather than a method
	    // variable so that it is not re-seeded every call.
	    Random rand = new Random();

	    // nextInt is normally exclusive of the top value,
	    // so add 1 to make it inclusive
	    int randomNum = rand.nextInt((max - min) + 1) + min;

	    return randomNum;
	}
	
	public static void addTaskToSchedule(TaskSchedule schedule, Task task) {
		String taskListStr = schedule.getJobList();
		if (taskListStr != null && taskListStr.length() > 0)  
			taskListStr += CommonConst.TASK_LIST_DELIMITER.get() + Integer.toHexString(task.getTaskId());
		else 
			taskListStr += Integer.toHexString(task.getTaskId());
		schedule.setJobList(taskListStr);
	}
	
	public static List<Integer> getTaskList(String str) {
		List<Integer> taskList = new ArrayList<Integer>();
		
		for (String item : str.split(CommonConst.TASK_LIST_DELIMITER.get()))
			taskList.add(Integer.parseInt(item, 16));
		
		return taskList;
	}
	
	public static String getTaskListStr(List<Integer> taskList) {
		StringBuffer sb = new StringBuffer();
		for (Integer item : taskList) {
			sb.append(Integer.toHexString(item)+CommonConst.TASK_LIST_DELIMITER.get());
		}
		if (sb.length()>0)
			sb.deleteCharAt(sb.length()-1);
		return sb.toString();
	}
	
	/**
	 * Scroll 알고리즘
		=============
		
		read의 경우
		- scroll (1~5회 랜덤
		- sleep 1~3초
		
		scroll total += scroll
		< total_scroll

	 * @param el
	 */
	public static void scrollDownList(WebElement el) {
		for (int i = 0; i < 200; i++) {
			el.sendKeys(Keys.ARROW_DOWN);
			if (RandomUtils.nextInt(4)%3 == 1) {
				Utils.waitRandomTime();
			}
		}
	}

	public static void scrollDownContent(WebElement el) {
		for (int i = 0; i < 200; i++) {
			el.sendKeys(Keys.ARROW_DOWN);
			if (RandomUtils.nextInt(4)%2 == 1) {
				Utils.waitRandomTime();
			}
		}
	}

	public static void scrollUpList(WebElement el) {
		for (int i = 0; i < 200; i++) {
			el.sendKeys(Keys.ARROW_DOWN);
			if (RandomUtils.nextInt(4)%3 == 1) {
				Utils.waitRandomTime();
			}
		}
	}

	public static void scrollUpContent(WebElement el) {
		for (int i = 0; i < 200; i++) {
			el.sendKeys(Keys.ARROW_DOWN);
			if (RandomUtils.nextInt(4)%2 == 1) {
				Utils.waitRandomTime();
			}
		}
	}

	public static void clickLinkByHref(WebDriver driver, String href) {
	    List<WebElement> anchors = driver.findElements(By.tagName("a"));
	    Iterator<WebElement> i = anchors.iterator();
	 
	    while(i.hasNext()) {
	        WebElement anchor = i.next();
	        if(anchor.getAttribute("href").contains(href)) {
	            anchor.click();
	            break;
	        }
	    }
	}
	
	public static WebElement findLinkByHref(WebDriver driver, String href) {
	    List<WebElement> anchors = driver.findElements(By.tagName("a"));
	    Iterator<WebElement> i = anchors.iterator();
	    WebElement el = null;
	    while(i.hasNext()) {
	        WebElement anchor = i.next();
	        //LOGGER.debug("비교대상:"+anchor.getAttribute("href"));
	        //LOGGER.debug("비교인자"+":"+href);
	        if(anchor.getAttribute("href").contains(href)) {
	            el = anchor;
	            break;
	        }
	    }
	    return el;
	}
	
	public static WebElement getLink(WebElement parent, String linkPart) {
        java.util.List<WebElement> links = parent.findElements(By.tagName("a"));
        WebElement result = null;
        Log.debug(links.size());
        
        for (WebElement link : links) {
        	String linkStr = link.getAttribute("href");
        	Log.debug("getLink by "+linkPart +" ==>link:"+linkStr);
        	if (linkStr != null && linkStr.contains(linkPart)) {
        		result = link;
        	}
        }
        return result;
	}
	
	public static java.util.List<WebElement> getLinks(WebDriver driver) {
        java.util.List<WebElement> links = driver.findElements(By.tagName("a"));
        
        Log.debug(links.size());
        for (int i = 1; i<=links.size(); i=i+1)
        	Log.debug(links.get(i).getText());
 
        return links;
	}
	
	public static java.util.List<WebElement> getInput(WebDriver driver) {
        java.util.List<WebElement> inputs = driver.findElements(By.tagName("Input"));
        
        Log.debug(inputs.size());
        for (int i = 1; i<=inputs.size(); i=i+1)
        	Log.debug(inputs.get(i).getText());
 
        return inputs;
	}
		
	public static java.util.List<WebElement> getCheckboxes(WebDriver driver) {
		java.util.List<WebElement> checkboxes = driver.findElements(By.xpath("//input[@type='checkbox']"));
		Log.debug(checkboxes.size());
		return checkboxes;
	}

	public static java.util.List<WebElement> getTextboxes(WebDriver driver) {
		java.util.List<WebElement> textboxes = driver.findElements(By.xpath("//input[@type='text'[@class='inputtext']")); 
		Log.debug(textboxes.size());
		return textboxes;
	}
	public static void mouseHoverAction(WebDriver driver, WebElement mainElement, String subElement){

		Actions action = new Actions(driver);

		action.moveToElement(mainElement).perform();

		if(subElement.equals("Accessories")){

			action.moveToElement(driver.findElement(By.linkText("Accessories")));

			Log.info("Accessories link is found under Product Category");

		}

		if(subElement.equals("iMacs")){

			action.moveToElement(driver.findElement(By.linkText("iMacs")));

			Log.info("iMacs link is found under Product Category");

		}

		if(subElement.equals("iPads")){

			action.moveToElement(driver.findElement(By.linkText("iPads")));

			Log.info("iPads link is found under Product Category");

		}

		if(subElement.equals("iPhones")){

			action.moveToElement(driver.findElement(By.linkText("iPhones")));

			Log.info("iPhones link is found under Product Category");

		}

		action.click();

		action.perform();

		Log.info("Click action is performed on the selected Product Type");

	}

	public static void waitForElement(WebDriver driver, WebElement element){

		WebDriverWait wait = new WebDriverWait(driver, 10);

		wait.until(ExpectedConditions.elementToBeClickable(element));

	}
	
	public static boolean doAlertPresent(WebDriver driver) {
		boolean result = false;
		Alert alert = null;
	    try { 
	        alert = driver.switchTo().alert();
	        Utils.waitRandomTime();
	        alert.accept();
	    	Log.info("alert창 예 누름");
	    	result = true;
	    } catch (NoAlertPresentException Ex) { 
	    	Log.info("alert창 없음");
	    }
	    return result;
	}
	
	public static String getFullDateStr() {
		  return new java.text.SimpleDateFormat("yyyyMMddHHmmss").format(new Date());
	}
	
	public static String getmmssStr() {
		  return new java.text.SimpleDateFormat("mmss").format(new Date());
	}
	
	public static String getDateStrNextHour(String yyyyMMddHH) {
		String result = "";
		
		try {
			Calendar cal = Calendar.getInstance();
			cal.setTime(new java.text.SimpleDateFormat("yyyyMMddHH").parse(yyyyMMddHH));
			cal.add(Calendar.HOUR, 1);
			result = new java.text.SimpleDateFormat("yyyyMMddHH").format(cal.getTime());
		} catch (ParseException e) {
			Log.error("getDateStrNextHour",e);
		}
		return result;
	}

	public static String getFullDateStr(Date dateTime) {
		String result = "";
		
		try {
			result = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(dateTime);
		} catch (Exception e) {
			Log.error("getFullDateStr",e);
		}
		return result;
	}
	
	public static void main(String[] args) {
/*		List<Integer> taskList = new ArrayList<Integer>();
		System.out.println(Integer.toHexString(233474));
		System.out.println(Integer.parseInt("2A",16));
		String str = 
		Integer.toHexString(233474)
		+":"+ Integer.toHexString(238964)
		+":"+ Integer.toHexString(2435234)
		+":"+ Integer.toHexString(0)
		+":"+ Integer.toHexString(26634)
		+":"+ Integer.toHexString(0xffffffff)
		+":"+ Integer.toHexString(283534);
		
		System.out.println(str);
		//String str = "ad23df23ad34ds33bh43";
		
		for (String val : str.split(":")) {
			System.out.println(Integer.parseInt(val,16));
		}*/
		
		System.out.println("e:757ee9:757eea:757ee9:757eec:15:757eea:757ee9:757eeb:757ee9:f:757ee9:757eea:757eea:757eea:757eea:757ee9:757eec:757eec:757ee9:757eec:e:757eea:757ee9:757ee9:757ee9:f:757eec:757ee9:757eea:757eeb:757eea:757ee9:757ee9:757eec:757eec:e:757eeb:757eea:f:757ee9:757eea:757ee9:757eea:757ee9:757eec:757eea:757ee9:e:757eea:757eeb:757ee9:757eec:757eea:757ee9:757ee9:757eea:757eeb:757eec:e:757ee9".split(":").length);
		System.out.println(String.format("%02d", 22));
		
		System.out.println(Utils.getDateStrNextHour("2014103023"));
		System.out.println(Utils.getDateStrNextHour("2014103002"));
/*		for (int i=0;i< 12; i++)
		Utils.generateRandomHit24();
		
		System.out.println(Utils.getFullDateStr());
*/		//return taskList;
		
	}	

}