using ETrade.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Media
{
    public class MediaListDto:BaseListDto
    {
        [JsonProperty(PropertyName="entityType")]
        public EntityType? EntityType { get; set; }

        [JsonProperty(PropertyName="entityId")]
        public long? EntityId { get; set; }

        [JsonProperty(PropertyName="fileType")]
        public FileType FileType { get; set; }

        [JsonProperty(PropertyName="fileName")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName="content")]
        public byte[] Content { get; set; }

        [JsonProperty(PropertyName="contentType")]
        public string ContentType { get; set; }
    }
}
