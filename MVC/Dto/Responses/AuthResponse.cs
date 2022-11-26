namespace MVC.Dto.Responses
{
    public class AuthResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;


    }
}
