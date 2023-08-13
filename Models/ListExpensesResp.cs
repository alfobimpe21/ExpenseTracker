namespace ExpenseTrackerAPI.Models
{
    public class ListExpensesResp
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Items { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
