package com.bgt.automation.pageObj;

import org.apache.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.bgt.automation.util.Utils;

public class HomePage  extends BasePage{
	static Logger LOGGER = Logger.getLogger(HomePage.class);
	private WebElement element = null;

	public HomePage(WebDriver driver){

		super(driver);

	}    

	public WebElement linkMyAccount(WebDriver driver){

		try{ 

			element = driver.findElement(By.xpath(".//*[@id='account']/a"));

			LOGGER.info("My Account link is found on the Home Page");

		}catch (Exception e){

			LOGGER.error("My Acocunt link is not found on the Home Page");

			throw(e);

		}

		return element;

	}

	public WebElement linkLogOut(WebDriver driver){

		try{

			element = driver.findElement(By.id("account_logout"));

			LOGGER.info("Log Out link is found on the Home Page");

		}catch (Exception e){

			LOGGER.error("Log Out link is not found on the Home Page");

			throw(e);

		}

		return element;

	}

	public  class TopNavigation{

		public  class Product_Type{

			WebElement mainElement;

			public void Accessories() throws Exception{

				try{

					mainElement = driver.findElement(By.linkText("Product Category"));

					LOGGER.info("Product category link is found under Top Navigation");

					Utils.mouseHoverAction(driver, mainElement, "Accessories");

				}catch (Exception e){

					LOGGER.error("Accessories link is not found under Product Category");

					throw(e);

				}

			}

			public  void iMacs() throws Exception{

				try{

					mainElement = driver.findElement(By.linkText("Product Category"));

					LOGGER.info("Product category link is found under Top Navigation");

					Utils.mouseHoverAction(driver, mainElement, "iMacs");

				}catch (Exception e){

					LOGGER.error("Accessories link is not found under Product Category");

					throw(e);

				}

			}

			public  void iPads() throws Exception{

				try{

					mainElement = driver.findElement(By.linkText("Product Category"));

					LOGGER.info("Product category link is found under Top Navigation");

					Utils.mouseHoverAction(driver, mainElement, "iPads");

				}catch (Exception e){

					LOGGER.error("Accessories link is not found under Product Category");

					throw(e);

				}

			}

			public  void iPhones() throws Exception{

				try{

					mainElement = driver.findElement(By.linkText("Product Category"));

					LOGGER.info("Product category link is found under Top Navigation");

					Utils.mouseHoverAction(driver, mainElement, "iPhones");

				}catch (Exception e){

					LOGGER.error("Accessories link is not found under Product Category");

					throw(e);

				}

			}

		}

	}
}
