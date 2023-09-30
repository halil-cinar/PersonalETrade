using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Address")]
    public class AddressEntity:EntityBase
    {
        [Column("countryId")]
        public long CountryId { get; set; }

        [Column("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("postalCode")]
        public string PostalCode { get; set; }


        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }
    }
}
