# Pre-requisites:

1. Visual Studio installed on your machine.  ".NET Core 3.1" should be installed in Visual Studio too (if no - add it with Visual Studio Installer)
   * [Install it from here](https://visualstudio.microsoft.com/downloads/)
2. Chrome browser, Firefox Browser and Edge Browser is installed on your machine.
   
3. Chrome, Firefox, Edge Webdriver is installed from Nuget Package Manager.

4. Nunit, Eyes.Selenium, NUnit3TestAdapter, Selenium.Webdriver,Selenium.Support packages are installed from Nuget Package Manager



# Steps to run


1. Navigate to folder `ApplitoolsCBTestingHackathon` and double click the `ApplitoolsCBTestingHackathon.sln`. This will open the project in Visual Studio
   
2. In Visual Studio open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and enter command `dotnet restore` in the console. Command execution can take several minutes. This will install all the dependencies mentioned above.

3. Build the solution (Build > Build Solution).

4. Run Tests
