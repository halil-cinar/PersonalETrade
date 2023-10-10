
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class SettingsFilter
        {
            
     

        [JsonProperty(PropertyName= "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "defaultValue")]
        public string DefaultValue { get; set; }

    
        }
    }
    