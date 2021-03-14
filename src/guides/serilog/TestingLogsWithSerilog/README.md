# TestingLogsWithSerilog readme

This project contains a demo app for the [How to test logging when using Microsoft.Extensions.Logging](../../../../docs/guides/testing-logs.md) guide.

This app is an ASP.NET web api and a test project that shows how to use [MELT](https://github.com/alefranz/MELT) and [Serilog](https://github.com/serilog/serilog-aspnetcore) to test logging in integration tests.

## How to run

* Open the `TestingLogsWithSerilog.sln` which can be found at `src/guides/serilog/TestingLogsWithSerilog`.
* Run the tests. Both tests should pass.

## Notes

* [`SerilogConfigurationExtensions.cs`](../../../../src/guides/serilog/TestingLogsWithSerilog/TestingLogsWithSerilogDemo/SerilogConfigurationExtensions.cs)

