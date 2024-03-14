namespace Academy.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            
        }
        public Customer(string name, string phoneNumber, string email, string cpf, int planId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            CPF = cpf;
            PlanId = planId;

            Active = true;
            DateCreated = DateTime.Now;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int PlanId { get; set; }
        public Plan? Plan { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public IEnumerable<Entry> Entries { get; set; } = new List<Entry>();

        public void Invactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }
    }
}