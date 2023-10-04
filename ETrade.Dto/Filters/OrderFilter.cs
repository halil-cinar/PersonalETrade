
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class OrderFilter
        {
            
        /// <summary>
        /// Customer
        /// </summary>
        [JsonProperty(PropertyName= "userId")]
        public long? UserId { get; set; }

        [JsonProperty(PropertyName= "orderNo")]
        public string? OrderNo { get; set; }

        [JsonProperty(PropertyName = "minOrderDate")]
        public DateTime? MinOrderDate { get; set; }

        [JsonProperty(PropertyName = "maxOrderDate")]
        public DateTime? MaxOrderDate { get; set; }


        [JsonProperty(PropertyName= "billingAddressId")]
        public long? BillingAddressId { get; set; }

        [JsonProperty(PropertyName= "deliveryAddressId")]
        public long? DeliveryAddressId { get; set; }



        [JsonProperty(PropertyName = "minDiscountAmount")]
        public Decimal? MinDiscountAmount { get; set; }

        [JsonProperty(PropertyName = "maxDiscountAmount")]
        public Decimal? MaxDiscountAmount { get; set; }











    }
}
    