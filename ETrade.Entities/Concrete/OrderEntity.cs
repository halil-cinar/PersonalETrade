using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Order")]
    public class OrderEntity:EntityBase
    {
        /// <summary>
        /// Customer
        /// </summary>
        [Column("userId")]
        public long UserId { get; set; }

        [Column("orderNo")]
        public string OrderNo { get; set; }

        [Column("orderDate")]
        public DateTime OrderDate { get; set; }

        [Column("billingAddressId")]
        public long BillingAddressId { get; set; }

        [Column("deliveryAddressId")]
        public long DeliveryAddressId { get; set; }



        [Column("discountAmount")]
        public Decimal DiscountAmount { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }







    }
}
