using DataDrivenTesting.Utilities;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTesting.Tests
{
    internal class Login
    {
        [Test]
        [TestCaseSource(typeof(DataProvider) ,nameof(DataProvider.data), new object[] { "Environment"  })]
        public async Task LoginToVIPTest(Dictionary<string, string> data)
        {

            IPlaywright playwright = await Playwright.CreateAsync();
            IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "msedge", Headless = false });
            IBrowserContext browserContext = await browser.NewContextAsync();
            IPage page = await browserContext.NewPageAsync();
            await page.GotoAsync("https://testadmin.msimga.com/");
            await Task.Delay(3000);
            ILocator email = page.Locator("#LoginName");
            await email.FillAsync(data["username"]);
            ILocator password = page.GetByPlaceholder("Password");
            await password.FillAsync(data["password"] );
            ILocator signInButton = page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });
            await signInButton.ClickAsync();
            ILocator searchPage = page.GetByRole(AriaRole.Heading, new() { Name = "Select Search Criteria" });
            await Assertions.Expect(searchPage).ToBeVisibleAsync();
            await Task.Delay(5000);
        }
    }
}
