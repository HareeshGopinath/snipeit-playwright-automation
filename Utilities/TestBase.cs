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

            // Launch Chromium in headless mode (CI-friendly)
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            // Create browser context
            Context = await Browser.NewContextAsync();

            // Open new page
            Page = await Context.NewPageAsync();

            // Set professional default timeouts for actions and navigation
            Page.SetDefaultTimeout(60_000);           // 60s for actions
            Page.SetDefaultNavigationTimeout(60_000); // 60s for navigation
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Page != null) await Page.CloseAsync();
            if (Context != null) await Context.CloseAsync();
            if (Browser != null) await Browser.CloseAsync();
            Playwright?.Dispose();
        }
    }
}
