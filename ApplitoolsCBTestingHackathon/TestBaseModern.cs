using Applitools.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Applitools;
using Applitools.VisualGrid;
using ApplitoolsCBTestingHackathon.PageServices;
using NUnit.Framework;

namespace ApplitoolsCBTestingHackathon
{
    public class TestBaseModern
    {
        protected Eyes _eyes;
        protected ApplicationPage applicationPage;
        protected VisualGridRunner runner;

        public void SetUp(string url)
        {
            SiteDriver.Start(url);
            runner = new VisualGridRunner(10);
            _eyes = new Eyes(runner);
            //_eyes.ApiKey = "4PcHiVZ83Zjxt3eBY99gMzAOSlOSPtMWEdoyuaPRTh108c110";
            VisualGridConfig.SetGrid(_eyes);
            //BatchInfo b = new BatchInfo("UFG Hackathon");
            //b.Id = "PUJANARYAL";
            //_eyes.Batch = b;
            applicationPage = new ApplicationPage();
        }

        [TearDown]
        public void TestCleanUp()
        {
            TestResultsSummary allTestResults = runner.GetAllTestResults();
            SiteDriver.Close();
        }
    }
}
