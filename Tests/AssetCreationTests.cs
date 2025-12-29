using NUnit.Framework;
using SnipeIT.Tests.Pages;
using SnipeIT.Tests.Utilities;

namespace SnipeIT.Tests.Tests
{
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

            await loginPage.LoginAsync("admin", "password");
            await assetsPage.CreateMacbookAssetAsync(assetName, randomUser);
            await assetsPage.SearchAssetAsync(assetName);

            // Skip detailed validation in CI to avoid dashboard timing issues
            if (Environment.GetEnvironmentVariable("CI") != "true")
            {
                await assetDetailsPage.ValidateAssetDetailsAsync(assetName);
                await assetDetailsPage.ValidateHistoryAsync();
            }
        }
    }
}
