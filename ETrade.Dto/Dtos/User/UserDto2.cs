using ETrade.Dto.Dtos.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.User
{
    public class UserDto2
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName="surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName="email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName="phoneNumber")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName="identityNumber")]
        public string IdentityNumber { get; set; }



        [JsonProperty(PropertyName="profilePhoto")]
        public MediaListDto? ProfilePhoto { get; set; }

        [JsonProperty(PropertyName="genderId")]
        public long GenderId { get; set; }


        [JsonProperty(PropertyName="birthDate")]
        public DateTime? BirthDate { get; set; }
    }
}
