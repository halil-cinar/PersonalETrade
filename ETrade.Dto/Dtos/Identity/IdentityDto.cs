using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Identity
{
    public class IdentityDto:BaseDto
    {
        [JsonProperty(PropertyName="userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName="isActive")]
        public bool isActive { get; set; }


        [JsonProperty(PropertyName="userName")]
        public string UserName { get; set; }


        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [Compare("Password")]
        [JsonProperty(PropertyName = "confirmPassword")]
        public string ConfirmPassword { get; set; }

        [JsonProperty(PropertyName ="deviceType")]
        public DeviceType DeviceType { get; set; }



    }
}
