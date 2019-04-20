﻿namespace HospitalWaitingRoom
{
    public class Bed
    {
        private readonly int _maxTime;
        private Patient _patient;
        private int _time;

        public Bed(int maxTime)
        {
            _maxTime = maxTime;
        }

        public BedStatus BedStatus {
            get {
                return _patient == null ? BedStatus.Empty : BedStatus.Filled;
            }
        }

        public bool Admit(Patient patient)
        {
            if (BedStatus == BedStatus.Empty) {
                _patient = patient;
                _time = 0;
                return true;
            }
            return false;
        }

        public void AdvanceTime()
        {
            _time += 1;
        }

        public Patient Vacate()
        {
            if (_time > _maxTime) {
                var p = _patient;
                _patient = null;
                return p;
            }
            return null;
        }

    }
}
