
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Dto.Dtos.Settings;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class SettingsLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="settingsListDtos")]
        public List<SettingsListDto> SettingsListDtos { get; set; }
            
        }
    }
    