using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
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

            if (request.SelectedEmployeeId.Equals(0)||request.SelectedEmployeeId.CompareTo(12)==1)
            {
                return BadRequest("Employee does not exist");
            }
            else
            {
            return Ok(await bonusPoolService.CalculateAsync(
                request.TotalBonusPoolAmount,
                request.SelectedEmployeeId));

            }

        }
    }
}
