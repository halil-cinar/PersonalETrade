
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class ChatFilter
        {
            
        [JsonProperty(PropertyName= "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "iconImageId")]
        public long? IconImageId { get; set; }

        




    
        }
    }
    