using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Category")]
    public class CategoryEntity:EntityBase
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("topCategoryId")]
        public long? TopCategoryId { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("imageId")]
        public long ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual MediaEntity Image { get; set;}

        




    }
}
