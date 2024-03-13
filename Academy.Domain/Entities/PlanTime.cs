namespace Academy.Domain.Entities
{
    public class PlanTime : Entity
    {
        public PlanTime(string startTime, string endTime, int dayWeek, int playId)
        {
            StartTime = startTime;
            EndTime = endTime;
            DayWeek = dayWeek;
            PlayId = playId;
        }

        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public int DayWeek { get; private set; }

        public int PlayId { get; set; }
        public Plan? Plan { get; set; }
    }
}