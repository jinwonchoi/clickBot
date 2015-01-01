package com.bgt.automation.example;

import java.util.List;

import java.util.concurrent.TimeUnit;
 
import org.openqa.selenium.By;
 
import org.openqa.selenium.WebDriver;
 
import org.openqa.selenium.WebElement;
 
import org.openqa.selenium.firefox.FirefoxDriver;
 
public class PracticeCheckBox {
 
        private static WebDriver driver = null;
 
    public static void main(String[] args) {
 
        // Create a new instance of the Firefox driver
 
        driver = new FirefoxDriver();
 
        // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
 
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
 
        // Launch the URL
 
        driver.get("http://www.toolsqa.com/automation-practice-form");
 
        // Step 3 : Select the deselected Radio button (female) for category Sex (Use IsSelected method)
 
        // Storing all the elements under category 'Sex' in the list of WebLements    
 
        List<WebElement> rdBtn_Sex = driver.findElements(By.name("sex"));
 
        // Create a boolean variable which will hold the value (True/False)
 
         boolean bValue = false;
 
         // This statement will return True, in case of first Radio button is selected
 
         bValue = rdBtn_Sex.get(0).isSelected();
 
         // This will check that if the bValue is True means if the first radio button is selected
 
         if(bValue = true){
 
             // This will select Second radio button, if the first radio button is selected by default
 
             rdBtn_Sex.get(1).click();
 
         }else{
 
             // If the first radio button is not selected by default, the first will be selected
 
             rdBtn_Sex.get(0).click();
 
         }
 
         //Step 4: Select the Third radio button for category 'Years of Exp' (Use Id attribute to select Radio button)
 
         WebElement rdBtn_Exp = driver.findElement(By.id("exp-2"));
 
         rdBtn_Exp.click();
 
         // STep 5: Check the checkbox 'Automation Tester' for category 'Profession'( Use Value attribute to match the selection)
 
         // Find the checkbox or radio button element by Name
 
         List<WebElement> chkBx_Profession = driver.findElements(By.name("profession"));
 
         // This will tell you the number of checkboxes are present
 
         int iSize = chkBx_Profession.size();
 
         // Start the loop from first checkbox to last checkboxe
 
         for(int i=0; i < iSize ; i++ ){
 
             // Store the checkbox name to the string variable, using 'Value' attribute
 
             String sValue = chkBx_Profession.get(i).getAttribute("value");
 
             // Select the checkbox it the value of the checkbox is same what you are looking for
 
             if (sValue.equalsIgnoreCase("Automation Tester")){
 
                 chkBx_Profession.get(i).click();
 
                 // This will take the execution out of for loop
 
                 break;
 
                }
 
            }
 
         // Step 6: Check the checkbox 'Selenium IDE' for category 'Automation Tool' (Use cssSelector)
 
         WebElement oCheckBox = driver.findElement(By.cssSelector("input[value='Selenium IDE']"));
 
         oCheckBox.click();
 
         // Kill the browser
 
         //driver.close();
 
    }
 
}