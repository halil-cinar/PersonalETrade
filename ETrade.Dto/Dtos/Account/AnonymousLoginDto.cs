using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Account
{
    public class AnonymousLoginDto
    {

        [JsonProperty(PropertyName = "deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "notifyToken")]
        public string NotifyToken { get; set; }

    }
}
