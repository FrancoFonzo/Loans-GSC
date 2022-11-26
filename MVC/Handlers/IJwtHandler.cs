using MVC.Dto;
using MVC.Entities;

namespace MVC.Services
{
    public interface IJwtHandler
    {
        string GenerateToken(AuthRequest userLoginRequest, Role roles);
    }
}
