    using Project.Application.Context;
using Project.Application.Repositories.AccountRepo;
using Project.Application.Services;


namespace Project.Application.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private DataContext _context;
        private IAccountRepository _accountRepository;
        

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAccountRepository GetAccountRepository()
        {
            if (_accountRepository == null)
            {
                _accountRepository = new AccountServiceImp(_context);
            }
            return _accountRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
