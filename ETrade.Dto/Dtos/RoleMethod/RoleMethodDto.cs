
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. RoleMethod
    {
        
        public class RoleMethodDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "roleId")]
        public long RoleId { get; set; }

        [JsonProperty(PropertyName= "methodId")]
        public long MethodId { get; set; }

        [JsonProperty(PropertyName= "expiryDate")]
        public DateTime? ExpiryDate { get; set; }

       
        }
    }
    