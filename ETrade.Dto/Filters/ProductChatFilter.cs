
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class ProductChatFilter
        {
            
        [JsonProperty(PropertyName= "chatId")]
        public long? ChatId { get; set; }

        [JsonProperty(PropertyName= "productId")]
        public long? ProductId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool? IsActive { get; set; }

        

       
        }
    }
    