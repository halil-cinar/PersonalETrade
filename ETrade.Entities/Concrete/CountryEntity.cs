using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Country")]
    public class CountryEntity:EntityBase
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("code")]
        public string Code { get; set; }


    }
}
