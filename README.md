# Guides for .NET SDK

This repo contains guides for building apps using .NET SDK. The guides are applicable for .NET core 3.1 and higher.

## Guides

* [Use cases for generic host](/docs/guides/generic-host-use-cases.md)
* [Code coverage on multiple projects using Coverlet](/docs/guides/code-coverage.md)
* [Debug NuGet package with included symbols](/docs/guides/debug-pdg-included-on-nuget.md)
* [Share data across the lifetime of an HTTP request](/docs/guides/share-data-with-async-local.md)

## GitHub Workflows

| Worflow                   |      Status and link      |
|---------------------------|:-------------------------:|
| [all-guides-sln](https://github.com/edumserrano/dot-net-sdk-extensions/blob/master/.github/workflows/build-demos.yml)             |  ![Build Status](https://github.com/edumserrano/dot-net-sdk-extensions/workflows/Build%20demos/badge.svg) |

## Building

### Using Visual Studio

1) Clone the repo and open one of the solution files:
   - **DotNet.Sdk.Extensions.sln:** source for the extensions.
   - **DotNet.Sdk.Extensions.Demos.sln:** demo projects for the extensions and the guides.

2) Press build on Visual Studio.

### Using dotnet CLI

1) Clone the repo and browse to the directory using your favorite shell.

2) Run:
   - **`dotnet build DotNet.Sdk.Extensions.sln`:** to build the source for the extensions.
   - **`dotnet build DotNet.Sdk.Extensions.Demos.sln`:** to build the demos for the extensions and the guides.

## License

This project is licensed under the [MIT license](https://licenses.nuget.org/MIT).
