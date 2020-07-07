using System;
using System.Collections.Generic;
using System.Text;
using ApplitoolsCBTestingHackathon.PageObjects;
using ApplitoolsCBTestingHackathon.PageServices;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace ApplitoolsCBTestingHackathon
{
    [TestFixture]
    public class TraditionalTestsV1 : TestBase
    {
        //Task 1
        [Test]
        [TestCaseSource(typeof(TestBase),"BrowsersToRunWith")]
        public void Verify_Cross_Device_Elements_Test(string browserName)
        {
            Setup(BrowsersSettings.Version1Url,browserName);
            Assert.Multiple(() =>
            {
                Assert.True(HackathonReport(1, "Search field is displayed", browserName, _v1Page.IsSearchBarPresent()));
                Assert.True(HackathonReport(1, "Search icon is displayed", browserName, _v1Page.IsSearchIconPresent()));
                Assert.True(HackathonReport(1, "Applifashion logo is displayed", browserName, _v1Page.IsAppLogoPresent()));
                Assert.True(HackathonReport(1, "Menu is displayed", browserName, _v1Page.IsAppMenuPresent()));
                Assert.True(HackathonReport(1, "Filters are displayed", browserName, _v1Page.IsFilterOptionsPresent()));
                Assert.True(HackathonReport(1, "Profile icon is displayed", browserName, _v1Page.IsProfileIconPresent()));
                Assert.True(HackathonReport(1, "Wishlist icon is displayed", browserName, _v1Page.IsWishListIconPresent()));
                Assert.True(HackathonReport(1, "Cart icon is displayed", browserName, _v1Page.IsCartIconPresent()));
                Assert.True(HackathonReport(1, "Quick links are displayed on footer", browserName, _v1Page.IsQuickLinksPresent()));
                Assert.True(HackathonReport(1, "Contacts are displayed on footer", browserName, _v1Page.IsContactsInfoPresent()));
                Assert.True(HackathonReport(1, "Keep in touch form is displayed on footer", browserName, _v1Page.IsKeepInTouchFormPresent()));
                Assert.True(HackathonReport(1, "Language selection dropdown is displayed on footer", browserName, _v1Page.IsLanguageSelectionPresent()));
                Assert.True(HackathonReport(1, "Currency dropdown is displayed on footer", browserName, _v1Page.IsCurrencyDropdownPresent()));
                Assert.True(HackathonReport(1, "Terms and conditions link is displayed on footer", browserName, _v1Page.IsTermsAndConditionLinkPresent()));
                Assert.True(HackathonReport(1, "Privacy link is displayed on footer", browserName, _v1Page.IsPrivacyLinkPresent()));
                Assert.True(HackathonReport(1, "Applitools copyright information is displayed on footer", browserName, _v1Page.IsCopyRightInfoPresent()));
                Assert.True(HackathonReport(1, "Sorting option is displayed", browserName, _v1Page.IsSortingOptionPresent()));
                Assert.True(HackathonReport(1, "Products arrangement option is displayed", browserName, _v1Page.IsProductArrangementOptionsPresent()));
                Assert.True(HackathonReport(1, "Products in grid are displayed", browserName, _v1Page.IsProductsGridPresent()));

            });
        }

        //Task 2
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void Verify_Shopping_Experience(string browserName)
        {
            Setup(BrowsersSettings.Version1Url,browserName);

            //Filters are hidden for Tablet and Mobile Device hence filter icon must be clicked before applying the filters
            if (browserName.Equals("chrome2")||browserName.Equals("firefox2")||browserName.Equals("edge2")||browserName.Equals("mobilePortrait"))
            {
                _v1Page.ClickOnFilterIcon();
            }
            _v1Page.SelectFilterByType("colors","Black ");
            _v1Page.ClickOnFilterButton();
            Assert.True(HackathonReport(2, "Correct Products Displayed When Filter Is Applied ?", browserName,
                    (_v1Page.GetSearchResultCount() == 2)));
        }

        //Task 3
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void Verify_Product_Details(string browserName)
        {
            Setup(BrowsersSettings.Version1Url, browserName);
            var productInformation = new Dictionary<string,string>()
            {
                {"Name","Appli Air x Night"},
                {"NewPrice","$33.00" },
                {"OldPrice","$48.00" },
                {"Discount","-30% discount"},
                {"Color","Black "}

            };
            if (browserName.Equals("chrome2") || browserName.Equals("firefox2") || browserName.Equals("edge2") || browserName.Equals("mobilePortrait"))
            {
                _v1Page.ClickOnFilterIcon();
            }
            _v1Page.SelectFilterByType("colors", "Black ");
            _v1Page.ClickOnProductByName(productInformation["Name"]);
            Assert.Multiple(() =>
            {
                Assert.True(HackathonReport(3, "Navigation To Default Page", browserName,
                    (_v1Page.GetPageHeader().Equals(productInformation["Name"]))));
                Assert.True(HackathonReport(3, "Verify Image Is Displayed", browserName,
                    _v1Page.IsImagePresentInDetailsPage()));
                Assert.True(HackathonReport(3, "Is Product Rating Present ?", browserName,
                    _v1Page.IsProductRatingPresent()));
                Assert.True(HackathonReport(3, "Is Product Description Present ?", browserName,
                    _v1Page.IsProductDescriptionPresent()));
                Assert.True(HackathonReport(3, "Is Size Selection Dropdown Present ?", browserName,
                    _v1Page.IsSizeSelectorDropdownPresent()));
                Assert.True(HackathonReport(3, "Is Quantity Selection Dropdown Present ?", browserName,
                    _v1Page.IsQuantitySelectorDropdownPresent()));
                Assert.True(HackathonReport(3, "Correct New Price Is Displayed", browserName,
                    (_v1Page.GetProductPriceNew().Equals(productInformation["NewPrice"]))));
                Assert.True(HackathonReport(3, "Correct Old Price Is Displayed", browserName,
                    (_v1Page.GetProductPriceOld().Equals(productInformation["OldPrice"]))));
                Assert.True(HackathonReport(3, "Correct Discount Is Displayed", browserName,
                    (_v1Page.GetProductDiscount().Equals(productInformation["Discount"]))));
                Assert.True(HackathonReport(3, "Is Add To Cart Button Present ?", browserName,
                    _v1Page.IsAddToCartButtonPresent()));
            });
        }
    }
}
