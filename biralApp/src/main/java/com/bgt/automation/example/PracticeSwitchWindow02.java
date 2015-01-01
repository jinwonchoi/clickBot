package com.bgt.automation.example;

import java.util.Set;
import java.util.concurrent.TimeUnit;
 


import org.openqa.selenium.Alert;
 
import org.openqa.selenium.By;
 
import org.openqa.selenium.WebDriver;
 
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
 
public class PracticeSwitchWindow02 {
 
        public static WebDriver driver;
 
        public static void main(String[] args) {
 
            // Create a new instance of the Firefox driver
 
            //driver = new FirefoxDriver();
        	System.setProperty("webdriver.chrome.driver", "F:\\java\\selenium\\selenium-2.43.1\\chromedriver.exe");
        	driver = new ChromeDriver();
 
            // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
 
            driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
 
            // Launch the URL
 
            driver.get("http://www.toolsqa.com/automation-practice-switch-windows/");
 
            // Click on the Button "Alert Box"
 
            //driver.findElement(By.name("Alert Box")).click();
            driver.findElement(By.id("alert")).click();
 
            // Switch to JavaScript Alert window
 
            Alert myAlert = driver.switchTo().alert();
 
            // Accept the Alert
 
            myAlert.accept();
            System.out.println("Alert Accepted");
            // Close Original window
 
            //driver.close();
 
    }
 
}