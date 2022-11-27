using System.ComponentModel.DataAnnotations;

namespace LoansAPI.Dto.Requests
{
    public class PersonRequest
    {
        [Required(ErrorMessage = "Name is requiered")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is requiered")]
        [MaxLength(20, ErrorMessage = "Phone number can't be longer than 20 characters")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is requiered")]
        [MaxLength(120, ErrorMessage = "Email can't be longer than 120 characters")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = string.Empty;
    }
}
