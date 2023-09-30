
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.UserAddress;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class UserAddressLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="userAddressListDtos")]
        public List<UserAddressListDto> UserAddressListDtos { get; set; }
            
        }
    }
    