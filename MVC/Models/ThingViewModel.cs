using MVC.Dto;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ThingViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
