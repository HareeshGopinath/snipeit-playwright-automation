using Microsoft.Playwright;
using System;
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
            await _page.GotoAsync("https://demo.snipeitapp.com/login");

            // Fill credentials
            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);

            // Click login
            await _page.ClickAsync("button[type='submit']");

            // Wait for dashboard element (adjust selector/text to match demo)
            try
            {
                await _page.Locator("text=Dashboard").WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 180000 // 3 min timeout for CI
                });
            }
            catch
            {
                // Capture screenshot if login fails
                await _page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = "login-failed.png",
                    FullPage = true
                });
                throw new Exception("Login failed or dashboard not visible. Screenshot saved as login-failed.png");
            }
        }
    }
}
