using HospitalWaitingRoom;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalWaitingRoom
{
    public class Hospital
    {
        private List<Patient> _arrivals;
        private List<Patient> _waiting;
        private List<Bed> _beds;
        private int _time;

        private List<HospitalHistoryRecord> _history = new List<HospitalHistoryRecord>();
        private readonly ILogger _log;

        public Hospital(ILogger log, int numberOfBeds, int maxTime)
        {
            _arrivals = new List<Patient>();
            _waiting = new List<Patient>();
            _beds = new List<Bed>(Enumerable.Range(0, numberOfBeds).Select(x => new Bed(maxTime)));
            _time = 0;
            _log = log;
        }
                             
        public HospitalStatus HospitalStatus {
            get {
                if (_time > 50) {
                    _log.Error("Forcing Hospital Closed.");
                    return HospitalStatus.Closed;
                }
                else if (_arrivals.Any() || _waiting.Any() || _beds.Any(b => b.BedStatus == BedStatus.Filled)) {
                    return HospitalStatus.Open;
                }
                else return HospitalStatus.Closed;
            }
            
        }

        public List<HospitalHistoryRecord> History { get => _history; }

        public void AdvanceTime() {

            if (HospitalStatus == HospitalStatus.Open) {
                _time += 1;
            } 

            _log.Information("Advancing Hospital time {Time}",_time);
            foreach (var bed in _beds) {
                bed.BedsAdvanceTime(_log);
            }

        }

        public void AddPendingArrivals(IEnumerable<Patient> patients)
        {
            _arrivals.AddRange(patients);
            _log.Information("Pending Arrivals moved to _arrival list");
            _log.Information("_arrivals List: {Arrivals}", _arrivals);
        }

        public void PatientsArrivals()
        {
            _log.Information("Checking if patients have arrived");            

            foreach (var patient in _arrivals.ToList()) {
                if (patient.ArrivedTime >= _time) {
                    _waiting.Add(patient);
                    _history.Add(new HospitalHistoryRecord(_time, PatientAction.Admitted, patient.Id, patient.Severity));
                    _arrivals.Remove(patient);
                    _log.Information("Patient {PatientId} has arrived", patient.Id);
                }
            }
        }

        public void FilterPatients()
        {
            _log.Information("Checking if low severity patients need to be sent home");

            var Patientfilter = _waiting.ToList();

            foreach (var patient in Patientfilter) {
                if (patient.Severity < 4 ) {
                    _history.Add(new HospitalHistoryRecord(_time, PatientAction.SentHome, patient.Id, patient.Severity));
                    _waiting.Remove(patient);
                    _log.Information("Patient {PatientId} has been sent home", patient.Id);
                }
            }
        }

        public void PatientAdmittance()
        {
            _log.Information("Trying to admit more patients");

            var PatiendAdmit = _waiting.ToList();
            var sortedPatients = PatiendAdmit.OrderBy(p => p.Severity);

            foreach (var patient in sortedPatients) {
                foreach (var bed in _beds) {
                    if (bed.Admit(patient)) {
                        _history.Add(new HospitalHistoryRecord(_time, PatientAction.Admitted, patient.Id, patient.Severity));
                        _waiting.Remove(patient);
                        _log.Information("Patient {PatientId} has been admitted", patient.Id);
                        break;
                    }
                }
            }
        }
        

        public void PatientVacate()
        {
            _log.Information("Try to vacate patient");

            foreach (var bed in _beds ) {
                var patient = bed.Vacate();
                if (patient != null) {
                    _history.Add(new HospitalHistoryRecord(_time, PatientAction.Vacated, patient.Id, patient.Severity));
                    _log.Information("Patient {PatientId} Vacated from bed", patient.Id);
                }
            }
        }

    }
}
