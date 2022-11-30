using Microsoft.AspNetCore.Mvc;
using LoansAPI.DataAccess;
using LoansAPI.Dto.Responses;
using LoansAPI.Dto.Requests;
using LoansAPI.Services;

namespace LoansAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtHandler jwtHandler;
        private readonly IUnitOfWork unitOfWork;

        public AuthController(IJwtHandler jwtHandler, IUnitOfWork unitOfWork)
        {
            this.jwtHandler = jwtHandler;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var user = unitOfWork.UsersRepository.Login(request.Username, request.Password);

            if (user is null)
            {
                return Unauthorized("Incorrect username or password");
            }

            var response = new AuthResponse
            {
                Token = jwtHandler.GenerateToken(request, user.Role)
            };
            
            return Ok(response);
        }
    }
}
