using LoansAPI.Dto.Responses;

namespace LoansAPI.Models
{
    public class ThingViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public CategoryResponse? Category { get; set; }
    }
}
