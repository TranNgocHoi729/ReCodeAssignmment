using Project.Application.Repositories.AccountRepo;
using System;

namespace Project.Application.EF.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository GetAccountRepository();

        int Complete();
    }
}
