using System;
using System.ComponentModel.DataAnnotations;

namespace api_budget_service.Models
{
    public class BudgetsRequest
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
    }
}
