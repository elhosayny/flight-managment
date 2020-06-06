using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightManagement.UITest
{
    public class FlightPageTests
    {
        [Fact]
        [Trait("Category","Smoke")]
        public void LoadApplicationPage()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://localhost:44368/Airplanes/Create");
            }
        }
    }
}
