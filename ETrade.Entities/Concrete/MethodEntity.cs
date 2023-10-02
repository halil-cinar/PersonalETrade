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
    [Table("Method")]
    public class MethodEntity:EntityBase
    {
        [Column("key")]
        public MethodList Key { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<RoleMethodEntity> RoleMethods { get; set; }
    }
}
