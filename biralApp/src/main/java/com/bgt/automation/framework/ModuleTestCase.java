package com.bgt.automation.framework;

import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import com.bgt.automation.appModule.SignInAction;
import com.bgt.automation.pageObj.HomePage;
import com.bgt.automation.util.CommonConst;

public class ModuleTestCase {

	static Logger LOGGER = Logger.getLogger(ModuleTestCase.class);
	private static WebDriver driver = null;

	public ModuleTestCase() {
		// TODO Auto-generated constructor stub
	}

	public static void main(String[] args) {

		driver = new FirefoxDriver();

		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		driver.get("http://www.store.demoqa.com");
		
		SignInAction.Execute(driver, "usr", "paswd");

		LOGGER.info("Login Successfully, now it is the time to Log Off buddy.");

		//HomePage.linkLogOut(driver).click();

		driver.quit();

	}

}
