namespace Academy.Domain.Entities
{
    public class PlanType : Entity
    {
        public PlanType(string name)
        {
            Name = name;
        }
        
        public PlanType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
        
        public IEnumerable<Plan> Plans { get; set; } = new List<Plan>();
    }
}