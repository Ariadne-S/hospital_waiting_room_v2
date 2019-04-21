using System;

namespace HospitalWaitingRoom
{
    public class HospitalHistoryRecord
    {
        public HospitalHistoryRecord(int time, PatientAction action, string id, int severity)
        {
            Time = time;
            Action = action;
            Id = id;
            Severity = severity;
        }

        public int Time { get; }
        public PatientAction Action { get; }
        public string Id { get; }
        public int Severity { get; }

        public (int Hours, int Minutes) ConvertTime()
        {
            var hours = Time / 60;
            var minutes = Time % 60;
            return (hours, minutes);
        }

        public void PrintHistory()
        {
            var (hours, minutes) = ConvertTime();
            Console.WriteLine("{0:d2}:{1:d2}\t[{2}]\tPaitent {3} with a severity of {4}",hours, minutes, Action, Id, Severity);
        }

        public override bool Equals(object obj)
        {
            if (obj is HospitalHistoryRecord r) {
                return (
                    this.Time == r.Time
                    && this.Id == r.Id
                    && this.Action == r.Action
                    && this.Severity == r.Severity
                );
            }
            return false;
        }

    }
}
