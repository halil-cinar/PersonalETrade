using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Message")]
    public class MessageEntity:EntityBase
    {
        [Column("chatId")]
        public long ChatId { get; set; }

        [Column("sentUserId")]
        public long SentUserId { get; set; }

        [Column("answeredMessageId")]
        public long? AnsweredMessageId { get; set; }
        
        [Column("message")]
        public string Message { get; set; }

        [Column("sendingTime")]
        public DateTime SendingTime { get; set;}

        [Column("isContainsImages")]
        public bool IsContainsImages { get; set; }


        [ForeignKey("ChatId")]
        public virtual ChatEntity Chat { get; set; }

        [ForeignKey("SentUserId")]
        public virtual UserEntity User { get; set; }

        //[ForeignKey("AnsweredMessageId")]
        //public virtual MessageEntity AnsweredMessage { get; set; }

        //public virtual ICollection<MessageEntity> ReplyingMessages { get; set; }




    }
}
