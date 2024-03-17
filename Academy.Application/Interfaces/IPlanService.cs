using Academy.Application.DTOs;
using Academy.Domain.Entities;
using Academy.Domain.Enums;

namespace Academy.Application.Interfaces
{
    public interface IPlanService
    {
        Task Create(PlanDTO planDTO);
        Task Update(PlanDTO planDTO, int id);
        Task<Plan> GetById(int id);
        Task<IEnumerable<Plan>> Get(int page = 1, int pageSize = 20, EStatusCustomer? type = null);
        Task UpdateStatus(EStatusCustomer type, int id);
    }
}
