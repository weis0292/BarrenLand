# Mike Weispfenning's Barren Land Analysis

For Target's Technical Assessment Case study, I've chosen to perform the Barren Land Analysis.
The Application is written in C#.  The solution contains three projects:
  - MikeWeispfenning.BarrenLandAnalysis
  - MikeWeispfenning.BarrenLandAnalysis.Application
  - MikeWeispfenning.BarrenLandAnalysis.Tests

The **MikeWeispfenning.BarrenLandAnalysis** project contains everything needed to create a piece of land, salt that land (make it barren), and get the remaining fertile land.  The algorithm magic happens in this project, in the **Land.CalculateFertileLand** method.

The **MikeWeispfenning.BarrenLandAnalysis.Application** project is a console application that satisfies the I/O requirements of the Barren Land Analysis, as defined in the provided Technical Assessment Case Study.

The **MikeWeispfenning.BarrenLandAnalysis.Tests** project contains a collection of Unit and Itegration tests that verify the other two projects are working as intended.

## Building The Application

The application was built using Visual Studio 2017.  The only dependencies the application has are on the Microsoft .NET framework (v4.6.1) and the Microsoft MSTest framework.  For logging, the [log4net NuGet package](https://www.nuget.org/packages/log4net/ "log4net") is used.

## Running The Application

To run the application, simply build the application in the Release configuration, then use the command prompt to run **MikeWeispfenning.BarrenLandAnalysis.Application.exe** in the bin\Release folder.  Append any plots of land you'd like to make barren in the correct form ("bottomLeftX bottomLeftY topRightX topRightY"), and wait for the result.  You can enter in as many plots to salt as desired.

For example, running the application as follows:

```sh
MikeWeispfenning.BarrenLandAnalysis.Application.exe "0 292 399 307"
```
Will produce the following result:
```sh
116800 116800
Press any key to continue
```

## Testing The Application

There are two ways the application can be tested.  One is through the command prompt, and the other is through the tests that are included in the **MikeWeispfenning.BarrenLandAnalysis.Tests** project.  The included tests can be run through the Visual Studio test explorer, or using the Visual Studio Developer Command Prompt with the following command (after navigating to **MikeWeispfenning.BarrenLandAnalysis.Tests\bin\Release**):
```sh
vstest.console.exe MikeWeispfenning.BarrenLandAnalysis.Tests.dll
```

## Questions
If you find yourself with any questions, please don't hesitate to reach out to me at [weis0292@umn.edu](mailto:weis0292@umn.edu).  Thank you.