using Academy.Application.DTOs;
using Academy.Application.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Enums;
using Academy.Domain.Interfaces;
using AutoMapper;

namespace Academy.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Create(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.CreateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> Get(int page, int pageSize)
        {
            var customers = await _customerRepository.GetAsync(page, pageSize);
            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer;
        }

        public async Task Update(CustomerDTO customerDTO, int id)
        {
            var customer = await GetById(id);
            if (customer == null)
                throw new Exception("Customers doesnt found");

            customer.Update(customerDTO.Name, customerDTO.PhoneNumber, customerDTO.Email, customerDTO.CPF, customer.PlanId);
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task UpdateStatus(EStatusCustomer type, int id)
        {
            var customer = await GetById(id);
            if (customer == null)
                throw new Exception("Customers doesnt found");

            switch (type)
            {
                case EStatusCustomer.Inactivate:
                    customer.Inactivate();
                    break;
                case EStatusCustomer.Activate:
                    customer.Activate();
                    break;
            }

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
