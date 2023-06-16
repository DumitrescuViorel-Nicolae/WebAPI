using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Base
{
    public class BaseRepository<TContext, TModel> : IBaseRepository<TContext, TModel>
        where TContext : BaseContext
        where TModel : class
    {
        private readonly TContext _context;
        public BaseRepository(TContext dbContext)
        {
            _context = dbContext;
        }

        public virtual void Create(params TModel[] items)
        {
            _context.Set<TModel>().AddRange(items);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TModel> Read()
        {
            IEnumerable<TModel> tableItems = _context.Set<TModel>().ToList();
            return tableItems;
        }

        public virtual void Update(params TModel[] items)
        {
            foreach (TModel item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public virtual int Delete(params TModel[] items)
        {
            _context.Set<TModel>().RemoveRange(items);
            return _context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<TModel, bool>> filter)
        {
            IEnumerable<TModel> items = _context.Set<TModel>().Where(filter).ToList();
            _context.Set<TModel>().RemoveRange(items);
            _context.SaveChanges();
        }
    }


}
