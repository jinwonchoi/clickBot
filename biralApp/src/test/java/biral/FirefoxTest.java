package biral;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;

public class FirefoxTest {

	@Before
	public void setUp() throws Exception {
	}

	@Test
	public void testScroll() {
			  
		        // TODO Auto-generated method stub        
		 
		        FirefoxDriver ff = new FirefoxDriver();
		 
		        ff.get("http://www.naver.com");
		 
		        try {
					Thread.sleep(5000);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
		 
	            WebElement searchBox = ff.findElement(By.name("query"));
		        try {
		        	//CharSequence charSeq = "우리들".subSequence(beginIndex, endIndex);
		            searchBox.sendKeys("우리들");
					Thread.sleep(1000);
		            searchBox.sendKeys("ㅜ");
					Thread.sleep(1000);
		            searchBox.sendKeys("ㅈ");
					Thread.sleep(1000);
		            searchBox.sendKeys("ㅠ");
					Thread.sleep(1000);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

		        
		        //ff.executeScript("document.getElementById('text-8').scrollIntoView(false);");
		 
		        //WebElement targetElement = ff.findElementById("container");
		 
		        int x = 0;
		 
		        //while((Long) ff.executeScript("return document.getElementById('body').getBoundingClientRect().top") > 0)
		        while((Long) ff.executeScript("return document.getElementById('container').getBoundingClientRect().bottom") > 0)
		        {
		 
		            x = x + 2;
		 
		            ff.executeScript("window.scrollByLines(2)");
		 
		            //System.out.println("Client top is = " + (Long) ff.executeScript("return document.getElementById('body').getBoundingClientRect().top"));            
		            System.out.println("Client bottom is = " + (Long) ff.executeScript("return document.getElementById('container').getBoundingClientRect().bottom"));            
		 
		        }
		 
		        System.out.println("Element is visible after  " + x + " scrolls");
		 
	}

}
