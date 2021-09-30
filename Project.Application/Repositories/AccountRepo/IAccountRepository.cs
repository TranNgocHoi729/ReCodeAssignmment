using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.AccountRepo
{
    public interface IAccountRepository : IRepository<Account>
    {
        bool ComparePassword(string password, string input);
    }
}
