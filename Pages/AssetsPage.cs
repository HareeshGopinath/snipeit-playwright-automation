using Microsoft.Playwright;
using System.Threading.Tasks;

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

            // Handle custom dropdown for model
            await _page.ClickAsync("#model_id");
            await _page.ClickAsync("text=Macbook Pro 13\"");

            // Fill asset tag
            await _page.FillAsync("#asset_tag", assetName);

            // Handle custom dropdown for status
            await _page.ClickAsync("#status_id");
            await _page.ClickAsync("text=Ready to Deploy");

            // Checkout to user
            await _page.ClickAsync("text=Checkout");
            await _page.FillAsync("#assigned_user", user);

            // Submit the form
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
