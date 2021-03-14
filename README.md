# .NET guides

This repo contains guides for developing apps using .NET SDK. These guides are applicable for .NET core 3.1 and higher.

## Guides

* [Use cases for generic host](./docs/guides/generic-host-use-cases.md)
* [Code coverage on multiple projects using Coverlet](./docs/guides/code-coverage.md)
* [Debug NuGet package with included symbols](./docs/guides/debug-pdg-included-on-nuget.md)
* [Share data across the lifetime of an HTTP request](./docs/guides/share-data-with-async-local.md)
* [How to test logging when using Microsoft.Extensions.Logging](./docs/guides/testing-logs.md)

## GitHub Workflows

| Worflow                   |      Status and link      |
|---------------------------|:-------------------------:|
| [all-guides-sln](https://github.com/edumserrano/dot-net-sdk-guides/blob/main/.github/workflows/all-guides-sln.yml)             |  ![Build Status](https://github.com/edumserrano/dot-net-sdk-guides/workflows/Build%20guides%20sln/badge.svg) |

## Building

### Using Visual Studio

1) Clone the repo and open the `DotNet.Guides.sln` solution file.
2) Press build on Visual Studio.

### Using dotnet CLI

1) Clone the repo and browse to the directory using your favorite shell.
2) To build the solution that contains all guides run: **`dotnet build DotNet.Guides.sln`**

### Notes

There are also individual solutions for each of the demo apps for the guides present at the folder level for the demo. Example: `AmbientDataDemo.sln` at `src/guides/ambient-data/AmbientDataDemo`.

## License

This project is licensed under the [MIT license](./LICENSE).
