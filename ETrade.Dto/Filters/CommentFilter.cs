using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class CommentFilter
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "firstDate")]
        public DateTime? FirstDate { get; set; }

        [JsonProperty(PropertyName = "lastDate")]
        public DateTime? LastDate { get; set; }


        [JsonProperty(PropertyName = "userId")]
        public long? UserId { get; set; }
    }
}
