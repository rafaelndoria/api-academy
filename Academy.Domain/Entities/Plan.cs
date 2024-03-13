namespace Academy.Domain.Entities
{
    public class Plan : Entity
    {
        public Plan(string name, double price, int entriesPerDay, int planTypeId)
        {
            Name = name;
            Price = price;
            EntriesPerDay = entriesPerDay;
            PlayTypeId = planTypeId;

            DateCreated = DateTime.Now;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public int EntriesPerDay { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int PlayTypeId { get; set; }
        public PlanType? PlanType { get; set; }
        public IEnumerable<PlanTime> PlanTimes { get; set; } = new List<PlanTime>();
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}