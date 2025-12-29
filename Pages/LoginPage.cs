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
            await _page.GotoAsync("https://demo.snipeitapp.com/login");

            // Wait for username input to be visible and fill
            var usernameLocator = _page.Locator("#username");
            await usernameLocator.WaitForAsync(new LocatorWaitForOptions 
            { 
                State = WaitForSelectorState.Visible,
                Timeout = 60000 // 60 seconds in case CI is slow
            });
            await usernameLocator.FillAsync(username);

            // Wait for password input to be visible and fill
            var passwordLocator = _page.Locator("#password");
            await passwordLocator.WaitForAsync(new LocatorWaitForOptions 
            { 
                State = WaitForSelectorState.Visible,
                Timeout = 60000
            });
            await passwordLocator.FillAsync(password);

            // Click the login button
            await _page.ClickAsync("button[type='submit']");

            // Wait for dashboard element (reliable way to confirm login)
            await _page.Locator("text=Assets Dashboard").WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 120000 // 2 minutes for slow CI runners
            });
        }
    }
}
