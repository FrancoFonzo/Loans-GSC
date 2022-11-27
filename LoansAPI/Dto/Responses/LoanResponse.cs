using LoansAPI.Models;

namespace LoansAPI.Dto.Responses
{
    public class LoanResponse
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public ThingViewModel? Thing { get; set; }
        public PersonResponse? Person { get; set; }
    }
}
