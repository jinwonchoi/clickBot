package com.bgt.automation.example;

import java.util.List;

import java.util.concurrent.TimeUnit;
 
import org.openqa.selenium.By;
 
import org.openqa.selenium.WebDriver;
 
import org.openqa.selenium.WebElement;
 
import org.openqa.selenium.firefox.FirefoxDriver;
 
import org.openqa.selenium.support.ui.Select;
 
public class PracticeDropDown {
 
    private static WebDriver driver = null;
 
    public static void main(String[] args) throws InterruptedException {
 
     // Create a new instance of the Firefox driver
 
        driver = new FirefoxDriver();
 
        // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
 
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
 
        // Launch the URL
 
        driver.get("http://www.toolsqa.com/automation-practice-form");
 
        // Step 3: Select 'Continents' Drop down ( Use Id to identify the element )
 
        // Find Select element of "Single selection" using ID locator.
 
        Select oSelection = new Select(driver.findElement(By.id("continents")));
 
        // Step 4:) Select option 'Europe' (Use selectByIndex)
 
        oSelection.selectByVisibleText("Europe");
 
        // Using sleep command so that changes can be noticed
 
        Thread.sleep(2000);
 
        // Step 5: Select option 'Africa' now (Use selectByVisibleText)
 
        oSelection.selectByIndex(2);
 
        Thread.sleep(2000);
 
        // Step 6: Print all the options for the selected drop down and select one option of your choice
 
        // Get the size of the Select element
 
        List<WebElement> oSize = oSelection.getOptions();
 
        int iListSize = oSize.size();
 
        // Setting up the loop to print all the options
 
        for(int i =0; i < iListSize ; i++){
 
            // Storing the value of the option    
 
            String sValue = oSelection.getOptions().get(i).getText();
 
            // Printing the stored value
 
            System.out.println(sValue);
 
            // Putting a check on each option that if any of the option is equal to 'Africa" then select it 
 
            if(sValue.equals("Africa")){
 
                oSelection.selectByIndex(i); 
                break;
                 }
             }        
 
        // Kill the browser
        //driver.close();
    }
}