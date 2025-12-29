using Microsoft.Playwright;

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

            // Select model (div-based custom dropdown)
            await _page.ClickAsync("#model_id"); 
            await _page.ClickAsync($"text=Macbook Pro 13\"");

            await _page.FillAsync("#asset_tag", assetName);

            // Select status (div-based dropdown)
            await _page.ClickAsync("#status_id");
            await _page.ClickAsync("text=Ready to Deploy");

            // Assign user
            await _page.ClickAsync("text=Checkout");
            await _page.FillAsync("#assigned_user", user);

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
