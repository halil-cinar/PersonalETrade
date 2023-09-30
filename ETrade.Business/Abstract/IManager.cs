using AutoMapper;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Entities.Abstract;
using ETrade.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IManager<T>
        where T : EntityBase,new()
    {
        string UserName { get; set; }
       
        string IpAddress { get; set; }

        IMapper mapper { get; set; }
        BaseEntityValidator<T> Validator { get; set; }

        BaseEntityValidator<T> UpdateValidator { get; set; }

        IEntityDal<T> repository { get; set; }



        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

        T GetById(long Id);

        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>> filter);

        List<T> GetAll(string sqlQuery);
    }
}
