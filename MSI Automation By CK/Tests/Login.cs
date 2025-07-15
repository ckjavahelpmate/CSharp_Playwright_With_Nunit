using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI_Automation_By_CK.Tests
{
    internal class Login
    {
        [Test]
        public async Task LoginToMSIApp()
        {

            IPlaywright playwright = await Playwright.CreateAsync();

            IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = false,
                
            });

            IBrowserContext browserContext = await browser.NewContextAsync();

            IPage page = await browserContext.NewPageAsync();

            await page.GotoAsync("https://testadmin.msimga.com/");

            await Task.Delay(2000);

            ILocator loginNmae = page.Locator("#LoginName");
            await loginNmae.FillAsync("qeUnderwriting@msiqe.com");

            ILocator password = page.Locator("#LoginPassword");
            await password.FillAsync("u6\"086tElR9V3p1qN29");

            ILocator signInButton = page.Locator("#buttonSignIn");
            await signInButton.ClickAsync();

            String titile = await page.TitleAsync();

            Console.WriteLine(titile);

            await Task.Delay(5000);

        }
    }
}
