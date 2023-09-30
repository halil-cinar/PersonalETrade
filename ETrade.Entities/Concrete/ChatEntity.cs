using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Chat")]
    public class ChatEntity:EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("iconImageId")]
        public long? IconImageId { get; set; }

        [ForeignKey("IconImageId")]
        public virtual MediaEntity IconImage { get; set; }

        public virtual ICollection<MessageEntity> Messages { get; set; }
        public virtual ICollection<UserChatEntity> UserChats { get; set; }
        public virtual ICollection<ProductChatEntity> ProductChats { get; set; }




    }
}
