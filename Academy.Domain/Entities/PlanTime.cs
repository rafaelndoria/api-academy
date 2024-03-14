using System.Globalization;
using Academy.Domain.Validations;

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

        private void ValidateDomain(string startTime, string endTime, int dayWeek, int playId)
        {
            var initialTime = "";
            if (StartTime != startTime)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(startTime), "Invalid startTime. StartTime is required");
                DateTime timeInDateTime;
                DomainExceptionValidation.When(!DateTime.TryParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeInDateTime), "Invalid intial time. Start time must be in the format HH:mm");
                initialTime = startTime;
            }
            if (EndTime != endTime)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(endTime), "Invalid endTime. EndTime is required");
                DateTime timeInDateTime;
                DomainExceptionValidation.When(!DateTime.TryParseExact(endTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeInDateTime), "Invalid end time. End time must be in the format HH:mm");

                if (initialTime != "")
                {
                    var initialTimeDateTime = DateTime.Parse(initialTime);
                    var endTimeDateTime = DateTime.Parse(endTime);
                    DomainExceptionValidation.When(endTimeDateTime < initialTimeDateTime, "Invalid end time. End time cannot be less than start time");
                }
            }
            if (DayWeek != dayWeek)
            {
                DomainExceptionValidation.When(dayWeek <= 0, "Invalid dayWeek. DayWeek is required");
            }
            if (PlayId != playId)
            {
                DomainExceptionValidation.When(playId <= 0, "Invalid playId. PlayId is required");
            }
        }
    }
}