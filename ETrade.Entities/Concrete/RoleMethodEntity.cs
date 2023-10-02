using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("RoleMethod")]
    public class RoleMethodEntity:EntityBase
    {
        [Column("roleId")]
        public long RoleId { get; set; }

        [Column("methodId")]
        public long MethodId { get; set; }

        [Column("expiryDate")]
        public DateTime? ExpiryDate { get; set; }

        [ForeignKey(nameof(RoleId))]
        public RoleEntity Role { get; set; }

        [ForeignKey(nameof(MethodId))]
        public MethodEntity Method { get; set; }
    }
}
