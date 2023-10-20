
using ETrade.Dto.Dtos.Media;
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Message
    {
        
        public class MessageDto:BaseDto
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

        [JsonProperty(PropertyName = "isContainsImages")]
        public bool IsContainsImages { get; set; }

        [JsonProperty(PropertyName = "medias")]
        public MediaDto[]?  Medias { get; set; }




        [ForeignKey("ChatId")]
        public virtual ChatEntity Chat { get; set; }

        [ForeignKey("SentUserId")]
        public virtual UserEntity User { get; set; }

        //[ForeignKey("AnsweredMessageId")]
        //public virtual MessageEntity AnsweredMessage { get; set; }

        //public virtual ICollection<MessageEntity> ReplyingMessages { get; set; }




    
        }
    }
    