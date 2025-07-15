using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTesting.Tests
{

    internal class HomeESHO3BindNewQuote
    {
        [Test]
        public async Task HomeESH03BrokerBilledNewQuoteTest()
        {
            // Get Test data
            String dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "TestData.json");
            JObject jObject = JObject.Parse(File.ReadAllText(dataPath));
            JArray? jArray = jObject["HomeESH03BrokerBilledNewQuoteTest"] as JArray;
            JObject? data = jArray?[0] as JObject;

            // Launch Application
            IPlaywright playwright = await Playwright.CreateAsync();
            IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "msedge", Headless = false });
            IBrowserContext browserContext = await browser.NewContextAsync();
            IPage page = await browserContext.NewPageAsync();
            await page.GotoAsync(url: TestContext.Parameters["url"]);

            //Login to Application
            ILocator usernameTestField = page.Locator("#LoginName");
            await usernameTestField.FillAsync(value: TestContext.Parameters["username"]);

            ILocator passwordTextField = page.Locator("#LoginPassword");
            await passwordTextField.FillAsync(value: TestContext.Parameters["password"]);

            ILocator signInButton = page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });
            await signInButton.ClickAsync();

            // Bind New Quote
            // Page1
            ILocator newQuoteDropDown = page.Locator("#btnGroupVerticalDropProducts");
            await newQuoteDropDown.ClickAsync();

            ILocator homeESHO3 = page.GetByText("Home E&S H03", new() { Exact = true });
            await homeESHO3.ClickAsync();

            ILocator zipeCode = page.Locator("#SelectPropertyZipCode");
            await zipeCode.FillAsync(data["Zipcode"].ToString());

            ILocator confirmButton = page.Locator("//button[text()='Confirm' and @type='submit']");
            await confirmButton.ClickAsync();

            ILocator agencyNameDropDown = page.Locator("#PolicyCoreInformation_AgencyPartyID");
            await agencyNameDropDown.SelectOptionAsync(new SelectOptionValue { Label = data["AgencyName"].ToString() });

            ILocator agentNameDropDown = page.Locator("#PolicyCoreInformation_AgentPartyID");
            await agentNameDropDown.SelectOptionAsync(new SelectOptionValue { Label = data["AgentName"].ToString() });

            ILocator licenseNumberTextField = page.Locator("#PolicyCoreInformation_AgentLicenseNumber");
            await licenseNumberTextField.FillAsync(data["AgentLicense"].ToString());

            ILocator firstNameTextField = page.Locator("#PNIFirstName");
            await firstNameTextField.FillAsync(data["FirstName"].ToString());

            ILocator lastNameTextField = page.Locator("#PNILastName");
            await lastNameTextField.FillAsync(data["LastName"].ToString());

            ILocator dobTextField = page.Locator("#PNIDateOfBirth");
            await dobTextField.FillAsync(data["DOB"].ToString());

            ILocator propertyButton = page.Locator("//button[ @href='#modalPropertyAddress' ]");
            await propertyButton.ClickAsync();

            ILocator streetTextField = page.Locator("#PropertyStreetAddress");
            await streetTextField.FillAsync(data["Street"].ToString());

            ILocator cityTextField = page.Locator("#PropertyCity");
            await cityTextField.FillAsync(data["City"].ToString());

            ILocator VerifyButton = page.Locator("#modalPropertyAddressClose");
            await VerifyButton.ClickAsync();

            ILocator nextButton = page.Locator("#buttonH04MDUNext");
            await nextButton.ClickAsync();

            // Page2
            ILocator occupancyDropDown = page.Locator("#Occupancy");
            await occupancyDropDown.SelectOptionAsync(new SelectOptionValue { Label = data["Occupancy"].ToString() });

            ILocator yearOfRoofTextField = page.Locator("#YearOfRoof");
            await yearOfRoofTextField.FillAsync(data["RoofYear"].ToString());

            ILocator nextButtonPage2 = page.Locator("#buttonH0HomeRiskCharacteristicsNext");
            await nextButtonPage2.ClickAsync();

            // Page3
            ILocator coverageBDropDown = page.Locator("#CoverageBPercentage");
            await coverageBDropDown.SelectOptionAsync(data["CoverageB"].ToString() );

            ILocator coverageCDropDown = page.Locator("#CoverageCPercentage");
            await coverageCDropDown.SelectOptionAsync( data["CoverageC"].ToString() );

            ILocator coverageDdropDown = page.Locator("#CoverageDPercentage");
            await coverageDdropDown.SelectOptionAsync(data["CoverageD"].ToString());

            ILocator rateButton = page.Locator("#buttonRate");
            await rateButton.ClickAsync();

            await Task.Delay(2000);
            ILocator premium = page.GetByRole(AriaRole.Heading, new() { Name = "$" }).First;
            string text = await premium.InnerTextAsync();
            double? basePremium = Convert.ToDouble( text.Substring(1) );
            Assert.That(basePremium, Is.GreaterThan(0));

            ILocator nextButtonPage3 = page.Locator("#buttonH0HomeDetailedCoverageNext");
            await nextButtonPage3.ClickAsync();

            //Page4
            ILocator emailAddress = page.Locator("#PNIEmailAddress");
            await emailAddress.FillAsync(data["Email"].ToString());

            ILocator phoneNumber = page.Locator("#PNIPhoneNumber");
            await phoneNumber.FillAsync(data["Contact"].ToString());

            ILocator addBrokerBilledButton = page.Locator("#ButtonSetupBrokerBilled");
            await addBrokerBilledButton.ClickAsync();

            ILocator confrimButtonBrokerBilled = page.Locator("#buttonBrokerBilledConfirm");
            await confrimButtonBrokerBilled.ClickAsync();

            ILocator buyNow = page.Locator("#buttonH0HomePaymentBuyNow");
            await buyNow.ClickAsync();

            ILocator confirmBuyNow = page.Locator("#buttonBindDisclosuresConfirm");
            await confirmBuyNow.ClickAsync();

            ILocator policyStatusTextField = null;
            String? policyStatus = null;

            for (int i = 1; i <= 4; i++)
            {
                policyStatusTextField = page.Locator("#PolicyCoreInformation_PolicyStatusDisplay");
                policyStatus = await policyStatusTextField.GetAttributeAsync("value");
                if (policyStatus.Equals("Active"))
                {
                    break;
                }
                await Task.Delay(3000);
                await page.ReloadAsync();
            }

            Assert.That(policyStatus, Is.EqualTo("Active"), "Policy status not changed to Active");

            ILocator policyNumberTextField = page.Locator("#PolicyCoreInformation_PolicyNumber");
            string? policyNumber = await policyNumberTextField.GetAttributeAsync("value");
            Console.WriteLine( $"Policy Number :: {policyNumber}");

        }
    }

    internal class HomeESHO3
    {
    }
}
