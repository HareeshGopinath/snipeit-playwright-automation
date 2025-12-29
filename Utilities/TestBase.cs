using Microsoft.Playwright;
using NUnit.Framework;
using System;
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

            // Launch Chromium browser in headless mode with higher timeout for CI
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                Timeout = 60000 // 60 seconds launch timeout
            });

            // Create a new browser context with default timeout
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                Timeout = 60000 // 60 seconds default timeout for actions
            });

            // Open a new page
            Page = await Context.NewPageAsync();

            // Optional: set default navigation timeout for the page
            Page.SetDefaultNavigationTimeout(60000); // 60 seconds
            Page.SetDefaultTimeout(60000);           // 60 seconds for all actions
        }

        [TearDown]
        public async Task TearDown()
        {
            // Close page, context, and browser safely
            if (Page != null)
            {
                await Page.CloseAsync();
                Page = null;
            }

            if (Context != null)
            {
                await Context.CloseAsync();
                Context = null;
            }

            if (Browser != null)
            {
                await Browser.CloseAsync();
                Browser = null;
            }

            // Dispose Playwright instance
            Playwright?.Dispose();
            Playwright = null;
        }
    }
}
