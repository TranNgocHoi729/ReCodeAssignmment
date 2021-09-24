using Project.Application.Dtos.LoginDtos;
using System.Threading.Tasks;

namespace Project.Application.Interfaces.LoginInterface
{
    public interface ILogin
    {
         Task<JwtResponseDto> Login(LoginRequest request);
    }
}
