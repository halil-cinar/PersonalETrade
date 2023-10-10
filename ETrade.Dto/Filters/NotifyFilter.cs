 
using Newtonsoft.Json;
using ETrade.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class NotifyFilter
    {
        [JsonProperty(PropertyName = "minExpiryDate")]
        public DateTime? MinExpiryDate { get; set; }

        [JsonProperty(PropertyName = "maxExpiryDate")]
        public DateTime? MaxExpiryDate { get; set; }


        [JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        

        [JsonProperty(PropertyName = "notifyType")]
        public NotifyType? NotifyType { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public long? UserId { get; set; }

        
    }
}
