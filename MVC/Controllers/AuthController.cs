using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Dto.Requests;
using MVC.Services;

namespace MVC.Controllers
{
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
                ModelState.AddModelError("login_error", "Incorrect username or password");

            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.FirstOrDefault(X => X.Errors.Count > 0)?.Errors.FirstOrDefault(x => x.ErrorMessage != null)?.ErrorMessage;
                response.Message = message!;
                response.Success = false;
                return Unauthorized(response);
            }

            response.Message = "Success";
            response.Success = true;
            response.Token = jwtHandler.GenerateToken(userRequest, user!.Role);
            return Ok(response);
        }
    }
}
