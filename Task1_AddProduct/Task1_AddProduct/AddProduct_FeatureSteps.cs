using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Task1_AddProduct
{
    [Binding]
    public class AddProduct_FeatureSteps
    {
        //Creating reference for chrome browser
        IWebDriver driver = new ChromeDriver();

        [Given(@"Login to Unleashed and Navigate to Add Product page")]
        public void GivenLoginToUnleashedAndNavigateToAddProductPage()
        {
            //Navigating to Unleashed webpage
            driver.Navigate().GoToUrl("https://go.unleashedsoftware.com/v2");

            //Sending values for username and password fields
            driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("qa+applicant@unleashedsoftware.com");
            driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("P@ssw0rd12345");

            //Clicking LogOn button
            driver.FindElement(By.XPath(".//*[@id='btnLogOn']")).Click();
            driver.FindElement(By.XPath(".//*[@id='shortcuts']/div[1]/i")).Click();
            driver.FindElement(By.XPath(".//*[@id='shortcuts']/div[2]/div[3]/a/div[2]")).Click();

        }

        [Given(@"Give values to new product and add it")]
        public void GivenGiveValuesToNewProductAndAddIt()
        {
            string product = "T0012";
            //Giving product details
            driver.FindElement(By.XPath(".//*[@id='Product_ProductCode']")).SendKeys(product);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(".//*[@id='Product_ProductDescription']")).SendKeys("Test Product - Cosmetics");

            //Saving product
            driver.FindElement(By.XPath(".//*[@id='btnSave']")).Click();

            Thread.Sleep(2000);
            //Verifying if product added successfully or not
            string verify = driver.FindElement(By.XPath(".//*[@id='messageBoxContent']")).Text;
            if (verify == "You have updated the product successfully.")
            {
                Console.WriteLine("Adding Product - successful");
            }
            else
            {
                Console.WriteLine("Adding Product - unsuccessful");
            }
        }
        
        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            Thread.Sleep(1000);
            driver.Close();

        }
    }
}
