<img alt="Meyer Corporation Logo" src="https://lemon-river-09725971e.azurestaticapps.net/images/Meyer.jpg" width="400" />

# MeyerCorp.Usps.Core

The MeyerCorp.Usps.Core assembly is a code lbrary for .NET Core 3.1 which is acts as a software development kit for other .NET assemblies allowing more convenient access to the [Internet API from the US Postal Service](https://www.usps.com/business/web-tools-apis/documentation-updates.htm). The Core library is distributed as a [NuGet package](https://www.nuget.org/packages/MeyerCorp.Usps.Core) and is referenced directly by other assembly projects in this repository.

The USPS APIs don't follow standards of either REST or SOAP but instead pass XML elements as a query argument of a HTTP GET command. The purpose of this library is to map .NET POCO objects to XML elements and URL routes required and returned by the USPS API. It also adds more descriptions to certain character codes which are returned by the USPS API.

## Prerequisites

- [.NET Core 3.1 or higher](https://dotnet.microsoft.com/download/dotnet)
- A user name (API Key) issued from the  [USPS API developer site](https://www.usps.com/business/web-tools-apis/general-api-developer-guide.htm#_Toc24631952).

## Endpoints

> All endpoint code has links in XML comments to their corresponding documentation on the USPS API website. Refer to that documenation for information on errors and footnote values. *Currently, only those API endpoints w/o strike thru are supported.*

1. [Address Endpoints](https://www.usps.com/business/web-tools-apis/address-information-api.htm)
    - Address Validation/Standardization
    - City & State Lookup
    - Zip Code™ Lookup
2. ~~[Tracking & Delivery Information APIs
Tracking](https://www.usps.com/business/web-tools-apis/track-and-confirm-api_files/track-and-confirm-api.htm)~~
    - ~~Tracking by Email~~
    - ~~Proof of Delivery~~
    - ~~Tracking Proof of Delivery~~
    - ~~Return Receipt Electronic~~
3. ~~Price Calculator APIs~~
    - ~~Domestic Price Calculator~~
    - ~~International Price Calculator~~
    - ~~Shipping Label APIs~~
4. ~~eVS Domestic Labels~~
5. ~~eVS International Labels~~
6. ~~Scan Form~~
7. ~~USPS Returns Labels~~
8. ~~Package Pickup APIs~~
    - ~~Check pickup availability~~
    - ~~Schedule a pickup~~
    - ~~Cancel a pickup request~~
    - ~~Update a pickup request~~
9. ~~Service Standards & Commitments APIs~~
    - ~~Domestic Mail Service Standards~~
    - ~~Service Delivery Calculator~~
    - ~~Sunday Holiday Availability~~
10. ~~Hold for Pickup Facilities Lookup API~~
