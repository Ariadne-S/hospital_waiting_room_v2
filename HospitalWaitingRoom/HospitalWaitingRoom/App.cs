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
            Console.WriteLine("{0} started", scenario.Name);
            log.Information("{ScenarioName} started", scenario.Name);
            hospital.AddPendingArrivals(scenario.Arrivals);

            while (hospital.HospitalStatus == HospitalStatus.Open) {
                hospital.PatientsArrivals();
                hospital.FilterPatients();
                hospital.PatientVacate();
                hospital.PatientAdmittance();
                                             
                hospital.AdvanceTime();
            }
                                
            foreach (var record in hospital.History) {
                record.PrintHistory();
            }

            log.Information("Hospital is closed");
            Console.WriteLine("Hospital is closed.");

            return hospital.History;

        }
    }
}
