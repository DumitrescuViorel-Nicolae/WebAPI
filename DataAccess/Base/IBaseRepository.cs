using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Base
{
    public interface IBaseRepository<TContext, TModel> where TContext : BaseContext where TModel : class
    {
        void Create(params TModel[] items);
        IEnumerable<TModel> Read();
        void Update(params TModel[] items);
        int Delete(params TModel[] items);
        void Delete(Expression<Func<TModel, bool>> filter);
    }
}
