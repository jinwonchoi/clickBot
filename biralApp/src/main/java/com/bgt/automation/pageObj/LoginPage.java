package com.bgt.automation.pageObj;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class LoginPage extends BasePage {

	static Logger Log = Logger.getLogger(LoginPage.class);
	private static WebElement element = null;

	public LoginPage(WebDriver driver){

		super(driver);

	}     

	public static WebElement textBoxUserName(WebDriver driver){

		try{

			element = driver.findElement(By.id("log"));

			Log.info("Username text box is found on the Login Page");

		}catch (Exception e){

			Log.error("UserName text box is not found on the Login Page");

			throw(e);

		}

		return element;

	}

	public static WebElement textBoxPassword(WebDriver driver){

		try{

			element = driver.findElement(By.id("pwd"));

			Log.info("Password text box is found on the Login page");

		}catch (Exception e){

			Log.error("Password text box is not found on the Login Page");

			throw(e);

		}

		return element;

	}

	public static WebElement buttonLogIn(WebDriver driver){

		try{

			element = driver.findElement(By.id("login"));

			Log.info("Submit button is found on the Login page");

		}catch (Exception e){

			Log.error("Submit button is not found on the Login Page");

			throw(e);

		}

		return element;

	}
}
