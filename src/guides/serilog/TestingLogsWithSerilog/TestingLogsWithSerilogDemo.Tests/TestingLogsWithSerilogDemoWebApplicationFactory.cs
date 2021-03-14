using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace TestingLogsWithSerilogDemo.Tests
{
    public class TestingLogsWithSerilogDemoWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(".")
                .UseStartup<Startup>();
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            // In here you should call the method that in your application is building the IHostBuilder
            // that's why here we return the method defined by Program.CreateHostBuilder
            // 
            // You do NOT have to do it like this but this just makes sure that the configuration you
            // have set on the IHostBuilder, such as configuration related to Serilog for instance,
            // is also used on the test. Alternatively you could duplicate that configuration here
            // but that seems to me as a worst choice.
            return Program.CreateHostBuilder(Array.Empty<string>());
        }
    }
}