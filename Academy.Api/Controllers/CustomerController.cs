using Academy.Api.Helpers;
using Academy.Application.DTOs;
using Academy.Application.Interfaces;
using Academy.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Create(CustomerDTO customerDTO)
        {
            try
            {
                await _customerService.Create(customerDTO);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot create customer", ex));
            }
        }

        [HttpGet("[controller]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error during request", ex));
            }
        }

        [HttpGet("[controller]")]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 20)
        {
            try
            {
                var customers = await _customerService.Get(page, pageSize);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot create customer", ex));
            }
        }

        [HttpPut("[controller]/{id:int}")]
        public async Task<IActionResult> Update(CustomerDTO customerDTO, int id)
        {
            try
            {
                await _customerService.Update(customerDTO, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot update customer", ex));
            }
        }

        [HttpPut("[controller]/{id:int}/inactivate")]
        public async Task<IActionResult> InactivateCustomer(int id)
        {
            try
            {
                await _customerService.UpdateStatus(EStatusCustomer.Inactivate, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot inactivate customer", ex));
            }
        }

        [HttpPut("[controller]/{id:int}/activate")]
        public async Task<IActionResult> ActivateCustomer(int id)
        {
            try
            {
                await _customerService.UpdateStatus(EStatusCustomer.Activate, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot activate customer", ex));
            }
        }
    }
}
