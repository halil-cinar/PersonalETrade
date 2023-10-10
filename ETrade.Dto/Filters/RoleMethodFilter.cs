
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class RoleMethodFilter
        {
            
        [JsonProperty(PropertyName= "roleId")]
        public long[]? RoleIds { get; set; }

        [JsonProperty(PropertyName= "methodId")]
        public long[]? MethodIds { get; set; }

        

        
    
        }
    }
    