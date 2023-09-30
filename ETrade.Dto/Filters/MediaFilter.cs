using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class MediaFilter
    {
        [JsonProperty(PropertyName = "entityType")]
        public EntityType? EntityType { get; set; }

        

        [JsonProperty(PropertyName = "fileType")]
        public FileType? FileType { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        
    }
}
