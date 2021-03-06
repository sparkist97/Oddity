# Oddity
[![GitHub release](https://img.shields.io/github/release/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/releases)
[![NuGet downloads](https://img.shields.io/nuget/dt/Oddity.svg)](https://www.nuget.org/packages/Oddity/)
[![GitHub issues](https://img.shields.io/github/issues/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/issues)
[![GitHub stars](https://img.shields.io/github/stars/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/stargazers)
[![GitHub license](https://img.shields.io/github/license/Tearth/Oddity.svg)](https://github.com/Tearth/Oddity/blob/master/LICENSE)

SpaceX API wrapper for .NET based on the https://github.com/r-spacex/SpaceX-API project. Method names are very familiar with API endpoints so you can just use API wiki documents:

https://github.com/r-spacex/SpaceX-API/wiki

**Available data overview:**
 * company data, history with most important events
 * detailed information about rockets (Falcon 1, Falcon 9, Falcon Heavy, BFR) and capsules (Dragon 1, Dragon 2, crew Dragon)
 * launchpads data
 * launches: latest, next, all past, all upcoming
 * information about the specified cores and capsules
 
Most of the endpoints contains a lot of filters which are applied on the API side to save bandwidth. Look at the example and [wiki](https://github.com/Tearth/Oddity/wiki) for more information.

# Minimal requirements
Library is build on [.NET Standard 1.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) which contains support for:
 * .NET Framework 4.5 or higher
 * .NET Core 1.0 or higher
 * Mono 4.6 or higher
 * Xamarin.iOS 10.0 or higher
 * Xamarin.Mac 3.0 or higher
 * Xamarin.Android 7.0 or higher
 * Universal Windows Platform 10.0 or higher
 
**External dependencies:**
 * Newtonsoft.Json

# Installation
 * download from NuGet: https://www.nuget.org/packages/Oddity/

or

 * search "Oddity" in Package Manager

or

 * run `Install-Package Oddity` in the Package Manager Console
 
# Example usage
```csharp
using System;
using Newtonsoft.Json.Serialization;
using Oddity;
using Oddity.API.Models.Launch.Rocket.SecondStage;
using Oddity.API.Models.Rocket;

namespace OverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var oddity = new OddityCore();

            // Optional.
            oddity.OnDeserializationError += OddityOnDeserializationError;

            // Note that every request must be done with Execute() or ExecuteAsync() call to retrieve data from the SpaceX API.

            // Get company information.
            var company = oddity.Company.GetInfo().Execute();

            // Get all history.
            var history = oddity.Company.GetHistory().Execute();

            // Get history from the last two years and ordered descending.
            var historyWithFilter = oddity.Company.GetHistory().WithRange(DateTime.Now.AddYears(-2), DateTime.Now).Descending().Execute();

            // Get data about Falcon Heavy.
            var falconHeavy = oddity.Rockets.GetAbout(RocketId.FalconHeavy).Execute();

            // Get list of all launchpads.
            var allLaunchpads = oddity.Launchpads.GetAll().Execute();

            // Get information about the next launch.
            var nextLaunch = oddity.Launches.GetNext().Execute();

            // Get data about all launches of Falcon 9 which has been launched to ISS and landed with success. Next, sort it ascending.
            var launchWithFilters = oddity.Launches.GetAll().WithRocketName("Falcon 9").WithOrbit(OrbitType.ISS).WithLandSuccess(true).Ascending().Execute();

            // Get capsule which has been launched 2015-04-14 at 20:10.
            var capsuleWithFilters = oddity.DetailedCapsules.GetAll().WithOriginalLaunch(new DateTime(2015, 4, 14, 20, 10, 0)).Execute();

            // Get all cores.
            var allCores = oddity.DetailedCores.GetAll().Execute();
        }

        private static void OddityOnDeserializationError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("Something went wrong.");

            // We don't want to stop all program, just leave problematic field as null.
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
}
```

# Why Oddity?
https://www.youtube.com/watch?v=iYYRH4apXDo