﻿using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class DeliveryOptionEntity:EntityBase
    {
        [Column("brandName")]
        public string BrandName { get; set; }

        [Column("price")]
        public Decimal Price { get; set; }

        [Column("isFree")]
        public bool IsFree { get; set;}

        [Column("isSentAbroad")]
        public bool IsSentAbroad { get; set; }

        [Column("logoId")]
        public long? LogoId { get; set; }


        [ForeignKey("LogoId")]
        public MediaEntity Logo { get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }



    }
}
