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
            string Price = "£29";
            var ProductPrice = driver.FindElement(By.ClassName("search-product-price"));
            AssertLibrary.Assert.IsEqual(ProductPrice.Text, Price);
            Thread.Sleep(3000);


            //Click on 1st Product in listing
            IWebElement ProductName = driver.FindElement(By.ClassName("search-product-name"));
            ProductName.Click();


            //Wait for product page to load and click Buy
            Thread.Sleep(3000);
            IWebElement BuyNowBtn = driver.FindElement(By.CssSelector("#product-form > div > button"));
            Thread.Sleep(3000);
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


            //Enter Email address and continue as guest
            IWebElement EnterEmail = driver.FindElement(By.CssSelector("#account_email_field"));
            EnterEmail.SendKeys("mark@mail.com");
            IWebElement ContinueAsGuest = driver.FindElement(By.CssSelector("#checkout_capture > div.step1_btns.col-lg-offset-4 > button.btn.login_guest.chk_btns"));
            ContinueAsGuest.Click();


            //Enter customer details
            IWebElement Title = driver.FindElement(By.Name("Salutation"));
            Title.Click();
            IWebElement TitleOptions = driver.FindElement(By.CssSelector("#titlefield > option:nth-child(2)"));
            TitleOptions.Click();
            IWebElement FName = driver.FindElement(By.CssSelector("#firstnamefield"));
            FName.SendKeys("TestFirstName");
            IWebElement LName = driver.FindElement(By.CssSelector("#lastnamefield"));
            LName.SendKeys("TestLastName");
            IWebElement ContinueBtn = driver.FindElement(By.CssSelector("#guest_personal_details > div.form-group.external_links > button"));
            ContinueBtn.Click();


            //Enter Billing and Payment details
            IWebElement PostCode = driver.FindElement(By.CssSelector("#billingPostcode"));
            PostCode.SendKeys("E1 6AN");
            IWebElement SearchBtn = driver.FindElement(By.CssSelector("##postCodeSearchBilling > div > div.form-group.postcodesearch > div.continue_area_buttons.col-sm-2 > button"));
            SearchBtn.Click();
            IWebElement ChooseAddress = driver.FindElement(By.CssSelector("#new_card_selectaddress > ul > li.row.newcard_newaddress.subpanel-inner > div > div > div > div > div.form-group.postcodesearchlist > div.col-xs-12.col-sm-8.nopadding.highlighted-field-onload.highlighted-field-fadedaway > select"));
            ChooseAddress.Click();








            driver.Quit();




        }

    }

}
