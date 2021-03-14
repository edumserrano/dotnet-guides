using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit;

namespace TestingLogsWithSerilogDemo.Tests
{
    // Demo how to test using a default WebApplicationFactory<T> implementation
    // See https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0#basic-tests-with-the-default-webapplicationfactory

    // Make sure that tests for your logs that are using Serilog do NOT run in parallel or else you will
    // get incorrect results. This is because the Serilog logger is setup on a static global property.
    // For xUnit tests this can be done with the 'Collection' attribute
    [Collection("Test Collection #1")]
    public class DemoTests1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;

        public DemoTests1(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSerilogTestLogging(options =>
                    {
                        // you can enable filters for your tests
                        // options.FilterByNamespace(nameof(TestingLogsWithSerilogDemo));
                    });
                }); ;
        }

        [Fact]
        public async Task Test1()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("/WeatherForecast");
            var testLoggerSink = _webApplicationFactory.GetSerilogTestLoggerSink();
            var logEntry = testLoggerSink.LogEntries.FirstOrDefault(x => x.LoggerName == "TestingLogsWithSerilogDemo.Controllers.WeatherForecastController");
            logEntry.ShouldNotBeNull();
            logEntry.Message.ShouldBe("test message from \"WeatherForecastController\"");
            logEntry.Properties.ShouldContain(x => 
                x.Key == "controller" &&
                x.Value.ToString() != null && 
                x.Value.ToString()!.Equals("WeatherForecastController", StringComparison.OrdinalIgnoreCase));
            logEntry.Properties.ShouldContain(x => x.Key == "MachineName");
        }
    }
}
