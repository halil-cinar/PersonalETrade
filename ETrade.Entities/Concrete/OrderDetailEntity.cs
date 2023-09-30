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
    [Table("OrderDetail")]
    public class OrderDetailEntity:EntityBase
    {
        [Column("orderId")]
        public long OrderId { get; set; }

        [Column("productId")]
        public long ProductId { get; set; }

        [Column("unitPrice")]
        public Decimal UnitPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discountAmount")]
        public Decimal DiscountAmount { get; set;}

        [Column("TrackingNumber")]
        public string TrackingNumber { get; set; }

        [Column("deliveryOptionId")]
        public long DeliveryOptionId { get; set; }

        [Column("shippedDate")]
        public DateTime? ShippedDate { get; set; }

        [Column("currencyId")]
        public long CurrencyId { get; set; }



        [ForeignKey("OrderId")]
        public  OrderEntity Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }

        [ForeignKey("DeliveryOptionId")]
        public virtual DeliveryOptionEntity DeliveryOption { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual CurrencyEntity Currency { get; set; }



    }
}
