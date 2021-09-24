using AutoMapper;
using Project.Application.Common.BaseDtos;
using Project.Application.Dtos.AccountDtos;
using Project.Application.Interfaces.AccountInterface;
using Project.Core.Context;
using Project.Core.Entities;
using Project.Core.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Services.AccountService
{
    public class AccountServiceImp : IAccountService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AccountServiceImp(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BaseResponseResult<int>> CreateAccountAsync(AccountAddingDto request)
        {
            var account = _mapper.Map<Account>(request);
            _context.Add(account);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return BaseResponseResult<int>.Success(result);
            }
            return BaseResponseResult<int>.Faild(result, CrudMessage.CreateErrorMessage);
        }

        public async Task<BaseResponseResult<AccountSelectingDto>> GetAccountByEmailAsync(string email)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Email.Equals(email));
            if (account != null)
            {
                AccountSelectingDto result = _mapper.Map<AccountSelectingDto>(account);
                return BaseResponseResult<AccountSelectingDto>.Success(result);
            }
            else
            {
                return BaseResponseResult<AccountSelectingDto>.Faild(null, CrudMessage.SelectErrorMessage);
            }
        }

        public async Task<BaseResponseResult<int>> UpdateAccountAsync(AccountUpdatingDto request, string email)
        {
            var temp = _context.Accounts.FirstOrDefault(a => a.Email.Equals(email));
            temp.Name = request.Name;
            temp.Gender = request.Gender;
            temp.DOB = request.DOB;
            temp.EmailOptIn = request.EmailOptIn;
            temp.MobileNumber = request.MobileNumber;

            _context.Accounts.Update(temp);
            int result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return BaseResponseResult<int>.Success(result);
            }
            return BaseResponseResult<int>.Faild(0, CrudMessage.UpdateErrorMessage);
        }
    }
}
