package com.bgt.automation.example;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;

import org.openqa.selenium.WebDriver;

import org.openqa.selenium.firefox.FirefoxDriver;

public class PracticeNavigationCommands {

	private static WebDriver driver = null;

	public static void main(String[] args) {

		// Create a new instance of the Firefox driver

		driver = new FirefoxDriver();

		// Open ToolsQA website

		driver.get("http://www.toolsqa.com");

		// Put an Implicit wait on driver

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		// Click on About link

        driver.findElement(By.linkText("ABOUT")).click();

		// Go back to Home Page

		driver.navigate().back();

		// Go forward to About page

        driver.navigate().forward();

		// Go back to Home page

        driver.navigate().to("http://www.toolsqa.com");

		// Refresh browser

		driver.navigate().refresh();

		// Close browser

		driver.close();

	}

}