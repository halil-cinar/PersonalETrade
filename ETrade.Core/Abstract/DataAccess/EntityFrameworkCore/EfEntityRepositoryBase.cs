using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Abstract.DataAccess.EntityFrameworkCore
{
    public abstract class EfEntityRepositoryBase<TEntity,TContext> : IEntityDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using(var db=new TContext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
               
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().FirstOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (var db = new TContext())
            {
                return (filter == null) ?
                        db.Set<TEntity>().ToList() :
                        db.Set<TEntity>().Where(filter).ToList();

            }
        }

        public List<TEntity> GetAll(string sqlQuery)
        {
            using (var db = new TContext())
            {
               return db.Set<TEntity>().SqlQuery(sqlQuery).ToList();

            }
        }

        public TEntity GetById(long Id)
        {
            using (var db = new TContext())
            {
               return db.Set<TEntity>().Find(Id);
               

            }
        }

        public void Remove(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();

            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().AddOrUpdate(entity);
                db.SaveChanges();

            }
        }
    }
}
