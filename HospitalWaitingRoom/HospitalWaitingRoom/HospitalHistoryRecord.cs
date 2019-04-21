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

    }
}
