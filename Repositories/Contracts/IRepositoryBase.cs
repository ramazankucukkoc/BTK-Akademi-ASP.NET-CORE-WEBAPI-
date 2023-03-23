using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindAllCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);  
    }
}
