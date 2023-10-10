using ETrade.Entities.Abstract;
using ETrade.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Notify")]
    public class NotifyEntity : EntityBase
    {
        [Column("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("notifyType")]
        public NotifyType NotifyType { get; set; }

        [Column("userId")]
        public long UserId { get; set; }

        [Column("data")]
        public string? Data { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

    }
}
