
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. RoleMethod
    {
        
        public class RoleMethodListDto:BaseListDto
        {

        [JsonProperty(PropertyName="roleId")]
        public long RoleId { get; set; }

        [JsonProperty(PropertyName="methodId")]
        public long MethodId { get; set; }

        [JsonProperty(PropertyName="expiryDate")]
        public DateTime? ExpiryDate { get; set; }

        [JsonProperty(PropertyName="methodKey")]
        public MethodList MethodKey { get; set; }

        [JsonProperty(PropertyName="methodName")]
        public string MethodName { get; set; }

        [JsonProperty(PropertyName="methodDescription")]
        public string MethodDescription { get; set; }


        [JsonProperty(PropertyName="roleName")]
        public string RoleName { get; set; }

        [JsonProperty(PropertyName="roleDescription")]
        public string RoleDescription { get; set; }


    }
    }
    