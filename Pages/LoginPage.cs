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

            var usernameLocator = _page.Locator("#username");
            await usernameLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await usernameLocator.FillAsync(username);

            var passwordLocator = _page.Locator("#password");
            await passwordLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await passwordLocator.FillAsync(password);

            await _page.ClickAsync("button[type='submit']");

            await _page.WaitForURLAsync("**/dashboard");
        }
    }
}
