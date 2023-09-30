using ETrade.Dto.Dtos.Identity;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.User
{
    public class UserDto:BaseDto
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName="surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName ="identity")]
        public IdentityDto Identity { get; set; }

        [JsonProperty(PropertyName="email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName="phoneNumber")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName="identityNumber")]
        public string IdentityNumber { get; set; }

        [JsonProperty(PropertyName ="roleId")]
        public long[]  RoleIds { get; set; }

        //[JsonProperty(PropertyName="profilePhotoId")]
        //public long? ProfilePhotoId { get; set; }

        [JsonProperty(PropertyName="gender")]
        public GenderType Gender { get; set; }


        [JsonProperty(PropertyName="birthDate")]
        public DateTime? BirthDate { get; set; }

    }
}
