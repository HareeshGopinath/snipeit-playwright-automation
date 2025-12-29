using Microsoft.Playwright;

namespace SnipeIT.Tests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/login", new PageGotoOptions
            {
                Timeout = 60000 // 60 seconds timeout
            });

            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");

            // Wait for a specific element on dashboard instead of URL
            await _page.WaitForSelectorAsync("text=Assets", new PageWaitForSelectorOptions
            {
                Timeout = 60000 // 60 seconds timeout
            });
        }
    }
}
