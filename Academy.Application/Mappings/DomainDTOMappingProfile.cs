using Academy.Application.DTOs;
using Academy.Domain.Entities;
using AutoMapper;

namespace Academy.Application.Mappings
{
    public class DomainDTOMappingProfile : Profile
    {
        public DomainDTOMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
