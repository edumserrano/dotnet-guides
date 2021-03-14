# Testing logs with Serilog

This project contains a demo app for the [How to test logging when using Microsoft.Extensions.Logging](../../../../docs/guides/testing-logs.md) guide.

This app is an ASP.NET web api and a test project that shows how to use [MELT](https://github.com/alefranz/MELT) and [Serilog](https://github.com/serilog/serilog-aspnetcore) to test logging in integration tests.

## How to run

* Open the `TestingLogsWithSerilog.sln` which can be found at `src/guides/serilog/TestingLogsWithSerilog`.
* Run the tests. Both tests should pass.

## Notes

* [`SerilogConfigurationExtensions.cs`](../../../../src/guides/serilog/TestingLogsWithSerilog/TestingLogsWithSerilogDemo/SerilogConfigurationExtensions.cs) shows an example setup of the Serilog logger. This is used on the [`Program.cs`](../../../../src/guides/serilog/TestingLogsWithSerilog/TestingLogsWithSerilogDemo/Program.cs) as part of building the `IHostBuilder`.
* The [`DemoTests1.cs`](../../../../src/guides/serilog/TestingLogsWithSerilog/TestingLogsWithSerilogDemo.Tests/DemoTests1.cs) test shows how to do test your logging in integration tests when using Serilog as your logging framework. The [`DemoTests2.cs`](../../../../src/guides/serilog/TestingLogsWithSerilog/TestingLogsWithSerilogDemo.Tests/DemoTests2.cs) test is the same as `DemoTest1` but it uses a custom `WebApplicationFactory`, which is something you might require depending on your scenario.
* The tests in `DemoTest1` and `DemoTest2` can **NOT** run in parallel. This is because the Serilog logger is setup on a static global property. That's why both test classes are marked with a `Collection` attribute. In xUnit that's how you control the [parallelism of running tests](https://xunit.net/docs/running-tests-in-parallel).
