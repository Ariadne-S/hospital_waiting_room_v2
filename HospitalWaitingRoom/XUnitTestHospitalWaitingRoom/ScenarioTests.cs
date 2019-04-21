using System;
using Xunit;
using HospitalWaitingRoom;
using Serilog;
using System.Collections.Generic;

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
        public void Scenario1Test()
        {
            _log.Information("Test1 started");

            var results = App.RunScenario(_log, Scenario.Scenarios[0]);
            
            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "a", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "b", 3),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "c", 5),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "d", 1),
                new HospitalHistoryRecord(0, PatientAction.SentHome, "b", 3),
                new HospitalHistoryRecord(0, PatientAction.SentHome, "d", 1),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "a", 6),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "c", 5),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "a", 6),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "c", 5)
            };

            Assert.Equal(results, expectations);
        }
    }
}
