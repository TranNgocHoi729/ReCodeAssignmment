using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dtos.AccountDtos;
using Project.Application.EF.UnitOfWork;
using System.Threading.Tasks;

namespace CMC_Assignment.Controllers.Account
{
    [Route("assignment/account")]
    [ApiController]
    [Authorize ]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAccount()
        {
            var email = User.FindFirst("Email").Value;
            var result =await _unitOfWork.GetAccountRepository().FindByIdAsync(email);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountAddingDto request)
        {
            var input = _mapper.Map<Project.Core.Entities.Account>(request);
            _unitOfWork.GetAccountRepository().AddAsync(input);
            return Ok(_unitOfWork.Complete());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountUpdatingDto request)
        {
            var email = User.FindFirst("Email").Value;
            var input = _mapper.Map<Project.Core.Entities.Account>(request);
            _unitOfWork.GetAccountRepository().Update(input);
            return Ok(_unitOfWork.Complete());
        }
    }
}
