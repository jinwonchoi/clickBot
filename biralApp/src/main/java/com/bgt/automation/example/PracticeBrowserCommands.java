package com.bgt.automation.example;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;

import org.openqa.selenium.firefox.FirefoxDriver;

public class PracticeBrowserCommands {

	private static WebDriver driver = null;

	public static void main(String[] args) throws InterruptedException {

		 // Create a new instance of the Firefox driver

        driver = new FirefoxDriver();

        //Put a Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        //Launch the ToolsQA Website

        driver.get("http://www.toolsqa.com");

		// Storing Title name in String variable

        String sTitle = driver.getTitle();

		// Storing Title length in Int variable

        int iTitleLength = driver.getTitle().length();

		// Printing Title name on Console

        System.out.println(sTitle);

		// Printing Title length on console

        System.out.println(iTitleLength);

		// Storing URL in String variable

        sTitle = driver.getCurrentUrl();

		// Storing URL length in Int variable

        iTitleLength = driver.getCurrentUrl().length();

		// Printing URL on Console

        System.out.println(sTitle);

		// Printing URL length on console

        System.out.println(iTitleLength);

		// Refreshing current page

        driver.get(driver.getCurrentUrl());  

		// Storing Page Source in String variable

        String sPageSource = driver.getPageSource();

		// Storing Page Source length in Int variable

        int iPageSourceLength = driver.getPageSource().length();

		// Printing Page Source on console

        System.out.println(sPageSource);

		// Printing Page SOurce length on console

        System.out.println(iPageSourceLength);

		//Closing browser

        driver.close();

	}

}