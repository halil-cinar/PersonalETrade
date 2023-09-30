using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Brand")]
    public class BrandEntity:EntityBase
    {
        [Column("brandName")]
        public string BrandName { get; set; }

        [Column("imageId")]
        public long? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual MediaEntity Image { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }




    }
}
