package com.bgt.automation.example;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;

import org.openqa.selenium.WebDriver;

import org.openqa.selenium.firefox.FirefoxDriver;

public class PracticeWebElementCommands01 {

	public static WebDriver driver;

	public static void main(String[] args) {

		 // Create a new instance of the Firefox driver

        driver = new FirefoxDriver();

        // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        // Launch the ToolsQA Website

        driver.get("http://www.toolsqa.com/Automation-practice-form/");

        // Type Name      

        driver.findElement(By.name("firstname")).sendKeys("Lakshay"); 

        //Type Last Name

        driver.findElement(By.name("lastname")).sendKeys("Sharma");

        // Click on Submit

        driver.findElement(By.id("submit")).click();

		}

	}