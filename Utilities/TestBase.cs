using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SnipeIT.Tests.Utilities
{
    public class TestBase
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            // Create Playwright instance
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            // Launch Chromium browser in headless mode
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            // Create a new browser context
            Context = await Browser.NewContextAsync();

            // Open a new page
            Page = await Context.NewPageAsync();

            // Set default timeouts for page actions and navigation
            Page.SetDefaultTimeout(60000);           // 60 seconds for all actions
            Page.SetDefaultNavigationTimeout(60000); // 60 seconds for navigations
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Page != null)
            {
                await Page.CloseAsync();
            }

            if (Context != null)
            {
                await Context.CloseAsync();
            }

            if (Browser != null)
            {
                await Browser.CloseAsync();
            }

            Playwright?.Dispose();
        }
    }
}
