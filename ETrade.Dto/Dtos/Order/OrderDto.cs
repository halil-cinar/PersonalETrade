
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Order
    {
        
        public class OrderDto:BaseDto
        {
            
        /// <summary>
        /// Customer
        /// </summary>
        [JsonProperty(PropertyName= "userId")]
        public long UserId { get; set; }

        

        [JsonProperty(PropertyName= "orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty(PropertyName= "billingAddressId")]
        public long BillingAddressId { get; set; }

        [JsonProperty(PropertyName= "deliveryAddressId")]
        public long DeliveryAddressId { get; set; }



        [JsonProperty(PropertyName= "discountAmount")]
        public Decimal DiscountAmount { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }







    
        }
    }
    