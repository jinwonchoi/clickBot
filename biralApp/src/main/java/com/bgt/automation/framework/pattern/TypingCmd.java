package com.bgt.automation.framework.pattern;

import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;

public class TypingCmd {

	public TypingCmd() {
	}

	public static void execute(WebElement el, String text) {
		el.sendKeys(text);
	}
}
