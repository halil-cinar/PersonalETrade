
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Session
    {
        
        public class SessionListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "identityId")]
        public long IdentityId { get;set; }

        [JsonProperty(PropertyName= "userId")]
        public long UserId { get; set; } 

        [JsonProperty(PropertyName= "expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonProperty(PropertyName= "ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName= "deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName= "notifyToken")]
        public string NotifyToken { get; set; }

        [JsonProperty(PropertyName= "token")]
        public Guid Token { get;set; }

        
       
    
        }
    }
    