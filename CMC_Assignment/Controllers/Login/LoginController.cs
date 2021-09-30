using Microsoft.AspNetCore.Mvc;
using Project.Application.Dtos.LoginDtos;
using Project.Application.Repositories.LoginRepo;
using System;
using System.Threading.Tasks;

namespace CMC_Assignment.Controllers.Login
{
    [Route("assignment/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;

        public LoginController(ILogin loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result =await _loginService.Login(request);
            return Ok(result);
        }
    }
}
