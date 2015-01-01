package com.bgt.automation.pageObj;

import org.apache.log4j.Logger;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.framework.ServiceElement;
import com.bgt.automation.framework.pattern.TypingCmd;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class LoginPopUpPage extends BasePage {

	static Logger Log = Logger.getLogger(LoginPopUpPage.class);
	WebElement inputUserId;
	WebElement inputPwd;
	WebElement buttonLogin;
	
	public LoginPopUpPage(WebDriver driver, ServiceElement serviceElement,ActionItem item) throws Exception{
		super(driver, serviceElement, item);
		//get focus
		this.goLastTab();
		inputUserId = serviceElement.popupLoginId();
		inputPwd = serviceElement.popupLoginPwd();
		buttonLogin = serviceElement.popupLoginButton();
	}
	
	public void getFocus() {
		try {
			this.goLastTab();
		} catch (Exception e) {
			Log.error(e);
		}
	}
	
	public boolean clickLogin() {
		boolean result = true;
		
		try {
			Utils.waitRandomTime();
			TypingCmd.execute(inputUserId, item.getLoginId());
			Utils.waitRandomTime();
			TypingCmd.execute(inputPwd, item.getLoginpwd());
			Utils.waitRandomTime();
			buttonLogin.click();
		} catch (NoSuchElementException ex) { 
			Log.error("popup login failed.",ex);
			result = false;
		}
		return result;
	}
}
