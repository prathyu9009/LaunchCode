using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace LaunchIT
{
    class Program
    {
        static void Main(string[] args)
        {
            string chromeDriverPath = @"C:\Program Files\Google\Chrome";
            string url = "https://www.launchconsulting.com/";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Console.WriteLine("Web page opened in Chrome successfully.");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement Career;
            Career = driver.FindElement(By.XPath("//*[text()='About Us'][1]"));
            if (Career.Displayed)
            {
                Console.WriteLine("Click on careers");
                Career.Click();
                string expectedtext = "Be you, with us";
                IWebElement actualtext;
                //IWebElement expectedtext;
                actualtext = driver.FindElement(By.XPath("//*[text()='Be you, with us']"));
                String Value = actualtext.Text;
                if (Value == expectedtext)
                {
                    Console.WriteLine("matched");
                    IWebElement openroles = driver.FindElement(By.XPath("//*[text()='See open Roles']"));
                    openroles.Click();
                    IWebElement logo = driver.FindElement(By.XPath("//*[@class=\"hmgjb-mobile-logo-wrapper\"]"));
                    if(!logo.Displayed)
                    {
                        Console.WriteLine("Launch logo is not displayed");
                    }
                    else
                    {
                        Console.WriteLine("logo is there");
                        IWebElement jobtitle = driver.FindElement(By.XPath("//*[@id=\"keywords\"]"));
                        jobtitle.SendKeys("Technology Leader");
                        IWebElement City = driver.FindElement(By.XPath("//*[@id=\"location-quicksearch\"]"));
                        City.SendKeys("Hyderbad");
                        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy({ down: 1000, behavior: 'smooth' });");
                        IWebElement ApplyFilters = driver.FindElement(By.XPath("//*[@id=\"searchFormButton\"]"));
                    }


                }
                else
                {
                    Console.WriteLine("matched");
                }
            }
            else
                Console.WriteLine("Careers link is not displayed");

            


            System.Threading.Thread.Sleep(5000); 
            driver.Quit();
        }
    }
}