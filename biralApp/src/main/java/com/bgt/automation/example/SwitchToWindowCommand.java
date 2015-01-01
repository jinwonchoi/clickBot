package com.bgt.automation.example;

import java.util.Set;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public class SwitchToWindowCommand {

	private static WebDriver driver = null;
	
	public SwitchToWindowCommand() {
		// TODO Auto-generated constructor stub
	}

	public void waitForNumberofWindowsToEqual(int numOfWindows) {
	
		Set<String> handles = driver.getWindowHandles();
		while (numOfWindows >= handles.size()) {
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
	
	public static void main(String[] args) {
		
		
		driver = new ChromeDriver();
		driver.findElement(By.id("id of the link which opens new window")).click();

		 //wait till two windows are not opened

	/*	 waitForNumberofWindowsToEqual(2);//this method is for wait
		 

		 Set handles = driver.getWindowHandles();

		 firstWinHandle = driver.getWindowHandle(); handles.remove(firstWinHandle);

		 String winHandle=handles.iterator().next();

		 if (winHandle!=firstWinHandle){

		 //To retrieve the handle of second window, extracting the handle which does not match to first window handle

		 secondWinHandle=winHandle; //Storing handle of second window handle

		//Switch control to new window

		 driver.switchTo().window(secondWinHandle);*/
	}
}
