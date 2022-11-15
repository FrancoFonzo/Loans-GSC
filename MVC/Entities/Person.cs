using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MVC.Entities
{
    public class Person : EntityBase
    {
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String? Email { get; set; }
    }
}
