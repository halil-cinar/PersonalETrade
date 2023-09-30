using ETrade.Entities.Abstract;
using ETrade.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Session")]
    public class SessionEntity:EntityBase
    {
        [Column("identityId")]
        public long IdentityId { get;set; }

        [Column("userId")]
        public long UserId { get; set; } 

        [Column("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [Column("ipAddress")]
        public string IpAddress { get; set; }

        [Column("deviceType")]
        public DeviceType DeviceType { get; set; }

        [Column("notifyToken")]
        public string NotifyToken { get; set; }

        [Column("token")]
        public Guid Token { get;set; }

        [ForeignKey("IdentityId")]
        public virtual IdentityEntity Identity { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set;}


       
    }
}
