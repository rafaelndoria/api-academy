using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infra.Context.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanTime> PlanTime { get; set; }
        public DbSet<PlanType> PlanType { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TypePayment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);    
        }
    }
}
