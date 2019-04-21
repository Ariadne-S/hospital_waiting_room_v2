using System;
using Serilog;

namespace HospitalWaitingRoom
{
    class Program
    {
        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                //.WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            try {
                Log.Information("Starting app");
                Run(Log.Logger);

                Console.ReadLine();
                return 0;
            } catch (Exception ex) {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            } finally {
                Log.CloseAndFlush();
            }
        }

        private static void Run(ILogger logger)
        {
            Welcome.PrintWelcome();
            App.RunScenario(logger, Scenario.Scenarios[0]);
        }
    }
}
