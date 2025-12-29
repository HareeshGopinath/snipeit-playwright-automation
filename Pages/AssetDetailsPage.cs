using Microsoft.Playwright;
using NUnit.Framework;

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
            await _page.ClickAsync($"text={assetName}");

            Assert.That(await _page.InnerTextAsync("h1"), Does.Contain(assetName));
            Assert.That(await _page.InnerTextAsync("text=Ready to Deploy"), Is.Not.Null);
        }

        public async Task ValidateHistoryAsync()
        {
            await _page.ClickAsync("text=History");

            var historyText = await _page.InnerTextAsync("table");
            Assert.That(historyText, Does.Contain("checked out"));
            Assert.That(historyText, Does.Contain("created"));
        }
    }
}
