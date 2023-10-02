
using AutoMapper;
using ETrade.Core.Abstract.DataAccess;
using ETrade.Core.Abstract.DataAccess.EntityFrameworkCore;
using ETrade.DataAccess.EntityFrameworkCore;
using ETrade.Entities.Abstract;
using ETrade.Entities.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public class ManagerBase<TEntity> : IManager<TEntity>
        where TEntity : EntityBase, new()
    {
        public string UserName { get; set; }

        public IMapper mapper { get; set; }

        public string IpAddress { get; set; }

        public BaseEntityValidator<TEntity> Validator { get;  set; }

        public BaseEntityValidator<TEntity> UpdateValidator { get;  set; }
        public IEntityDal<TEntity> repository { get; set; }

        public ManagerBase(string userName, string ıpAddress, BaseEntityValidator<TEntity> validator, IMapper mapper, IEntityDal<TEntity> repository)
        {
            UserName = userName;
            IpAddress = ıpAddress;
            Validator = validator;


            UpdateValidator = (BaseEntityValidator<TEntity>)Activator.CreateInstance(Validator.GetType());
            UpdateValidator.RuleFor(x => x.UpdateTime).NotEmpty().NotNull();
            UpdateValidator.RuleFor(x => x.UpdateIpAddress).NotEmpty().NotNull();
            UpdateValidator.RuleFor(x => x.UpdateUserName).NotEmpty().NotNull();
            this.mapper = mapper;
            this.repository = repository;
        }

        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
           return repository.Get(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            return repository.GetAll(filter);
        }

        public List<TEntity> GetAll(string sqlQuery)
        {
            return repository.GetAll(sqlQuery);
        }

        public TEntity GetById(long Id)
        {
           return repository.GetById(Id);
        }

        public void Remove(TEntity entity)
        {
            repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }

   
}
