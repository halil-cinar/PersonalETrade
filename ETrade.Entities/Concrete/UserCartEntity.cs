using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("UserCart")]
    public class UserCartEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("productId")]
        public long ProductId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
    }
}
