using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("UserAddress")]
    public class UserAddressEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("addressId")]
        public long AddressId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("AddressId")]
        public virtual AddressEntity Address { get; set;}
    }
}
