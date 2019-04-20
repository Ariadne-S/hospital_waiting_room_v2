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
        public void Scenario1()
        {
            _log.Information("Test1 started");

            var expectations = new List<HospitalHistoryRecord>() {
                new HospitalHistoryRecord(0, PatientAction.Arrived, "a", 6)
            };




            { 'time': 0, 'action': 'Arrived', 'patient_id': 'a', 'severity': 6},
            { 'time': 0, 'action': 'Arrived', 'patient_id': 'b', 'severity': 3},
            { 'time': 0, 'action': 'Arrived', 'patient_id': 'c', 'severity': 5},
            { 'time': 0, 'action': 'Arrived', 'patient_id': 'd', 'severity': 1},
            { 'time': 0, 'action': 'Sent Home', 'patient_id': 'b', 'severity': 3},
            { 'time': 0, 'action': 'Sent Home', 'patient_id': 'd', 'severity': 1},
            { 'time': 0, 'action': 'Admitted', 'patient_id': 'a', 'severity': 6},
            { 'time': 0, 'action': 'Admitted', 'patient_id': 'c', 'severity': 5},
            { 'time': 10, 'action': 'Vacated', 'patient_id': 'a', 'severity': 6},
            { 'time': 10, 'action': 'Vacated', 'patient_id': 'c', 'severity': 5}
        ]

            Assert.Equal(results, expectations);
        }
    }
}
