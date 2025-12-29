using Microsoft.Playwright;
using System.Threading.Tasks;

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
            // Navigate to login page
            await _page.GotoAsync("https://demo.snipeitapp.com/login", new PageGotoOptions
            {
                Timeout = 120_000 // 2 minutes for CI
            });

            // Wait for username field
            await _page.WaitForSelectorAsync("#username", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });

            // Fill login form
            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");

            // Wait for a stable element on dashboard to confirm login
            await _page.WaitForSelectorAsync("text=Assets", new PageWaitForSelectorOptions
            {
                Timeout = 120_000
            });
        }
    }
}
