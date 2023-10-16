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
        [Table("SessionListView")]
    public class SessionListEntity : ViewEntityBase
    {
        [Column("identityId")]
        public long? IdentityId { get; set; }

        [Column("userId")]
        public long? UserId { get; set; }

        [Column("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [Column("ipAddress")]
        public string IpAddress { get; set; }

        [Column("deviceType")]
        public DeviceType DeviceType { get; set; }

        [Column("notifyToken")]
        public string NotifyToken { get; set; }

        [Column("token")]
        public Guid Token { get; set; }

        [Column("isActive")]
        public bool? IsActive { get; set; }


        [Column("name")]
        public string Name { get; set; }


        [Column("surname")]
        public string Surname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phoneNumber")]
        public string Phone { get; set; }

        [Column("identityNumber")]
        public string IdentityNumber { get; set; }



        [Column("profilePhotoId")]
        public long? ProfilePhotoId { get; set; }

        [Column("gender")]
        public GenderType Gender { get; set; }


        [Column("birthDate")]
        public DateTime? BirthDate { get; set; }

        [Column("userName")]
        public string UserName { get; set; }



    }
}
