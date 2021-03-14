using System;
using System.Diagnostics;
using Destructurama;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

namespace TestingLogsWithSerilogDemo
{
    public static class SerilogConfigurationExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            // The if DEBUG condition is a way to make sure the 'writeToProviders: true' option
            // is only set when running tests. The 'if DEBUG' condition could be changed as long
            // as it only evaluates true when running tests.
            // 
            // The reasoning behind this is that we only need to write to providers when running
            // tests so that we can then assert on the logs.
            // When running in production we will be running in release mode and thus not writing to providers.
            // Although I did not measure if writing to providers would have a performance impact,
            // I did this example like this because of a note from https://github.com/serilog/serilog-aspnetcore README
            // which says:
            //
            // 'By default, Serilog ignores providers, since there are usually equivalent Serilog sinks available,
            //  and these work more efficiently with Serilog's pipeline. If provider support is needed,
            //  it can be optionally enabled.'
            //
            // It's up to you whether you think this 'if DEBUG' is worth it.
            //
#if DEBUG   
            return hostBuilder.UseSerilog(ConfigureLogger, writeToProviders: true);
#endif
#pragma warning disable 162 // disable unreachable code warning
            return hostBuilder.UseSerilog(ConfigureLogger);
#pragma warning restore 162
        }

        private static void ConfigureLogger(HostBuilderContext hostBuilderContext, LoggerConfiguration loggerConfiguration)
        {
            if (Debugger.IsAttached)
            {
                // allow serilog warnings to show when running in debug
                // see https://github.com/serilog/serilog/wiki/Debugging-and-Diagnostics
                // if you're having issues with serilog in some environments (sandbox/uat/prod) consider enabling this
                Serilog.Debugging.SelfLog.Enable(Console.Error);
            }

            // setup your serilog logger configuration
            // the configuration below is just an example, you should configure it as it fits your use case
            var jsonValueFormatter = new JsonValueFormatter(typeTagName: null); //passing null removes $type from being added to all serialized objects
            var jsonFormatter = new CompactJsonFormatter(jsonValueFormatter);
            var exceptionDetailsDeconstructorers = new DestructuringOptionsBuilder().WithDefaultDestructurers();
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration)
                .Destructure.UsingAttributes()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails(exceptionDetailsDeconstructorers)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .WriteTo.Console(jsonFormatter);
        }
    }
}
