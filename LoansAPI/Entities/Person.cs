namespace LoansAPI.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public IList<Loan>? Loans { get; set; }
    }
}
