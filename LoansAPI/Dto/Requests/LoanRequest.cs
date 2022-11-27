using System.ComponentModel.DataAnnotations;

namespace LoansAPI.Dto.Requests
{
    public class LoanRequest
    {
        [Required(ErrorMessage = "Thing is requiered")]
        public int ThingId { get; set; }

        [Required(ErrorMessage = "Person is requiered")]
        public int PersonId { get; set; }
    }
}
