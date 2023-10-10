
using ETrade.Dto.Dtos.Method;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class MethodLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="methodListDtos")]
        public List<MethodListDto> MethodListDtos { get; set; }
            
        }
    }
    