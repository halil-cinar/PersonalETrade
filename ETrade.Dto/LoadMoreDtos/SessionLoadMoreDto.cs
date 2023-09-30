
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Session;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SessionLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="sessionListDtos")]
        public List<SessionListDto> SessionListDtos { get; set; }
            
        }
    }
    