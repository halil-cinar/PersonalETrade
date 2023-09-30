using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("UserChat")]
    public class UserChatEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("chatId")]
        public long ChatId { get; set; }

        [Column("isActive")]
        public bool isActive { get; set; }

        [Column("joinDate")]
        public DateTime JoinDate { get; set; }

        [Column("DepartureDate")]
        public DateTime? DepartureDate { get; set; }

        [Column("isSeller")]
        public bool IsSeller { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("ChatId")]
        public virtual ChatEntity Chat { get; set;}







    }

}
