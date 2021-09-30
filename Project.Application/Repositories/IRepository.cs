using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>> input);

        void AddAsync(T request);

        void Update(T request);

        Task<T> FindByIdAsync(string id);

    }
}
