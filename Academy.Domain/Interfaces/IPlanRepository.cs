using Academy.Domain.Entities;
using Academy.Domain.Enums;

namespace Academy.Domain.Interfaces
{
    public interface IPlanRepository
    {
        Task CreateAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task<Plan> GetByIdAsync(int id);
        Task<IEnumerable<Plan>> GetAsync(int page = 1, int pageSize = 20, EStatusCustomer? type = null);  
    }
}
