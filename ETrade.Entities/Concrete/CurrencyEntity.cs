using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Currency")]
    public class CurrencyEntity:EntityBase
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("currencyCode")]
        public string Code { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }


    }
}
