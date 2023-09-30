using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
   
    [Table("Status")]
    public class StatusEntity:EntityBase

    {

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("color")]
        public string Color { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
