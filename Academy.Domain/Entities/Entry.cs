using System.Globalization;
using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class Entry : Entity
    {
        public Entry(DateTime date, string timeIn, int customerId)
        {
            ValidateDomain(date, timeIn, customerId);
            
            Date = date;
            TimeIn = timeIn;
            CustomerId = customerId;
        }

        public DateTime Date { get; private set; }
        public string TimeIn { get; private set; }
        public string? TimeOn { get; private set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public void SetTimeOn(string timeOn)
        {
            ValidateEntry(timeOn);
            TimeOn = timeOn;
        }

        private void ValidateEntry(string timeOnInput)
        {
            try
            {
                if (!DateTime.TryParse(timeOnInput, out var timeOn))
                {
                    throw new Exception("Invalid time format");
                }

                var timeIn = DateTime.Parse(TimeIn);
                if (timeOn < timeIn)
                {
                    throw new Exception("TimeOn cannot be less than TimeIn");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Validation failed: " + ex.Message);
            }
        }

        private void ValidateDomain(DateTime date, string timeIn, int customerId)
        {
            DomainExceptionValidation.When(date == null || date == DateTime.MinValue, "Invalid date. Date is required");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(timeIn), "Invalid timeIn. TimeIn is required");
            DateTime timeInDateTime;
            DomainExceptionValidation.When(!DateTime.TryParseExact(timeIn, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeInDateTime), "Invalid timeIn. TimeIn must be in the format HH:mm");

            DomainExceptionValidation.When(customerId == 0, "Invalid customerId. CustomerId is required");
        }
    }
}