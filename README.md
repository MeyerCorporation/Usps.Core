<img alt="Meyer Corporation Logo" src="https://lemon-river-09725971e.azurestaticapps.net/images/Meyer.jpg" width="400" />

# MeyerCorp.Usps

A more convenient wrapper of the United States Postal Service APIs. 

The USPS Web APIs are an HTTP web service, however they rely on long strings of rudimentary XML as a parameter of the query in the target URL.

MeyerCorp.Usps uses a more traditional RESTful approach in most cases and exposes a Swagger endpoint.

## Architecture

The solution contains four projects allowing two main configurations for use:

### API

This is a .NET Core Web API which allows the product to be configured and hosted like any .NET Core web app.

### USPS

This is a .NET Core library which contains the controller and model components. It will yield an assembly which is refrenced by the API project and also a NuGet package which allows the controller and models to be included in an existing web application.

### Client

This is a .NET Standard library which contains code generated by AutoRest based on the Swagger information presented by the API. This can be referenced as a project in a solution, but it also creates a NuGet package.

### Test

This is a collection of unit tests written in xunit.


## Getting Started

### Prerequisites

### Installing

## Running the tests

### Break down into end to end tests

### And coding style tests

## Deployment

## Built With

* [.NET Core 2.2](https://docs.microsoft.com/en-us/dotnet/core/)
* [USPS Web API](https://www.usps.com/business/web-tools-apis/welcome.htm)

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

## Authors

* **Daniel Przybylski** - [Alfetta159](https://github.com/Alfetta159)

See also the list of [contributors](https://github.com/MeyerCorporation/Usps.Core/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc

## References

[Welcome to the Web Tools API Portal](https://www.usps.com/business/web-tools-apis/welcome.htm)
