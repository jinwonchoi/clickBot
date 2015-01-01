import java.util.Set;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;


public class OpenGoogle {

	public OpenGoogle() {
		// TODO Auto-generated constructor stub
	}

	public static void main(String [] arg)
	{

		System.setProperty("webdriver.chrome.driver", "C:\\SelenuimProject\\chromedriver2.8.exe");
		WebDriver driver =  new ChromeDriver();



		try{
			driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
			driver.manage().timeouts().pageLoadTimeout(50,TimeUnit.SECONDS);
			//driver.navigate().to("http://www.google.com");

			//Please enter your web url here
			driver.get("http://www.xyz.com/");

			String mainHandle = driver.getWindowHandle();

			driver.findElement(By.linkText("Open New Window")).click();

			//wait while ( driver.getWindowHandles().size() == 1 );


			Set<String> HandleSet = driver.getWindowHandles();
			//Switching to the popup window.

			for ( String handle : HandleSet )
			{
				if(!handle.equals(mainHandle))
				{
					//Switch to newly created window
					driver.switchTo().window(handle);
				}
			}



		}

		catch(Exception e){
			System.out.println("Exception - > " + e.toString());
		}
		finally{
			driver.close();
			driver.quit();
		}
	}      //main function ends

}
