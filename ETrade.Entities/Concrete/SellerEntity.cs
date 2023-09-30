using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Seller")]
    public class SellerEntity:EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("userId")]
        public long UserId { get; set; }

        [Column("coverImageId")]
        public long? CoverImageId { get; set; }

        [Column("avatarImageId")]
        public long? AvatarImageId { get; set;}

        [Column("rating")]
        public Double  Rating { get; set; }

        

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [ForeignKey("CoverImageId")]
        public MediaEntity CoverImage { get; set; }

        [ForeignKey("AvatarImageId")]
        public MediaEntity AvatarImage { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
        public virtual ICollection<DeliveryOptionEntity> DeliveryOptions { get; set; }
        public virtual ICollection<SellerAddressEntity> SellerAddresses { get; set; }
        public virtual ICollection<SellerCommentEntity> SellerComments { get; set; }









    }
}
