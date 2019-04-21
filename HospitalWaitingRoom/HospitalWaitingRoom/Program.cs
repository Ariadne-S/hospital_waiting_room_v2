using System;
using System.Linq;
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
            var senarios = Scenario.Scenarios.ToList();
            while (true) {
                var command = Welcome.ScenarioOptions();
                if (command is Exit) {
                    return;
                } else if (command is RunScenario run) {
                    App.RunScenario(logger, senarios[run.Senario - 1]);
                } else if (command is BuildScenario Build) {
                    var result = ScenarioBuilder.BuildScenario(logger);
                    if (result is ExitApp) {
                        return;
                    } else if (result is AddScenario add) {
                        senarios.Add(add.NewScenario);
                    }
                }
            }
        }
    }
}
