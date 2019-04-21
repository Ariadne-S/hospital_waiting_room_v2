using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalWaitingRoom
{
    public static class App
    {
        public static List<HospitalHistoryRecord> RunScenario(ILogger log, Scenario scenario) {
            var hospital = new Hospital(log, 4, 10);
            // Print name
            log.Information("{ScenarioName} started", scenario.Name);
            hospital.AddPendingArrivals(scenario.Arrivals);

            while (hospital.HospitalStatus == HospitalStatus.Open) {
                hospital.PatientsArrivals();
                hospital.FilterPatients();
                hospital.PatientAdmittance();
                hospital.PatientVacate();
                                             
                hospital.AdvanceTime();
            }

            // return total hospital history.
            return hospital.History;
        }
    }
}
