package com.bgt.automation.example;

import java.util.concurrent.TimeUnit;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public class PracticeWebElementCommands02 {

	public static WebDriver driver;

	public static void main(String[] args) {

		 // Create a new instance of the Firefox driver

        driver = new FirefoxDriver();

        // Put a Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        // Launch the Online Store Website

        driver.get("http://www.toolsqa.com/Automation-practice-form/");

        // Click on "Partial Link Text" link

        driver.findElement(By.partialLinkText("Partial Link Test")).click();

        System.out.println("Partial Link Test Pass");

        // Convert element in to a string 

        String sClass = driver.findElements(By.tagName("button")).toString();

        System.out.println(sClass);

        // Click on "Link Text" link

        driver.findElement(By.linkText("Link Test")).click();

        System.out.println("Link Test Pass");

        	}

}
