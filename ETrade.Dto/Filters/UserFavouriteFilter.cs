
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class UserFavouriteFilter
        {
            
        [JsonProperty(PropertyName= "userId")]
        public long? UserId { get; set; }

        [JsonProperty(PropertyName= "productId")]
        public long? ProductId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool? IsActive { get; set; }


        
    
        }
    }
    