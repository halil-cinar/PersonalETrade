using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Identity")]
    public class IdentityEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("isActive")]
        public bool isActive { get; set; }
        
        
        [Column("userName")]
        public string UserName { get; set; }


        [Column("passwordHash")]
        public string PasswordHash { get; set; }

        [Column("passwordSalt")]
        public string PasswordSalt { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

    }
}
