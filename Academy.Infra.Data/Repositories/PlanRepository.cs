using Academy.Domain.Entities;
using Academy.Domain.Enums;
using Academy.Domain.Interfaces;
using Academy.Infra.Context.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infra.Data.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public PlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Plan plan)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Plan>> GetAsync(int page = 1, int pageSize = 20, EStatusCustomer? type = null)
        {
            IQueryable<Plan> query = _context.Plans
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            if (type != null)
            {
                var isActive = type == EStatusCustomer.Activate;
                query = query.Where(x => x.Active == isActive);
            }

            var plans = await query.ToListAsync();
            return plans;
        }

        public async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Plans
                .Include(x => x.PlanTimes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Plan plan)
        {
            _context.Plans.Update(plan);
            await _context.SaveChangesAsync();
        }
    }
}
