using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("SellerComment")]
    public  class SellerCommentEntity:EntityBase
    {
        [Column("SellerId")]
        public long SellerId { get; set; }

        [Column("commentId")]
        public long CommentId { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey("SellerId")]
        public virtual SellerEntity Seller { get; set; }

        [ForeignKey("CommentId")]
        public virtual CommentEntity Comment { get; set; }
    }
}
