using LoansAPI.Dto.Requests;
using LoansAPI.Entities;

namespace LoansAPI.Services
{
    public interface IJwtHandler
    {
        string GenerateToken(AuthRequest userLoginRequest, Role roles);
    }
}
