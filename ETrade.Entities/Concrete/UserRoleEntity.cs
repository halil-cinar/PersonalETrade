using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("UserRole")]
    public class UserRoleEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("roleId")]
        public long RoleId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity Role { get; set; }


    }
}
