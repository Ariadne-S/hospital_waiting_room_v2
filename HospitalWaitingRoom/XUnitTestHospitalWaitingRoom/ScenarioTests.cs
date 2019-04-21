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


        [Fact]
        public void Scenario3Test()
        {
            _log.Information("Test3 started");

            var results = App.RunScenario(_log, Scenario.Scenarios[2]);

            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "k", 7),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "l", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "m", 2),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "n", 7),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "o", 6),
                new HospitalHistoryRecord(0, PatientAction.SentHome, "m", 2),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "k", 7),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "n", 7),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "l", 6),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "o", 6),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "p", 6),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "q", 9),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "k", 7),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "n", 7),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "l", 6),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "o", 6),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "q", 9),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "p", 6),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "q", 9),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "p", 6)
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
        public void Scenario4Test()
        {
            _log.Information("Test4 started");

            var results = App.RunScenario(_log, Scenario.Scenarios[3]);

            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "r", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "s", 3),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "t", 7),
                new HospitalHistoryRecord(0, PatientAction.SentHome, "s", 3),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "t", 7),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "r", 6),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "u", 7),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "v", 8),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "w", 4),
                new HospitalHistoryRecord(5, PatientAction.Admitted, "v", 8),
                new HospitalHistoryRecord(5, PatientAction.Admitted, "u", 7),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "t", 7),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "r", 6),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "w", 4),
                new HospitalHistoryRecord(15, PatientAction.Vacated, "v", 8),
                new HospitalHistoryRecord(15, PatientAction.Vacated, "u", 7),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "w", 4)
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
        public void Scenario5Test()
        {
            _log.Information("Test5 started");

            var results = App.RunScenario(_log, Scenario.Scenarios[4]);

            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "x", 8),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "y", 6),
                new HospitalHistoryRecord(0, PatientAction.Arrived, "z", 4),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "x", 8),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "y", 6),
                new HospitalHistoryRecord(0, PatientAction.Admitted, "z", 4),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "aa", 7),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "ab", 4),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "ac", 2),
                new HospitalHistoryRecord(5, PatientAction.Arrived, "ad", 8),
                new HospitalHistoryRecord(5, PatientAction.SentHome, "ac", 2),
                new HospitalHistoryRecord(5, PatientAction.Admitted, "ad", 8),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "x", 8),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "y", 6),
                new HospitalHistoryRecord(10, PatientAction.Vacated, "z", 4),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "aa", 7),
                new HospitalHistoryRecord(10, PatientAction.Admitted, "ab", 4),
                new HospitalHistoryRecord(12, PatientAction.Arrived, "ae", 7),
                new HospitalHistoryRecord(12, PatientAction.Arrived, "af", 3),
                new HospitalHistoryRecord(12, PatientAction.Arrived, "ag", 5),
                new HospitalHistoryRecord(12, PatientAction.Arrived, "ah", 8),
                new HospitalHistoryRecord(12, PatientAction.Arrived, "ai", 2),
                new HospitalHistoryRecord(12, PatientAction.SentHome, "af", 3),
                new HospitalHistoryRecord(12, PatientAction.SentHome, "ai", 2),
                new HospitalHistoryRecord(12, PatientAction.Admitted, "ah", 8),
                new HospitalHistoryRecord(15, PatientAction.Vacated, "ad", 8),
                new HospitalHistoryRecord(15, PatientAction.Admitted, "ae", 7),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "aa", 7),
                new HospitalHistoryRecord(20, PatientAction.Vacated, "ab", 4),
                new HospitalHistoryRecord(20, PatientAction.Admitted, "ag", 5),
                new HospitalHistoryRecord(22, PatientAction.Vacated, "ah", 8),
                new HospitalHistoryRecord(25, PatientAction.Vacated, "ae", 7),
                new HospitalHistoryRecord(30, PatientAction.Vacated, "ag", 5)
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
