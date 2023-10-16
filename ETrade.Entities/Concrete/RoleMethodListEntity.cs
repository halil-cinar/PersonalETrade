using ETrade.Entities.Abstract;
using ETrade.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("RoleMethodListView")]
    public class RoleMethodListEntity:ViewEntityBase
    {
        [Column("roleId")]
        public long RoleId { get; set; }

        [Column("methodId")]
        public long MethodId { get; set; }

        [Column("expiryDate")]
        public DateTime? ExpiryDate { get; set; }

        [Column("methodKey")]
        public MethodList MethodKey { get; set; }

        [Column("methodName")]
        public string MethodName { get; set; }

        [Column("methodDescription")]
        public string MethodDescription { get; set; }
        

        [Column("roleName")]
        public string RoleName { get; set; }

        [Column("roleDescription")]
        public string RoleDescription { get; set; }
    }
}
