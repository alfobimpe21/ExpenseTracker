namespace ExpenseTrackerAPI.Models
{
    public class ListCategoryResp
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
