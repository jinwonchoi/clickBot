package com.bgt.automation.framework;

import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import com.bgt.automation.pageObj.HomePage;
import com.bgt.automation.pageObj.LoginPage;

public class PageObjectModel {

	static Logger LOGGER = Logger.getLogger(PageObjectModel.class);
    private static WebDriver driver = null;

    public PageObjectModel() {
		// TODO Auto-generated constructor stub
	}
    
  public static void main(String[] args) {

    driver = new FirefoxDriver();

    driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

    driver.get("http://www.store.demoqa.com");

    // Use page Object library now

    //HomePage.linkMyAccount(driver).click();

    LoginPage.textBoxUserName(driver).sendKeys("testuser_1");

    LoginPage.textBoxPassword(driver).sendKeys("Test@123");

    LoginPage.buttonLogIn(driver).click();

    LOGGER.info(" Login Successfully, now it is the time to Log Off buddy.");

   // HomePage.linkLogOut(driver).click(); 

    driver.quit();

    }

}
