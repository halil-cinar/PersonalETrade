using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("ProductComment")]
    public class ProductCommentEntity:EntityBase
    {
        [Column("productId")]
        public long ProductId { get; set; }

        [Column("commentId")]
        public long CommentId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }

        [ForeignKey("CommentId")]
        public virtual CommentEntity Comment { get; set; }
    }
}
