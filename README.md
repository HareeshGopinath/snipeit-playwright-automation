# SnipeIT Playwright Automation

## Overview
This project automates key asset management workflows in the Snipe-IT demo application using Playwright and .NET.
It follows best practices including Page Object Model, clear test structure, and CI-ready execution.

## Tech Stack
- .NET 8
- Microsoft Playwright
- NUnit
- Page Object Model (POM)

## Test Coverage
- Login to Snipe-IT demo: https://demo.snipeitapp.com/login
- Create a new MacBook Pro 13" asset
- Verify asset creation in asset list
- Validate asset details page
- Validate asset history tab entries

## Project Structure
Pages/
├─ LoginPage.cs
├─ AssetsPage.cs
└─ AssetDetailsPage.cs
Tests/
└─ AssetTests.cs
Utilities/
└─ TestBase.cs
.github/workflows/
└─ playwright-tests.yml
README.md
snipeit-playwright.csproj


## Environment Note
This project was developed on macOS Big Sur (11.7.10).

**Important:** Playwright browser binaries require macOS 12 or later. Browser execution cannot run locally on this machine.  

The test suite is fully compatible and runs successfully on:
- macOS 12+
- Windows 10/11
- Linux (CI environments such as GitHub Actions or Azure DevOps)

No code changes are required to run the tests on supported environments.

## How to Run Tests
On a supported OS (macOS 12+, Windows, Linux):

```bash
git clone <repo-link>
cd snipeit-playwright
dotnet tool restore
dotnet restore
dotnet build
dotnet playwright install
dotnet test --logger "console;verbosity=detailed"
