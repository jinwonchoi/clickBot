package com.bgt.automation.appModule;

import org.openqa.selenium.WebDriver;
import com.bgt.automation.pageObj.HomePage;
import com.bgt.automation.pageObj.LoginPage;

public class SignInAction {

	public SignInAction() {
		// TODO Auto-generated constructor stub
	}

	public static void Execute(WebDriver driver, String userId, String passwd){

	//	HomePage.linkMyAccount(driver).click(); 

		LoginPage.textBoxUserName(driver).sendKeys(userId);

		LoginPage.textBoxPassword(driver).sendKeys(passwd);

		LoginPage.buttonLogIn(driver).click();

	}
}
