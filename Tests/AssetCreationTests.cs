using NUnit.Framework;
using SnipeIT.Tests.Pages;
using SnipeIT.Tests.Utilities;
using System;
using System.Threading.Tasks;

namespace SnipeIT.Tests.Tests
{
    [TestFixture, Timeout(300000)] // 5 min per test
    public class AssetCreationTests : TestBase
    {
        [Test]
        public async Task Create_And_Verify_Macbook_Asset()
        {
            var loginPage = new LoginPage(Page);
            var assetsPage = new AssetsPage(Page);
            var assetDetailsPage = new AssetDetailsPage(Page);

            string assetName = $"MacBook-{Guid.NewGuid()}";
            string randomUser = "Admin User";

            try
            {
                // Login
                await loginPage.LoginAsync("admin", "password");

                // Create asset
                await assetsPage.CreateMacbookAssetAsync(assetName, randomUser);

                // Search and validate
                await assetsPage.SearchAssetAsync(assetName);
                await assetDetailsPage.ValidateAssetDetailsAsync(assetName);
                await assetDetailsPage.ValidateHistoryAsync();
            }
            catch
            {
                // Take screenshot if any step fails
                await Page.ScreenshotAsync(new Microsoft.Playwright.PageScreenshotOptions
                {
                    Path = "test-failure.png",
                    FullPage = true
                });
                throw;
            }
        }
    }
}
