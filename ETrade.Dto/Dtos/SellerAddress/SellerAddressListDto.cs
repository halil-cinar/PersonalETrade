
using ETrade.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos. SellerAddress
    {
        
        public class SellerAddressListDto:BaseListDto
        {
            
        [JsonProperty(PropertyName= "sellerId")]
        public long SellerId { get; set; }

        [JsonProperty(PropertyName= "addressId")]
        public long AddressId { get; set; }

        [JsonProperty(PropertyName= "isActive")]
        public bool IsActive { get; set; }

        
    
        }
    }
    