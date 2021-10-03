using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly BonusPoolService service;

        public BonusPoolController(BonusPoolService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bonusPoolService = new BonusPoolService();

            return Ok(await bonusPoolService.GetEmployeesAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            var bonusPoolService = new BonusPoolService();
            var employees = new List<int>();
            foreach (var item in service.GetEmployeesAsync().Result)
            {
                employees.Add(item.Id);

            }
            if (employees.Contains(request.SelectedEmployeeId))
            {

                return Ok(await bonusPoolService.CalculateAsync(
                                       request.TotalBonusPoolAmount,
                                       request.SelectedEmployeeId));
            }
            else
            {
                return BadRequest("Employee does not exist");
            }
        }
    }
}

