using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Comment
{
    public class CommentDto:BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime CommentDate { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }
    }
}
