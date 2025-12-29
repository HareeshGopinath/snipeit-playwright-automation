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

            // ---- Model Dropdown ----
            // Wait until the model dropdown is visible
            await _page.WaitForSelectorAsync("#model_id", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            // Click the dropdown
            await _page.ClickAsync("#model_id");

            // Wait for the desired option to appear
            await _page.WaitForSelectorAsync("text=Macbook Pro 13\"", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            // Select the option
            await _page.ClickAsync("text=Macbook Pro 13\"");

            // ---- Asset Tag ----
            await _page.FillAsync("#asset_tag", assetName);

            // ---- Status Dropdown ----
            await _page.WaitForSelectorAsync("#status_id", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            await _page.ClickAsync("#status_id");

            await _page.WaitForSelectorAsync("text=Ready to Deploy", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            await _page.ClickAsync("text=Ready to Deploy");

            // ---- Checkout User ----
            await _page.ClickAsync("text=Checkout");

            // Wait for the assigned user input to appear
            await _page.WaitForSelectorAsync("#assigned_user", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            await _page.FillAsync("#assigned_user", user);

            // ---- Submit Form ----
            await _page.ClickAsync("button[type='submit']");

            // Optional: Wait for navigation or confirmation message
            await _page.WaitForSelectorAsync("text=Asset Created", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });
        }

        public async Task SearchAssetAsync(string assetName)
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");

            // Wait for search input
            await _page.WaitForSelectorAsync("input[type='search']", new PageWaitForSelectorOptions
            {
                Timeout = 60_000
            });

            await _page.FillAsync("input[type='search']", assetName);
            await _page.PressAsync("input[type='search']", "Enter");

            // Wait for search results
            await _page.WaitForSelectorAsync($"text={assetName}", new PageWaitForSelectorOptions
            {
                Timeout = 60_000
            });
        }
    }
}
