
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. OrderDetail
    {
        
        public class OrderDetailListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "orderId")]
        public long OrderId { get; set; }

        [JsonProperty(PropertyName= "productId")]
        public long ProductId { get; set; }

        [JsonProperty(PropertyName= "unitPrice")]
        public Decimal UnitPrice { get; set; }

        [JsonProperty(PropertyName= "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName= "discountAmount")]
        public Decimal DiscountAmount { get; set;}

        [JsonProperty(PropertyName= "TrackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName= "deliveryOptionId")]
        public long DeliveryOptionId { get; set; }

        [JsonProperty(PropertyName= "shippedDate")]
        public DateTime? ShippedDate { get; set; }

        [JsonProperty(PropertyName= "currencyId")]
        public long CurrencyId { get; set; }



        



    
        }
    }
    