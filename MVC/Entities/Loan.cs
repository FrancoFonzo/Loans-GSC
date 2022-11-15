namespace MVC.Entities
{
    public class Loan : EntityBase
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Thing Thing { get; set; }
        public Person Person { get; set; }
    }
}
