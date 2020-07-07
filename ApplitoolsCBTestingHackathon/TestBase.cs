using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ApplitoolsCBTestingHackathon.PageServices;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ApplitoolsCBTestingHackathon
{
    public class TestBase
    {
        protected ApplicationPage _v1Page;
        protected string appUrl;
        protected string path;
        public void Setup(string url, string browserName)
        {
            SiteDriver.Start(url,browserName);
            _v1Page = new ApplicationPage();
            appUrl = url;
            path = Path.Combine(
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")), 
                (appUrl == BrowsersSettings.Version1Url) ? "traditional-V1-TestResults.txt" : 
                    "Traditional-V2-TestResults.txt");
        }

        public static IEnumerable<String> BrowsersToRunWith()
        {
            String[] browsers = BrowsersSettings.Browsers.Split(',');
            foreach (var browser in browsers)
            {
                yield return browser;
            }

        }

        [TearDown]
        public void CleanUp()
        {
            SiteDriver.Close();
        }

        public bool HackathonReport(int task, string testName,string browserName, bool comparisonResult)
        {
            string Browser, Viewport = "", Device;
          
            if (browserName.Equals("chrome1")||browserName.Equals("chrome2"))
            {
                Browser = "Chrome";
                if (browserName.Equals("chrome1"))
                {
                    Viewport = "1200*700";
                    Device = "Laptop";
                }
                else
                {
                    Viewport = "768*700";
                    Device = "Tablet";
                }
            }
            else if (browserName.Equals("firefox1")||browserName.Equals("firefox2"))
            {
                Browser = "FireFox";
                if (browserName.Equals("firefox1"))
                {
                    Viewport = "1200*700";
                    Device = "Laptop";
                }
                else
                {
                    Viewport = "768*700";
                    Device = "Tablet";
                }
            }
            else if (browserName.Equals("edge1")||browserName.Equals("edge2"))
            {
                Browser = "Edge";
                if (browserName.Equals("edge1"))
                {
                    Viewport = "1200*700";
                    Device = "Laptop";
                }
                else
                {
                    Viewport = "768*700";
                    Device = "Tablet";
                }
            }
            else
            {
                Browser = "Chrome";
                Viewport = "500*700";
                Device = "Mobile";
            }

            using (StreamWriter fs = new StreamWriter(path, true))
            {
                string ReportContent = string.Format("Task: {0}, Test Name: {1}, Browser {2}, Viewport {3}, " +
                                                     "Device {4}, Status: {5}", task, testName, Browser, Viewport, Device, comparisonResult);
                fs.WriteLine(ReportContent);
            }

            //returns the result so that it can be used for further Assertions in the test code.
            return comparisonResult;
        }
    }
}
