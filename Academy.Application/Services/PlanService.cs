using Academy.Application.DTOs;
using Academy.Application.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Enums;
using Academy.Domain.Interfaces;
using AutoMapper;

namespace Academy.Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanService(IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task Create(PlanDTO planDTO)
        {
            var plan = _mapper.Map<Plan>(planDTO);
            await _planRepository.CreateAsync(plan);
        }

        public async Task<IEnumerable<Plan>> Get(int page = 1, int pageSize = 20, EStatusCustomer? type = null)
        {
            var plans = await _planRepository.GetAsync(page, pageSize, type);
            return plans;
        }

        public async Task<Plan> GetById(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            return plan;
        }

        public async Task Update(PlanDTO planDTO, int id)
        {
            var plan = await GetById(id);
            if (plan == null)
                throw new Exception("Plan doesnt found");

            plan.Update(planDTO.Name, planDTO.Price, planDTO.EntriesPerDay, planDTO.PlanTypeId);
            await _planRepository.UpdateAsync(plan);
        }

        public async Task UpdateStatus(EStatusCustomer type, int id)
        {
            var plan = await GetById(id);
            if (plan == null)
                throw new Exception("Plan doesnt found");

            switch (type)
            {
                case EStatusCustomer.Inactivate:
                    plan.Inactivate();
                    break;
                case EStatusCustomer.Activate:
                    plan.Activate();
                    break;
            }

            await _planRepository.UpdateAsync(plan);
        }
    }
}
