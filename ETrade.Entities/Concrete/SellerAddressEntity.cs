using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("SellerAddress")]
    public class SellerAddressEntity:EntityBase
    {
        [Column("sellerId")]
        public long SellerId { get; set; }

        [Column("addressId")]
        public long AddressId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey("SellerId")]
        public virtual SellerEntity Seller { get; set; }

        [ForeignKey("AddressId")]
        public virtual AddressEntity Address { get; set; }
    }
}
