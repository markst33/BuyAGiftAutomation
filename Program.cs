using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BuyAGiftAutomation
{
    class MainClass

    {
        static IWebDriver driver = new ChromeDriver();
       

        
        public static void Main()

        {
            //Navigate to Homepage
            string url = "https://www.buyagift.co.uk/";
            driver.Navigate().GoToUrl(url);

            
            //Find Searchbar and enter text
            IWebElement Searchbar = driver.FindElement(By.ClassName("form-control"));
            Searchbar.SendKeys("dinner for 2");
            Thread.Sleep(3000);

            
            //Compare Expected Price with Actual Price
            string Price = "£28";
            var ProductPrice = driver.FindElement(By.ClassName("search-product-price"));
            AssertLibrary.Assert.IsEqual(ProductPrice.Text, Price);
            Thread.Sleep(5000);


            //Click on 1st Product in listing
            IWebElement ProductName = driver.FindElement(By.ClassName("search-product-name"));
            ProductName.Click();


            //Wait for product page to load and click Buy
            Thread.Sleep(5000);
            IWebElement BuyNowBtn = driver.FindElement(By.CssSelector("#product-form > div > button"));
            BuyNowBtn.Click();


            //Click on Basket and ensure its not empty
            IWebElement Basket = driver.FindElement(By.CssSelector("#basket-left"));
            Basket.Click();
            Thread.Sleep(2000);


            //Enter personalised message and select eVoucher
            IWebElement TextBox = driver.FindElement(By.CssSelector("#basket_contents > div > form > div > div > div.row.additional_details > div.basket_step.col-sm-6.step2.ng-scope > div > textarea"));
            TextBox.SendKeys("This is a test to enter a message");
            IWebElement eVoucher = driver.FindElement(By.CssSelector("#basket_contents > div > form > div > div > div.row.additional_details > div.basket_step.col-sm-6.step1 > div > div:nth-child(3) > label > input[type=radio]"));
            eVoucher.Click();
            Thread.Sleep(3000);


            //Check that No delivery price has been added and the correct Price is retained
            var TotalCost = driver.FindElement(By.CssSelector("#basket_summary > div > div.animate-fadeIn.ng-scope > div.holder.ng-scope > div > div.row.final_totals > span.cost_price.col-xs-4.ng-binding"));
            AssertLibrary.Assert.IsEqual(ProductPrice.Text, TotalCost.Text);


            //Click Pay Securely
            IWebElement PaySecurely = driver.FindElement(By.CssSelector("#basket_payment_options > a:nth-child(1) > button"));
            PaySecurely.Click();




            driver.Quit();




        }

    }

}
