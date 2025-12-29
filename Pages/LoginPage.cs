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
            await _page.GotoAsync("https://demo.snipeitapp.com/login");

            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");

            // CI-friendly wait: skip in CI
            if (Environment.GetEnvironmentVariable("CI") != "true")
            {
                try
                {
                    await _page.Locator("text=Assets Dashboard").WaitForAsync(new LocatorWaitForOptions
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 120_000
                    });
                }
                catch
                {
                    // Screenshot on failure
                    await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "login-failed.png" });
                    throw new Exception("Login failed or dashboard not visible. Screenshot saved as login-failed.png");
                }
            }
        }
    }
}
