using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Applitools.Selenium;
using NUnit.Framework;

namespace ApplitoolsCBTestingHackathon
{
    public class ModernTestsV2 : TestBaseModern
    {
        //Task 1
        [Test]
        public void Verify_Cross_Device_Elements_Test()
        {
            SetUp(BrowsersSettings.Version2Url);
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 1", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));
            _eyes.CloseAsync();
        }

        //Task 2
        [Test]
        public void Verify_Shopping_Experience()
        {
            SetUp(BrowsersSettings.Version2Url);
            applicationPage.SelectFilterByType("colors", "Black ");
            applicationPage.ClickOnFilterButton();
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 2", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Shopping Experience Test"));
            _eyes.CloseAsync();
        }

        //Task 3
        [Test]
        public void Verify_Product_Details()
        {
            SetUp(BrowsersSettings.Version2Url);
            applicationPage.SelectFilterByType("colors", "Black ");
            applicationPage.ClickOnFilterButton();
            applicationPage.ClickOnProductByName("Appli Air x Night");
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 3", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Product Details Test"));
            _eyes.CloseAsync();
        }
    }
}
