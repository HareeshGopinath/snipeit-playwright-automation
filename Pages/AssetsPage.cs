using Microsoft.Playwright;
using NUnit.Framework;

namespace SnipeIT.Tests.Pages
{
    public class AssetsPage
    {
        private readonly IPage _page;

        public AssetsPage(IPage page)
        {
            _page = page;
        }

        public async Task CreateMacbookAssetAsync(string assetName, string user)
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware/create");

            // Model dropdown is custom; click and select option
            await _page.ClickAsync("#model_id .select2-selection");
            await _page.ClickAsync("text=Macbook Pro 13\"");

            // Fill asset tag
            await _page.FillAsync("#asset_tag", assetName);

            // Status dropdown is custom; click and select option
            await _page.ClickAsync("#status_id .select2-selection");
            await _page.ClickAsync("text=Ready to Deploy");

            // Checkout to user
            await _page.ClickAsync("text=Checkout");
            await _page.FillAsync("#assigned_user", user);

            // Submit
            await _page.ClickAsync("button[type='submit']");
        }

        public async Task SearchAssetAsync(string assetName)
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");
            await _page.FillAsync("input[type='search']", assetName);
            await _page.PressAsync("input[type='search']", "Enter");
        }
    }
}
