namespace Academy.Domain.Entities
{
    public class PlanType : Entity
    {
        public PlanType(string name, int period)
        {
            Name = name;
            Period = period;
        }
        
        public PlanType(int id, string name, int period)
        {
            Id = id;
            Name = name;
            Period = period;
        }

        public string Name { get; private set; }
        public int Period { get; private set; }

        public IEnumerable<Plan> Plans { get; set; } = new List<Plan>();
    }
}