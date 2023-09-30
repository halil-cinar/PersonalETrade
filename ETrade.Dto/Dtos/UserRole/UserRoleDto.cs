using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.UserRole
{
    public class UserRoleDto:BaseDto
    {
        [JsonProperty(PropertyName="userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName="roleId")]
        public long RoleId { get; set; }

        [JsonProperty(PropertyName="isActive")]
        public bool IsActive { get; set; }
    }
}
