using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto.Responses;
using MVC.Dto.Requests;
using MVC.Services;

namespace MVC.Controllers
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
        public IActionResult Login([FromBody] AuthRequest userRequest)
        {
            var response = new AuthResponse();
            var user = unitOfWork.UsersRepository.Login(userRequest.Username, userRequest.Password);

            if (user is null)
            {
                response.Message = "Incorrect username or password";
                response.Success = false;
                return Unauthorized(response);
            }

            response.Message = "Successfully logged in";
            response.Success = true;
            response.Token = jwtHandler.GenerateToken(userRequest, user!.Role);
            return Ok(response);
        }
    }
}
