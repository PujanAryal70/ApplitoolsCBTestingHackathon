using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ApplitoolsCBTestingHackathon.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace ApplitoolsCBTestingHackathon.PageServices
{
    public class ApplicationPage
    {

        #region Methods

        public bool IsSearchBarPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.searchField, How.Id);
        }

        public bool IsSearchIconPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.searchIcon, How.Id);
        }

        public bool IsAppLogoPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.appLogo, How.Id);
        }

        public bool IsAppMenuPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.appMenu, How.Id);
        }

        public bool IsFilterOptionsPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.filterOptions, How.Id);
        }

        public bool IsProfileIconPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.profileIcon, How.Id);
        }

        public bool IsWishListIconPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.wishListIcon, How.Id);
        }

        public bool IsCartIconPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.cartIcon, How.Id);
        }

        public bool IsQuickLinksPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.quickLinksIcons, How.Id);
        }

        public bool IsContactsInfoPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.contactsInfo, How.Id);
        }

        public bool IsKeepInTouchFormPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.keepInTouchForm, How.Id);
        }

        public bool IsLanguageSelectionPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.languageSelection, How.Id);
        }

        public bool IsCurrencyDropdownPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.currencyDropdown, How.Id);
        }

        public bool IsTermsAndConditionLinkPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.termsAndConditionLink, How.Id);
        }

        public bool IsPrivacyLinkPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.privacyLink, How.Id);
        }

        public bool IsCopyRightInfoPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.copyrightInfo, How.Id);
        }

        public bool IsSortingOptionPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.sortingOption, How.Id);
        }

        public bool IsProductArrangementOptionsPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.productArrangementOption, How.Id);
        }

        public bool IsProductsGridPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.products, How.Id);
        }

        public void SelectFilterByType(string type, string option)
        {
            SiteDriver.FindElement(string.Format(ApplicationPageObjects.SelectFilterXpath,type,option),How.XPath).Click();
        }

        public void ClickOnFilterButton()
        {
            SiteDriver.FindElement(ApplicationPageObjects.FilterButton, How.Id).Click();

        }

        public int GetSearchResultCount()
        {
            return SiteDriver.FindElements(ApplicationPageObjects.GridItem, How.CssSelector).Count();
        }
        #endregion

        public void ClickOnProductByName(string productName)
        {
            SiteDriver.FindElement(string.Format(ApplicationPageObjects.ProductByName,productName), How.XPath).Click();
            Thread.Sleep(500);
        }

        public string GetPageHeader()
        {
            return SiteDriver.FindElement(ApplicationPageObjects.PageHeader, How.CssSelector).Text;
        }

        public bool IsImagePresentInDetailsPage()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.ProductImage, How.CssSelector);

        }

        public bool IsProductRatingPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.ProductRating, How.CssSelector);

        }

        public bool IsProductDescriptionPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.ProductDescription, How.CssSelector);

        }

        public bool IsSizeSelectorDropdownPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.SizeSelector, How.CssSelector);

        }

        public bool IsQuantitySelectorDropdownPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.QuantitySelector, How.CssSelector);

        }


        public string GetProductPriceNew()
        {
            return SiteDriver.FindElement(ApplicationPageObjects.ProductPriceNew, How.CssSelector).Text;

        }

        public string GetProductPriceOld()
        {
            return SiteDriver.FindElement(ApplicationPageObjects.ProductPriceOld, How.CssSelector).Text;

        }

        public string GetProductDiscount()
        {
            return SiteDriver.FindElement(ApplicationPageObjects.ProductDiscount, How.CssSelector).Text;
        }

        public bool IsAddToCartButtonPresent()
        {
            return SiteDriver.IsElementPresent(ApplicationPageObjects.AddToCartButton, How.CssSelector);

        }



    }
}
