namespace ExpenseTrackerAPI.Models
{
    public class AddExpensesRq
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Items { get; set; }
        public int CategoryId { get; set; }
    }
}
