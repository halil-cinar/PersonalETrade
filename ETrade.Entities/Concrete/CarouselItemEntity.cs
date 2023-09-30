using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("CarouselItem")]
    public class CarouselItemEntity:EntityBase
    {
        [Column("backgroudImageId")]
        public long BackgroudImageId { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("subtitle")]
        public string Subtitle { get; set; }

        [ForeignKey("BackgroudImageId")]
        public virtual MediaEntity BackgroudImage { get; set; }





    }
}
