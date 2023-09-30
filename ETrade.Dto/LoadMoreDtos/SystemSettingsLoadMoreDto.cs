
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.SystemSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SystemSettingsLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="systemSettingsListDtos")]
        public List<SystemSettingsListDto> SystemSettingsListDtos { get; set; }
            
        }
    }
    