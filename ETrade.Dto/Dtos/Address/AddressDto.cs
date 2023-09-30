using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Address
{
    public class AddressDto:BaseDto
    {
        [JsonProperty(PropertyName="countryId")]
        public long CountryId { get; set; }

        [JsonProperty(PropertyName="phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName="city")]
        public string City { get; set; }

        [JsonProperty(PropertyName="address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName="postalCode")]
        public string PostalCode { get; set; }

       
    }
}
