using System.ComponentModel.DataAnnotations;

namespace MVC.Dto.Requests
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Description is requiered")]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters")]
        [MaxLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
