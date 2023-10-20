using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("MessageMedia")]
    public class MessageMediaEntity:EntityBase
    {
        [Column("messageId")]
        public long MessageId { get; set; }


        [Column("mediaId")]
        public long MediaId { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [ForeignKey(nameof(MediaId))]
        public MediaEntity Media { get; set; }

        [ForeignKey(nameof(MessageId))]
        public MessageEntity Message { get; set; }


    }
}
