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

        public Hospital(int numberOfBeds, int maxTime)
        {
            _arrivals = new List<Patient>();
            _arrivals = new List<Patient>();
            _beds = new List<Bed>(Enumerable.Range(0, numberOfBeds).Select(x => new Bed(maxTime)));
            _time = 0;
        }





        public HospitalStatus HospitalStatus {
            get {
                return HospitalStatus.Open;
            }
        }
    }
}
