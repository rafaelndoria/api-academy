using Academy.Domain.Entities;

namespace Academy.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAsync(int page, int pageSize);
        Task UpdateAsync(Customer customer);
    }
}
