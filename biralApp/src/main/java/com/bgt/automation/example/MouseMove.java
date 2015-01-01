package com.bgt.automation.example;

import java.awt.AWTException;
import java.awt.Robot;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;

import org.openqa.selenium.*;
import org.openqa.selenium.firefox.FirefoxDriver;
 
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.interactions.HasInputDevices;
import org.openqa.selenium.interactions.Mouse;

public class MouseMove {

	public MouseMove() {
		// TODO Auto-generated constructor stub
	}
	
	public void dragAndDropElement(WebElement dragFrom, WebElement dragTo, int xOffset) throws Exception {
	    //Setup robot
	    Robot robot = new Robot();
	    robot.setAutoDelay(50);

	    //Fullscreen page so selenium coordinates are same as robot coordinates
	    //robot.keyPress(KeyEvent.VK_F11);
	    Thread.sleep(2000);

	    //Get size of elements
	    Dimension fromSize = dragFrom.getSize();
	    Dimension toSize = dragTo.getSize();

	    //Get centre distance
	    int xCentreFrom = fromSize.width / 2;
	    int yCentreFrom = fromSize.height / 2;
	    int xCentreTo = toSize.width / 2;
	    int yCentreTo = toSize.height / 2;

	    //Get x and y of WebElement to drag to
	    Point toLocation = dragTo.getLocation();
	    Point fromLocation = dragFrom.getLocation();

	    //Make Mouse coordinate centre of element and account for offset
	    toLocation.x += xOffset + xCentreTo;
	    toLocation.y += yCentreTo;
	    fromLocation.x += xCentreFrom;
	    fromLocation.y += yCentreFrom;

	    //Move mouse to drag from location
	    robot.mouseMove(fromLocation.x, fromLocation.y);

	    //Click and drag
	    robot.mousePress(InputEvent.BUTTON1_MASK);

	    //Drag events require more than one movement to register
	    //Just appearing at destination doesn't work so move halfway first
	    robot.mouseMove(((toLocation.x - fromLocation.x) / 2) + fromLocation.x, ((toLocation.y - fromLocation.y) / 2) + fromLocation.y);

	    //Move to final position
	    robot.mouseMove(toLocation.x, toLocation.y);

	    //Drop
	    robot.mouseRelease(InputEvent.BUTTON1_MASK);
	}
	
	public static void main(String[] args) throws Exception {
		String baseUrl = "http://newtours.demoaut.com/";
		        WebDriver driver = new FirefoxDriver();
		 
		        driver.get(baseUrl);           
		        WebElement link_Home = driver.findElement(By.linkText("Home"));
		        WebElement td_Home = driver
		                .findElement(By
		                .xpath("//html/body/div"
		                + "/table/tbody/tr/td"
		                + "/table/tbody/tr/td"
		                + "/table/tbody/tr/td"
		                + "/table/tbody/tr"));    
		         
		        Actions builder = new Actions(driver);
		        Action mouseOverHome = builder
		                //.moveByOffset(345, 543)
		        		.moveToElement(link_Home)
		                .build();
		         
		        String bgColor = td_Home.getCssValue("background-color");
		        System.out.println("Before hover: " + bgColor);        
		        mouseOverHome.perform();        
		        bgColor = td_Home.getCssValue("background-color");
		        System.out.println("After hover: " + bgColor);
		        

		        Point coordinates = link_Home.getLocation();
		        Robot robot = new Robot();
		        Mouse mouse = ((HasInputDevices) driver).getMouse();
		        robot.mouseMove(coordinates.getX(),coordinates.getY());
		         
		        
		       // driver.quit();
//		        MouseMove move = new MouseMove();
//		        move.dragAndDropElement(td_Home, link_Home, 3);
		}
}
