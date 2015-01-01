package biral;



import static org.junit.Assert.assertEquals;
 



import java.io.File;
import java.io.IOException;

import junit.framework.TestCase;

 import org.junit.*;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriverService;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;
 
 @RunWith(JUnit4.class)
 public class ChromeTest extends TestCase {
 
   private static ChromeDriverService service;
   private WebDriver driver;
 
   @BeforeClass
   public static void createAndStartService() {
     service = new ChromeDriverService.Builder()
         .usingDriverExecutable(new File("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"))
         .usingAnyFreePort()
         .build();
     try {
		service.start();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
   }
 
   @AfterClass
   public static void createAndStopService() {
     service.stop();
   }
 
   @Before
   public void createDriver() {
     driver = new RemoteWebDriver(service.getUrl(),
         DesiredCapabilities.chrome());
   }
 
   @After
   public void quitDriver() {
     driver.quit();
   }
 
   @Test
   public void testGoogleSearch() {
     driver.get("http://www.google.com");
     WebElement searchBox = driver.findElement(By.name("q"));
     searchBox.sendKeys("webdriver");
     searchBox.click();
     assertEquals("webdriver - Google Search", driver.getTitle());
   }
 }
 