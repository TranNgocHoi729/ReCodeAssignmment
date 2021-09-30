using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.BaseDtos;
using Project.Application.Context;
using Project.Application.Dtos.AccountDtos;
using Project.Application.Repositories;
using Project.Application.Repositories.AccountRepo;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
    
    public class AccountServiceImp: ApplicationRepository<Account>, IAccountRepository
    {
        public AccountServiceImp(DataContext context) : base(context)
        {
        }

        public bool ComparePassword(string password, string input)
        {
            var dbPassword = password.Split("|");
            var realPassword = dbPassword[0];
            byte[] salt = Convert.FromBase64String(dbPassword[1]);
            string passInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            bool is_same = realPassword.Equals(passInput);
            return is_same;
        }

        
    }
}
