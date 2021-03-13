# How to test logging when using Microsoft.Extensions.Logging

## Motivation

I want to be able to do integration tests as defined in [introduction to integration tests](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?#introduction-to-integration-tests) and then assert the log messages produced.

The problem with testing the `ILogger` interface is that in itself it's a very small interface and most of the methods you use are actually extension methods. This makes it harder to mock/substitute on your tests.

You can research online and you will find many articles on this subject such as:

* [Log[Severity] Extension Methods Make Unit Testing Logging Behavior Difficult](https://github.com/aspnet/Logging/issues/611)
* [How to test logging when using Microsoft.Extensions.Logging](https://alessio.franceschelli.me/posts/dotnet/how-to-test-logging-when-using-microsoft-extensions-logging/)
* [Tips & tricks for unit testing in .NET Core 3: Checking matching and non matching arguments on ILogger](https://anthonygiretti.com/2020/02/05/tips-tricks-for-unit-testing-in-net-core-3-checking-matching-and-non-matching-arguments-on-ilogger/)

## How to

For now I believe that using [MELT](https://github.com/alefranz/MELT) is the best approach to take.

From MELT's README:

> MELT is a free, open-source, testing library for the .NET Standard _Microsoft Extensions Logging_ library. It is a solution to easily test logs.

> It is a repackaging with a sweetened API and some omissions of [Microsoft.Extensions.Logging.Testing](https://github.com/aspnet/Extensions/tree/master/src/Logging/Logging.Testing), a library used internally in [ASP.NET Core](https://github.com/aspnet/AspNetCore) for testing the logging, given that [there is currently no plan to offer an official package for it](https://github.com/aspnet/Extensions/issues/672#issuecomment-532850535).

MELT will work for unit tests and integration tests. It also integrates with popular logging frameworks such as Serilog and NLog.

See METL's README to understand how to configure it for [unit tests](https://github.com/alefranz/MELT#quickstart) and for [integration tests](https://github.com/alefranz/MELT#quickstart-for-aspnet-core-integration-tests)