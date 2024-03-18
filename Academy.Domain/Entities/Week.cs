namespace Academy.Domain.Entities
{
    public class Week : Entity
    {
        public Week(string name)
        {
            Name = name;
        }

        public Week(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public IEnumerable<PlanTime> PlanTimes { get; set; } = new List<PlanTime>();
    }
}
