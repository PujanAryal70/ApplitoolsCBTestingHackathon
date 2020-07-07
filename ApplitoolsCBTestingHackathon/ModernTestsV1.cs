using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Applitools;
using Applitools.Selenium;
using ApplitoolsCBTestingHackathon.PageServices;
using NUnit.Framework;

namespace ApplitoolsCBTestingHackathon
{
    [TestFixture]
    public class ModernTestsV1 : TestBaseModern
    {
        //Task 1
        [Test]
        public void Verify_Cross_Device_Elements_Test()
        {
            SetUp(BrowsersSettings.Version1Url);
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 1", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));
            _eyes.CloseAsync();
        }

        //Task 2
        [Test]
        public void Verify_Shopping_Experience()
        {
            SetUp(BrowsersSettings.Version1Url);
            applicationPage.SelectFilterByType("colors", "Black ");
            applicationPage.ClickOnFilterButton();
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 2", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Filter Results"));
            _eyes.CloseAsync();
        }

        //Task 3
        [Test]
        public void Verify_Product_Details()
        {
            SetUp(BrowsersSettings.Version1Url);
            applicationPage.SelectFilterByType("colors", "Black ");
            applicationPage.ClickOnFilterButton();
            applicationPage.ClickOnProductByName("Appli Air x Night");
            _eyes.Open(SiteDriver._driver, "Applifashion", "Task 3", new Size(800, 600));
            _eyes.Check(Target.Window().Fully().WithName("Product Details test"));
            _eyes.CloseAsync();
        }
    }
}
