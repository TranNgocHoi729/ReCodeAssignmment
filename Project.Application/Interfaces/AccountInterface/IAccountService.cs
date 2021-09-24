
using Project.Application.Common.BaseDtos;
using Project.Application.Dtos.AccountDtos;
using System.Threading.Tasks;

namespace Project.Application.Interfaces.AccountInterface
{
    public interface IAccountService
    {
        Task<BaseResponseResult<int>> CreateAccountAsync(AccountAddingDto request);

        Task<BaseResponseResult<int>> UpdateAccountAsync(AccountUpdatingDto request, string email);

        Task<BaseResponseResult<AccountSelectingDto>> GetAccountByEmailAsync(string email);
    }
}
