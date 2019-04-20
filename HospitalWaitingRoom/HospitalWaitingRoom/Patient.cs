using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalWaitingRoom
{
    public class Patient
    {
        public Patient(string id, int severity, int arrivedTime)
        {
            Id = id;
            Severity = severity;
            ArrivedTime = arrivedTime;
        }

        public string Id { get; }
        public int Severity { get; }
        public int ArrivedTime { get; }
    }
}
