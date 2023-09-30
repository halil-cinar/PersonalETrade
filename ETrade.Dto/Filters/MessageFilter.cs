
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
    {
        
        public class MessageFilter
        {
            
        [JsonProperty(PropertyName= "chatId")]
        public long ChatId { get; set; }

        [JsonProperty(PropertyName= "sentUserId")]
        public long SentUserId { get; set; }

        [JsonProperty(PropertyName= "answeredMessageId")]
        public long? AnsweredMessageId { get; set; }
        
        [JsonProperty(PropertyName= "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName= "sendingTime")]
        public DateTime SendingTime { get; set;}

        [JsonProperty(PropertyName= "isContainsImages")]
        public bool IsContainsImages { get; set; }


       




    
        }
    }
    