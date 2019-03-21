using System;
using System.Threading.Tasks;
using api_budget_service.Models;

namespace api_budget_service.Managers
{
    public interface IBudgetsManager
    {
        Task<decimal> CalculateBudget(BudgetsRequest request);
    }
}
