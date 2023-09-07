namespace ExpenseTrackerAPI.Models
{
    public class ListBudgetResp
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Salary { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryPercentage { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
