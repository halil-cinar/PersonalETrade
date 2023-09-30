using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Role")]
    public class RoleEntity:EntityBase
    {
        [Column("name")]
        public string Name { get; set; }


        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }





    }
}
