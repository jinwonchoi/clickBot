package com.bgt.automation.example;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;

public class ScrollElement {

	public ScrollElement() {
		// TODO Auto-generated constructor stub
	}
    public static void main(String[] args) throws Exception {
    	 
        // TODO Auto-generated method stub        
 
        FirefoxDriver ff = new FirefoxDriver();
 
        ff.get("http://toolsqa.com");
 
        Thread.sleep(5000);
 
        //ff.executeScript("document.getElementById('text-8').scrollIntoView(false);");
 
        WebElement targetElement = ff.findElementById("text-8");
 
        int x = 0;
 
        while((Double) ff.executeScript("return document.getElementById('text-8').getBoundingClientRect().top") > 0 )
 
        {
 
            x = x + 2;
 
            ff.executeScript("window.scrollByLines(2)");
 
            System.out.println("Client top is = " + (Double) ff.executeScript("return document.getElementById('text-8').getBoundingClientRect().top"));            
 
        }
 
        System.out.println("Element is visible after  " + x + " scrolls");
 
    }
 
}
