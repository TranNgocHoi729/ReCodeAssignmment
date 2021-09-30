using Microsoft.EntityFrameworkCore;
using Project.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories
{
    public class ApplicationRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _setEntity;

        public ApplicationRepository(DataContext context)
        {
            _context = context;
            _setEntity = context.Set<T>();          
        }
        public async void AddAsync(T request)
        {
            await _setEntity.AddAsync(request);
        }

        public async Task<T> FindByIdAsync(string id)
        {
            return await _setEntity.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> input)
        {
            return await _setEntity.Where(input).ToListAsync();
        }

        public async void Update(T request)
        {
            _setEntity.Update(request);
        }
    }
}
