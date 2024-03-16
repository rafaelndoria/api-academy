using Academy.Application.DTOs;
using Academy.Domain.Entities;
using Academy.Domain.Enums;

namespace Academy.Application.Interfaces
{
    public interface ICustomerService
    {
        Task Create(CustomerDTO customerDTO);
        Task<Customer> GetById(int id);
        Task<IEnumerable<Customer>> Get(int page, int pageSize);
        Task Update(CustomerDTO customerDTO, int id);
        Task UpdateStatus(EStatusCustomer type, int id);
    }
}
