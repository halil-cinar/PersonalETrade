
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Settings
    {
        
        public class SettingsListDto:BaseListDto
        {
            
     

        [JsonProperty(PropertyName= "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "defaultValue")]
        public string DefaultValue { get; set; }

    
        }
    }
    