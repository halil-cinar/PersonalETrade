
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Chat
    {
        
        public class ChatListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName= "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName= "iconImageId")]
        public long? IconImageId { get; set; }

        




    
        }
    }
    