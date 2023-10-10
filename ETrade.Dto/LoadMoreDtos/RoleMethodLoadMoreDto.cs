
using ETrade.Dto.Dtos.RoleMethod;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class RoleMethodLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="roleMethodListDtos")]
        public List<RoleMethodListDto> RoleMethodListDtos { get; set; }
            
        }
    }
    