using ETrade.Core.Abstract.DataAccess;
using ETrade.Core.Abstract.DataAccess.EntityFrameworkCore;
using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.EntityFrameworkCore
{
    public class EfEntityGenericRepository<T>:EfEntityRepositoryBase<T,DatabaseContext>,IEntityDal<T>
        where T : class,IEntity,new()
    {
    }
}
