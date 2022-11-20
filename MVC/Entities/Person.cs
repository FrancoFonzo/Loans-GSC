using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MVC.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IList<Loan> Loans { get; set; }
    }
}
