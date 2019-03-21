using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_budget_service.Managers;
using api_budget_service.Models;
using Microsoft.AspNetCore.Mvc;


namespace api_budget_service.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetsManager _budgetsManager;

        public BudgetsController(IBudgetsManager budgetsManager)
        {
            _budgetsManager = budgetsManager;
        }

        /// <summary>
        /// Calculates total budget from a start date to n-number of days.
        /// </summary>
        /// <returns>Total budget.</returns>
        /// <param name="request">Any valid date format and an integer</param>
        /// <response code="200">Returns total budget</response>
        /// <response code="400">If request is null or invalid</response>
        /// <response code="500">Server error</response>
        [HttpPost]
        [Route("budgets")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CalculateBudget([FromBody]BudgetsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _budgetsManager.CalculateBudget(request);
                var budget = new BudgetsDTO { Budget = response };

                return Ok(budget);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
