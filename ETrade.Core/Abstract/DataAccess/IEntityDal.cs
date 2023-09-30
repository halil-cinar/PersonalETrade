using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Abstract.DataAccess
{
    public interface IEntityDal<T> where T : class,IEntity,new()
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        
        T GetById(long Id);

        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T,bool>> filter);

        List<T> GetAll(string sqlQuery);



    }
}
