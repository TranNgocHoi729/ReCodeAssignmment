using Project.Application.Dtos.LoginDtos;
using System.Threading.Tasks;

namespace Project.Application.Repositories.LoginRepo
{
    public interface ILogin
    {
         Task<JwtResponseDto> Login(LoginRequest request);
    }
}
