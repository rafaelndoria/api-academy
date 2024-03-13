namespace Academy.Domain.Entities
{
    public class Entry : Entity
    {
        public Entry(DateTime date, string timeIn, int customerId)
        {
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
                var timeIn = DateTime.Parse(TimeIn);
                var timeOn = DateTime.Parse(timeOnInput);

                if (timeOn < timeIn)
                {
                    throw new Exception("TimeOn cannot be less than TimeIn");
                }
            }
            catch
            {
                throw new Exception("Invalid time format");
            }
        }
    }
}