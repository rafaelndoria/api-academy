using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class Plan : Entity
    {
        public Plan()
        {
            
        }
        public Plan(string name, double price, int entriesPerDay, int planTypeId)
        {
            ValidateDomain(name, price, entriesPerDay, planTypeId);

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

        private void ValidateDomain(string name, double price, int entriesPerDay, int planTypeId)
        {
            if (Name != name)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
                DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name must have at least 3 characters");
                DomainExceptionValidation.When(name.Length > 50, "Invalid name. Name must have a maximum of 50 characters");
            }
            if (Price != price)
            {
                DomainExceptionValidation.When(price == 0, "Invalid price. Price is required");
            }
            if (EntriesPerDay != entriesPerDay)
            {
                DomainExceptionValidation.When(entriesPerDay == 0, "Invalid entriesPerDay. EntriesPerDay is required");
            }
            if (PlayTypeId != planTypeId)
            {
                DomainExceptionValidation.When(planTypeId == 0, "Invalid planTypeId. PlanTypeId is required");
            }
        }

        public void Update(string name, double price, int entriesPerDay, int planTypeId)
        {
            ValidateDomain(name, price, entriesPerDay, planTypeId);

            Name = name;
            Price = price;
            EntriesPerDay = entriesPerDay;
            PlayTypeId = planTypeId;
        }
    }
}