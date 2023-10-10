
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities.Enum;
using ETrade.Entities.Enums;

namespace ETrade.Dto.Dtos. Method
    {
        
        public class MethodDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "key")]
        public MethodList Key { get; set; }

        [JsonProperty(PropertyName= "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        }
    }
    