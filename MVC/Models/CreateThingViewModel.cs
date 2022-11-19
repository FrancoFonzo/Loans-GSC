using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CreateThingViewModel
    {
        [Required(ErrorMessage = "Description is requiered")]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters")]
        [MaxLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is requiered")]
        public int CategoryId { get; set; }
    }
}
