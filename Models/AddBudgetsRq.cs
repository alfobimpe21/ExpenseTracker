namespace ExpenseTrackerAPI.Models
{
    public class AddBudgetsRq
    { 
        public string UserId { get; set; }
        public decimal Salary { get; set; }
        public string SalaryMonth { get; set; } 
        public string SalaryPercentage { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }

    }
}
