<img alt="Meyer Corporation Logo" src="https://lemon-river-09725971e.azurestaticapps.net/images/Meyer.jpg" width="400" />

# MeyerCorp.Usps.Example

A .NET Core console application that demonstrates the use of MeyerCorp.Usps.Core library.

## Architecture

This assembly references the MeyerCorp.Usps.Core library through its NuGet package: [MeyerCorp.Usps.Core](https://www.nuget.org/packages/MeyerCorp.Usps.Core).

### Prerequisites

.NET Core 3.1 or higher.

## Getting Started

* Get a User ID/API Key from the [USPS API website](https://www.usps.com/business/web-tools-apis/), and add it as a user secret with the key: *ApiUsername*.
* Install [.NET Core 3.1](https://dotnet.microsoft.com/download/) (or higher) SDK or runtime.
* Get the code for at least the Example console app.
* Build and Run
  * *or*
* Use your favorite debugger/IDE.


### Installing

(N/A)

## What To Expect

Use the application and review the code to see how it references the Core library. Review the specs on the USPS site to really see how MeyerCorp.Usps.Core makes for a much easier experience when creating .NET applications. Using the Core library, Azure Function projects, AppService projects and even IIS hosting to create your own RESTful APIs are much easier.

## Built With

* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/)
* [USPS Web API](https://www.usps.com/business/web-tools-apis/welcome.htm)

## Contributing

Please read [CONTRIBUTING.md](https://github.com/MeyerCorporation/Usps.Core/blob/dev/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

## Authors

* **Daniel Przybylski** - [Alfetta159](https://github.com/Alfetta159)

See also the list of [contributors](https://github.com/MeyerCorporation/Usps.Core/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments


## References

* [Welcome to the Web Tools API Portal](https://www.usps.com/business/web-tools-apis/welcome.htm)
* [Azure Functions Quick Start](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio#:~:text=Table%201%20%20%20%20Setting%20%20,created%20function%20can%20be%20triggered%20by%20...%20)
* [.NET Core Web API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)
