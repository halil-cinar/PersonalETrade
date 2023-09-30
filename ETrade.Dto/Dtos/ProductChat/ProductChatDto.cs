
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. ProductChat
    {
        
        public class ProductChatDto:BaseDto
        {
            
        [JsonProperty(PropertyName= "chatId")]
        public long ChatId { get; set; }

        [JsonProperty(PropertyName= "productId")]
        public long ProductId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool IsActive { get; set; }

        

       
    
        }
    }
    