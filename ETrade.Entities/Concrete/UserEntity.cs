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
    [Table("User")]
    public class UserEntity:EntityBase
    {
        

        [Column("name")]
        public string  Name { get; set; }


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

        //[ForeignKey("GenderId")]
        //public virtual GenderEntity Gender { get; set; }

        [ForeignKey("ProfilePhotoId")]
        public virtual MediaEntity Image { get; set; }

        public virtual ICollection<UserFavouriteEntity> UserFavourites { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<MessageEntity> Messages { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
        public virtual ICollection<SellerEntity> Sellers { get; set; }
        public virtual ICollection<UserAddressEntity> UserAddresses { get; set; }
        public virtual ICollection<UserCartEntity> UserCarts { get; set; }
        public virtual ICollection<UserChatEntity> UserChats { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }










    }
}
