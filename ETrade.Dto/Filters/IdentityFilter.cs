using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class IdentityFilter
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool isActive { get; set; }



       
    }
}
