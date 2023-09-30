using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class ProductChatEntity:EntityBase
    {
        [Column("chatId")]
        public long ChatId { get; set; }

        [Column("productId")]
        public long ProductId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        

        [ForeignKey("ChatId")]
        public virtual ChatEntity Chat { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
    }
}
