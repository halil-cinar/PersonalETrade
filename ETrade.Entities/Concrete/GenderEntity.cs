using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Gender")]
    public class GenderEntity:EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }

    }
}
