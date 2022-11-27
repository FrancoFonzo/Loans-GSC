namespace LoansAPI.Entities
{
    public class Thing : EntityBase
    {
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public IList<Loan>? Loans { get; set; }
    }
}
