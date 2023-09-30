using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class UserFilter
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName="surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName="email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName="phoneNumber")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "identityNumber")]
        public string IdentityNumber { get; set; }

        [JsonProperty(PropertyName="gender")]
        public GenderType? Gender { get; set; }


        [JsonProperty(PropertyName = "birthDateFirst")]
        public DateTime? BirthDateFirst { get; set; }

        [JsonProperty(PropertyName = "birthDateLast")]
        public DateTime? BirthDateLast { get; set; }

    }
}
