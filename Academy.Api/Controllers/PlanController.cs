using Academy.Api.Helpers;
using Academy.Application.DTOs;
using Academy.Application.Interfaces;
using Academy.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Create(PlanDTO planDTO)
        {
            try
            {
                await _planService.Create(planDTO);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot create plan", ex));
            }
        }

        [HttpPut("[controller]/{id:int}")]
        public async Task<IActionResult> Update(PlanDTO plan, int id)
        {
            try
            {
                await _planService.Update(plan, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Cannot update plan", ex));
            }
        }

        [HttpGet("[controller]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var plan = await _planService.GetById(id);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }

        [HttpGet("[controller]")]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 20)
        {
            try
            {
                var plans = await _planService.Get(page, pageSize);
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }

        [HttpPut("[controller]/inactivate/{id:int}")]
        public async Task<IActionResult> Inactivate(int id)
        {
            try
            {
                await _planService.UpdateStatus(EStatusCustomer.Inactivate, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }

        [HttpPut("[controller]/activate/{id:int}")]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                await _planService.UpdateStatus(EStatusCustomer.Activate, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }

        [HttpGet("[controller]/active")]
        public async Task<IActionResult> GetPlansActive(int page = 1, int pageSize = 20)
        {
            try
            {
                var plans = await _planService.Get(page, pageSize, EStatusCustomer.Activate);
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }

        [HttpGet("[controller]/inative")]
        public async Task<IActionResult> GetPlansInative(int page = 1, int pageSize = 20)
        {
            try
            {
                var plans = await _planService.Get(page, pageSize, EStatusCustomer.Inactivate);
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return BadRequest(CustomExceptionMessageHelper.ExceptionMessage("Error durant request", ex));
            }
        }
    }
}
