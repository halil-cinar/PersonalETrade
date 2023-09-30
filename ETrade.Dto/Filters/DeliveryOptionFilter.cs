
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class DeliveryOptionFilter
        {
            
        [JsonProperty(PropertyName= "brandName")]
        public string BrandName { get; set; }

        [JsonProperty(PropertyName= "price")]
        public Decimal Price { get; set; }

        [JsonProperty(PropertyName= "isFree")]
        public bool IsFree { get; set;}

        [JsonProperty(PropertyName= "isSentAbroad")]
        public bool IsSentAbroad { get; set; }

        [JsonProperty(PropertyName= "sellerId")]
        public long? SellerId { get; set; }

       



    
        }
    }
    