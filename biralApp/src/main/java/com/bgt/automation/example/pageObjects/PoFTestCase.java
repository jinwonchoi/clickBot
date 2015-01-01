package com.bgt.automation.example.pageObjects;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;

import org.openqa.selenium.firefox.FirefoxDriver;

import org.openqa.selenium.support.PageFactory;


import org.testng.annotations.Test;
 
import org.testng.annotations.BeforeMethod;
 
import org.testng.annotations.AfterMethod;


public class PoFTestCase {

	public PoFTestCase() {
		// TODO Auto-generated constructor stub
	}

    static WebDriver driver;
    HomePGPoF HomePage;
    LogInPGPoF LoginPage;
    
    @BeforeMethod
    
    public void beforeMethod() {
   
         driver = new FirefoxDriver();

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        driver.get("http://www.store.demoqa.com");

        // This is to Instantiate Home Page and LogIn Page class  

        HomePage = PageFactory.initElements(driver, HomePGPoF.class);

        LoginPage = PageFactory.initElements(driver, LogInPGPoF.class);
    }
    
    @Test
   
    public void test() {
        // Once both classes Initialised, use their Web Element Objects

        HomePage.lnk_MyAccount.click();

        //LoginPage.txtbx_UserName.sendKeys("testuser_1");

        //LoginPage.txtbx_Password.sendKeys("Test@123");
        LoginPage.LogIn_Action("testuser_1", "Test@123");
        
        LoginPage.btn_Login.click();

        System.out.println(" Login Successfully, now it is the time to Log Off buddy.");

        HomePage.lnk_LogOut.click();
    }
    
    @AfterMethod
   
    public void afterMethod() {
   
        driver.quit();

    }
}
