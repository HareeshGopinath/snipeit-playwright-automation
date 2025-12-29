using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SnipeIT.Tests.Pages
{
    public class AssetDetailsPage
    {
        private readonly IPage _page;

        public AssetDetailsPage(IPage page)
        {
            _page = page;
        }

        public async Task ValidateAssetDetailsAsync(string assetName)
        {
            // Click on asset link in search results
            await _page.ClickAsync($"text={assetName}");

            // Validate header and status
            Assert.That(await _page.InnerTextAsync("h1"), Does.Contain(assetName));
            Assert.That(await _page.InnerTextAsync("text=Ready to Deploy"), Is.Not.Null);
        }

        public async Task ValidateHistoryAsync()
        {
            // Open History tab
            await _page.ClickAsync("text=History");

            // Verify history entries
            var historyText = await _page.InnerTextAsync("table");
            Assert.That(historyText, Does.Contain("checked out"));
            Assert.That(historyText, Does.Contain("created"));
        }
    }
}
