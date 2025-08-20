# GAPSTARSTechnicalAssessment
The automation project its using the current stack:
 - .net 8.0
 - Reqnroll
 - Nunit
 - Playwright

## Reqnroll

Reqnroll is an open-source .NET test automation tool to BDD (Gherkin).
The current Specflow doesn’t support the latest version of .net 8.
More details you can find in  [Reqnroll]: <https://docs.reqnroll.net/latest/index.html>

## Playwright

Playwright was created specifically to accommodate the needs of end-to-end testing. Playwright supports all modern rendering engines including Chromium, WebKit, and Firefox. Test on Windows, Linux, and macOS, locally or on CI, headless or headed with native mobile emulation.
[playwright]: <https://playwright.dev/dotnet/ >

## Recommended
- Use visual studio / Rider to work with the project.
- Install the Extension of Reqnroll to your IDE.
- Run the ide as a Adm user.


## Installation Guide

1. Install in your ide the extension of Reqnroll (Need to close the ide to apply the installation)
    1.1 Visual Studio - [Reqnroll for Visual Studio 2022 - Visual Studio Marketplace] <https://marketplace.visualstudio.com/items?itemName=Reqnroll.ReqnrollForVisualStudio2022>
    1.1 Rider - [Reqnroll for Rider Plugin for Rider | JetBrains Marketplace] <https://plugins.jetbrains.com/plugin/24012-reqnroll-for-rider>
2. Build the Project (Only build for now)
3. For the E2E testing Install required browsers.
4. Go to the “AcceptanceTests“ folder in the project. 
5. Run the command pwsh bin/Debug/net8.0/playwright.ps1 install 
    If pwsh is not available, you will have to install PowerShell.
	(https://playwright.dev/dotnet/docs/intro)

## How to run the tests

### Through the Ide
Right click in the test in the ide.
Click on run.

### Through the Cli
Run all the tests
Open Developer Command Promp. On the menu bar, select "Tools" ➡ "Command Line" ➡ "Developer Command Prompt"

Execute the command below:
```sh
dotnet test
```
#### How to use the filters

Use the  `--filter`  command-line option to filter the desired test:
```sh
dotnet test --filter Category=tag
```
Tests that have both tags:
```sh
dotnet test --filter "Category=us123 & Category=tag"
```
Test that have one of tags:
```sh
dotnet test --filter "Category=tag | Category=automated"
```

## Allure Report

You can find how it works here
https://allurereport.org/docs/how-it-works/

But the most important thing is:
'Allure generate' processes the test results and saves an HTML report into the specified directory.
To view the report, use the 'allure open' command.