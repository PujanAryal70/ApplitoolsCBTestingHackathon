using System;
using System.Collections.Generic;
using System.Text;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using Configuration = Applitools.Selenium.Configuration;

namespace ApplitoolsCBTestingHackathon
{
    public class VisualGridConfig
    {
        public static void SetGrid(Eyes eyes)
        {

            Configuration vgConfig = new Configuration();
            vgConfig.SetApiKey("4PcHiVZ83Zjxt3eBY99gMzAOSlOSPtMWEdoyuaPRTh108c110");
            BatchInfo b = new BatchInfo("UFG Hackathon");
            //b.Id = "PUJANARYAL";
            //eyes.Batch = b;
            vgConfig.SetBatch(b);
            vgConfig.AddBrowser(1200, 700, BrowserType.CHROME);
            vgConfig.AddBrowser(1200, 700, BrowserType.FIREFOX);
            vgConfig.AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM);
            vgConfig.AddBrowser(768, 700, BrowserType.CHROME);
            vgConfig.AddBrowser(768, 700, BrowserType.FIREFOX);
            vgConfig.AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM);
            vgConfig.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
            eyes.SetConfiguration(vgConfig);
        }
    }
}
