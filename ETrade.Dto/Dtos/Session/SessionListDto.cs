
using ETrade.Entities.Concrete;
using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. Session
    {
        
        public class SessionListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName="identityId")]
        public long? IdentityId { get; set; }

        [JsonProperty(PropertyName="userId")]
        public long? UserId { get; set; }

        [JsonProperty(PropertyName="expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonProperty(PropertyName="ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName="deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName="notifyToken")]
        public string NotifyToken { get; set; }

        [JsonProperty(PropertyName="token")]
        public Guid Token { get; set; }

        [JsonProperty(PropertyName="isActive")]
        public bool? IsActive { get; set; }


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



        [JsonProperty(PropertyName="profilePhotoId")]
        public long? ProfilePhotoId { get; set; }

        [JsonProperty(PropertyName="gender")]
        public GenderType Gender { get; set; }


        [JsonProperty(PropertyName="birthDate")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty(PropertyName="userName")]
        public string UserName { get; set; }





    }
}
    