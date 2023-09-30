using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Identity
{
    public class IdentityListDto:BaseListDto
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool isActive { get; set; }


        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }


        [JsonProperty(PropertyName = "passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty(PropertyName = "passwordSalt")]
        public string PasswordSalt { get; set; }
    }
}
