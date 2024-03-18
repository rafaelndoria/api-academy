using System.Globalization;
using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class PlanTime : Entity
    {
        public PlanTime(string startTime, string endTime, int planId)
        {
            ValidateDomain(startTime, endTime, planId);

            StartTime = startTime;
            EndTime = endTime;
            PlanId = planId;
        }

        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public int WeekId { get; set; }
        public Week? Week { get; set; }
        public int PlanId { get; set; }
        public Plan? Plan { get; set; }

        private void ValidateDomain(string startTime, string endTime, int planId)
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
            if (PlanId != planId || planId <= 0)
            {
                DomainExceptionValidation.When(planId <= 0, "Invalid playId. PlayId is required");
            }
        }

        public void Update(string startTime, string endTime)
        {
            ValidateDomain(startTime, endTime, PlanId);

            StartTime = startTime;
            EndTime = endTime;
        }
    }
}