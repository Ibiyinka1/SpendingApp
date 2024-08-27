namespace SPENDINGAPP.backend.Models
{
    public class Income
    {
        public int IncomeId { get; set; } // Primary Key
        public string? Title { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = "income";
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}


