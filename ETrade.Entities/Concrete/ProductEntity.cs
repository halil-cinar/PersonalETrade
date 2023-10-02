using ETrade.Entities.Abstract;
using ETrade.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Product")]
    public class ProductEntity:EntityBase
    {
        
        [Column("title")]
        public string Title { get; set; }

        [Column("oldPrice")]
        public Decimal? OldPrice { get; set; }

        [Column("price")]
        public Decimal Price { get; set; }

        [Column("currencyId")]
        public long CurrencyId { get; set; }

        [Column("brandId")]
        public long? BrandId { get; set; }

        [Column("categoryId")]
        public long CategoryId { get; set; }

        [Column("userId")]
        public long UserId { get; set; }

        [Column("rating")]
        public Double Rating { get; set; }

        [Column("isSoldAbroad")]
        public bool IsSoldAbroad { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("statusType")]
        public ProductStatusType StatusType { get; set; }

        [Column("stockStatusType")]
        public ProductStockStatusType StockStatusType { get; set; }



        [ForeignKey("CurrencyId")]
        public virtual CurrencyEntity Currency { get; set; }

        [ForeignKey("BrandId")]
        public virtual BrandEntity Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        
        //[ForeignKey("StatusId")]
        //public virtual StatusEntity Status { get; set; }


        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
        public virtual ICollection<ProductCommentEntity> ProductComments { get; set; }
        public virtual ICollection<UserFavouriteEntity> UserFavourites { get; set; }
        public virtual ICollection<UserCartEntity> UserCarts { get; set; }
        public virtual ICollection<ProductChatEntity> ProductChats { get; set; }



    }
}
