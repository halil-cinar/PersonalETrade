using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Comment")]
    public class CommentEntity:EntityBase
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("commentDate")]
        public DateTime CommentDate { get; set; }

        [Column("userId")]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

    }
}
