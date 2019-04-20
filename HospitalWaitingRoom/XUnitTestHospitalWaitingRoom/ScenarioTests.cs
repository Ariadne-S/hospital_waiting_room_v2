using System;
using Xunit;
using HospitalWaitingRoom;
using Serilog;

namespace XUnitTestHospitalWaitingRoom
{
    public class ScenarioTests
    {
        private readonly ILogger _log;

        public ScenarioTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Sink(new TestSink(output))
                .CreateLogger();
        }

        [Fact]
        public void Test1()
        {
            _log.Information("Test1 started");
        }
    }
}
