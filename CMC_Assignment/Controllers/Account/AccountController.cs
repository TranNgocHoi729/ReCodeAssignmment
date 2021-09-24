using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dtos.AccountDtos;
using Project.Application.Interfaces.AccountInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMC_Assignment.Controllers.Account
{
    [Route("assignment/account")]
    [ApiController]
    [Authorize ]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAccount()
        {
            var email = User.FindFirst("Email").Value;
            var result =await _accountService.GetAccountByEmailAsync(email);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountAddingDto request)
        {
            var result = await _accountService.CreateAccountAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountUpdatingDto request)
        {
            var email = User.FindFirst("Email").Value;
            var result = await _accountService.UpdateAccountAsync(request, email);
            return Ok(result);
        }
    }
}
