
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class OrderDetailFilter
        {
            
        [JsonProperty(PropertyName= "orderId")]
        public long? OrderId { get; set; }

        [JsonProperty(PropertyName= "productId")]
        public long? ProductId { get; set; }

        [JsonProperty(PropertyName= "unitPrice")]
        public Decimal? UnitPrice { get; set; }

      

        [JsonProperty(PropertyName= "discountAmount")]
        public Decimal? DiscountAmount { get; set;}

        [JsonProperty(PropertyName= "trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName= "deliveryOptionId")]
        public long? DeliveryOptionId { get; set; }

        [JsonProperty(PropertyName= "shippedDate")]
        public DateTime? ShippedDate { get; set; }

       



        



    
        }
    }
    