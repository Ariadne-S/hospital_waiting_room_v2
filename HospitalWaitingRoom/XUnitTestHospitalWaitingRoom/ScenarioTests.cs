using System;
using System.Linq;
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
                .MinimumLevel.Information()
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

            foreach (var (expected, actual) in expectations.Zip(results, (a, b) => (a, b))) {

                if (expected.Equals(actual)) {
                    _log.Information("{@Expected} == {@Actual}", expected, actual);
                } else {
                    _log.Information("{@Expected} != {@Actual}", expected, actual);
                }

            }

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void Scenario2Test()
        {
            _log.Information("Test2 started");

            var results = App.RunScenario(_log, Scenario.Scenarios[1]);

            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "e", 7),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "f", 3),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "g", 8),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "h", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "i", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "j", 5),
                new HospitalHistoryRecord(0, PatientAction.SentHome, "f", 3),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "g", 8),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "e", 7),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "h", 6),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "i", 6),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "g", 8),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "e", 7),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "h", 6),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "i", 6),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "j", 5),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "j", 5)
            };

            foreach (var (expected, actual) in expectations.Zip(results, (a, b) => (a, b))) {

                if (expected.Equals(actual)) {
                    _log.Information("{@Expected} == {@Actual}", expected, actual);
                } else {
                    _log.Information("{@Expected} != {@Actual}", expected, actual);
                }

            }

            Assert.Equal(expectations, results);
        }
    }
}
