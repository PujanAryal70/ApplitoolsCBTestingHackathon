using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ApplitoolsCBTestingHackathon
{
    public static class SiteDriver
        {
            public static IWebDriver _driver;
            public static IJavaScriptExecutor _javascriptexecutor;
            public static WebDriverWait _waitPageLoad;


            public static void Start(string url,string browserName="chrome3")
            {
                int width = 0;
                int height = Convert.ToInt32(BrowsersSettings.Height.ToString());
                if (browserName.Equals("edge1"))
                {
                    _driver = new EdgeDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[0]);
                }
                else if (browserName.Equals("edge2"))
                {
                    _driver = new EdgeDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[1]);
                }
                else if (browserName.Equals("firefox1"))
                {
                    _driver = new FirefoxDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[0]);
                }
                else if (browserName.Equals("firefox2"))
                {
                    _driver = new FirefoxDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[1]);
                }
                else if(browserName.Equals("chrome1"))
                {
                    _driver = new ChromeDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[0]);
                }
                else if (browserName.Equals("chrome2"))
                {
                    _driver = new ChromeDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[1]);
                }
                else if (browserName.Equals("chrome3"))
                {
                    _driver = new ChromeDriver();
                }
                else if (browserName.Equals("mobilePortrait"))
                {
                    _driver = new ChromeDriver();
                    width = Convert.ToInt32(BrowsersSettings.Width.Split(',')[2]);
                }
                _waitPageLoad = new WebDriverWait(_driver, TimeSpan.FromSeconds(500));
                _javascriptexecutor = (IJavaScriptExecutor)_driver;
                _driver.Navigate().GoToUrl(url);
                WaitForPageToLoad();
                if (!browserName.Equals("chrome3"))
                {
                    _driver.Manage().Window.Size = new Size(width, height);
                    var windowSize = _driver.Manage().Window.Size;
                }


            }


            public static bool IsElementPresent(string select, How selector, int timeOut = 0)
            {
                try
                {
                    FindElement(select, selector, _driver, timeOut);
                    return true;
                }
                catch (Exception ex)
                {
                    // Don't handle NotSupportedException
                    if (ex is NotSupportedException)
                        throw;
                    return false;
                }
            }

            internal static IWebElement FindElement(string select, How selector)
            {
                return FindElement(select, selector, _driver);
            }

            public static IEnumerable<IWebElement> FindElements(string select, How selector)
            {
                return FindElements(select, selector, _driver);
            }

            internal static IWebElement FindElement(string select, How selector, ISearchContext context, int elementTimeOut = 2000)
            {
                switch (selector)
                {
                    case How.ClassName:
                        return WaitandReturnElementExists(By.ClassName(select), context, elementTimeOut);
                    case How.CssSelector:
                        return WaitandReturnElementExists(By.CssSelector(select), context, elementTimeOut);
                    case How.Id:
                        return WaitandReturnElementExists(By.Id(select), context, elementTimeOut);
                    case How.LinkText:
                        return WaitandReturnElementExists(By.LinkText(select), context, elementTimeOut);
                    case How.Name:
                        return WaitandReturnElementExists(By.Name(select), context, elementTimeOut);
                    case How.PartialLinkText:
                        return WaitandReturnElementExists(By.PartialLinkText(select), context, elementTimeOut);
                    case How.TagName:
                        return WaitandReturnElementExists(By.TagName(select), context, elementTimeOut);
                    case How.XPath:
                        return WaitandReturnElementExists(By.XPath(select), context, elementTimeOut);
                }
                throw new NotSupportedException(string.Format("Selector \"{0}\" is not supported.", selector));
            }

            public static IWebElement WaitandReturnElementExists(By locator, ISearchContext context, int elementTimeOut = 2000)
            {
                if (elementTimeOut == 0)
                    return context.FindElement(locator);

                var wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(2000));
                IWebElement webElement = null;
                wait.Until(driver =>
                {
                    try
                    {
                        webElement = context.FindElement(locator);
                        return webElement != null;

                    }
                    catch (Exception ex)
                    {
                        //Console.Out.WriteLine("unhandled exception" + ex.Message);
                        return false;
                    }
                });
                return webElement;
            }

            public static void Close()
            {
                _driver.Quit();
            }

            public static void WaitForCondition(Func<bool> f, int milliSec = 0)
            {

                milliSec = (int)((milliSec == 0) ? 100 * 1000 : milliSec);
                var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(milliSec));
                try
                {
                    wait.Until(d =>
                    {
                        try
                        {
                            return f();
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    });
                }
                catch (UnhandledAlertException ex)
                {
                    Console.Out.WriteLine("unhandled exception" + ex.Message);
                }

                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }

            public static void WaitForPageToLoad()
            {
                const string jScript = "return document.readyState;";
                _waitPageLoad.Until(d =>
                {
                    try
                    {
                        return (string)_javascriptexecutor.ExecuteScript(jScript) == "complete";
                    }
                    catch (UnhandledAlertException)
                    {
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(ex.Message);
                        return false;
                    }
                });
            }

        internal static IEnumerable<IWebElement> FindElements(string select, How selector, ISearchContext context, int elementTimeOut = 2000)
            {
                switch (selector)
                {
                    case How.ClassName:
                        return WaitandReturnElementsExists(By.ClassName(select), context, elementTimeOut);
                    case How.CssSelector:
                        return WaitandReturnElementsExists(By.CssSelector(select), context, elementTimeOut);
                    case How.Id:
                        return WaitandReturnElementsExists(By.Id(select), context, elementTimeOut);
                    case How.LinkText:
                        return WaitandReturnElementsExists(By.LinkText(select), context, elementTimeOut);
                    case How.Name:
                        return WaitandReturnElementsExists(By.Name(select), context, elementTimeOut);
                    case How.PartialLinkText:
                        return WaitandReturnElementsExists(By.PartialLinkText(select), context, elementTimeOut);
                    case How.TagName:
                        return WaitandReturnElementsExists(By.TagName(select), context, elementTimeOut);
                    case How.XPath:
                        return WaitandReturnElementsExists(By.XPath(select), context, elementTimeOut);
                }
                throw new NotSupportedException(string.Format("Selector \"{0}\" is not supported.", selector));
            }

            public static IEnumerable<IWebElement> WaitandReturnElementsExists(By locator, ISearchContext context, int elementTimeOut = 2000)
            {
                if (elementTimeOut == 0)
                    return context.FindElements(locator);

                var wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1000));
                IEnumerable<IWebElement> webElement = null;
                wait.Until(driver =>
                {
                    try
                    {
                        webElement = context.FindElements(locator);
                        return webElement != null;

                    }
                    catch (Exception ex)
                    {
                        //Console.Out.WriteLine("unhandled exception" + ex.Message);
                        return false;
                    }
                });
                return webElement;
            }

            public static List<string> FindDisplayedElementsText(string select, How selector)
            {
                return FindElements(select, selector, _driver).Where(e => e.Displayed).Select(e => e.Text).ToList();
            }

        public static bool IsInAscendingOrder<T>(this List<T> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (Comparer<T>.Default.Compare(values[i], values[i + 1]) > 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check whether values are in descending order or not
        /// </summary>
        /// <param name = "values" ></ param >
        /// < returns ></ returns >
        public static bool IsInDescendingOrder<T>(this List<T> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (Comparer<T>.Default.Compare(values[i], values[i + 1]) < 0)
                    return false;
            }
            return true;
        }

        public static void ScrollToBottom()
            {
                _javascriptexecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            }

        }
    }
