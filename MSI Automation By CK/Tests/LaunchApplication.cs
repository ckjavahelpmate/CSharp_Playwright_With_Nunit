using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI_Automation_By_CK.Tests
{
    internal class LaunchApplication
    {
        [Test]
        public async Task Launch()
        {
            Console.WriteLine("Launching the MSI application...");

            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge", // Specify the browser channel if needed
                Headless = false // Set to true if you want to run in headless mode
            });

            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();


            await page.GotoAsync("https://testadmin.msimga.com/"); // Replace with the URL of your MSI application

            await Task.Delay(1000); 
            Console.WriteLine("MSI application launched successfully.");
        }   
    }
}

