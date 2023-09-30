using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Role
{
    public class RoleListDto:BaseListDto
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName="description")]
        public string Description { get; set; }
    }
}
