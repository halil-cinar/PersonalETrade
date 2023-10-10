
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class UserSettingsFilter
        {
            
        [JsonProperty(PropertyName= "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName= "settingId")]
        public long SettingId { get; set; }

        [JsonProperty(PropertyName= "value")]
        public string Value { get; set; }


    
        }
    }
    