using MVC.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Description is requiered")]
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
        [MaxLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string Description { get; set; }
    }
}
