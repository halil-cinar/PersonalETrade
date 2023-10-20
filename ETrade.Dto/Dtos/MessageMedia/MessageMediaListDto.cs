﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.MessageMedia
{
    public class MessageMediaListDto:BaseListDto
    {
        [JsonProperty(PropertyName = "messageId")]
        public long MessageId { get; set; }


        [JsonProperty(PropertyName = "mediaId")]
        public long MediaId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
    }
}
