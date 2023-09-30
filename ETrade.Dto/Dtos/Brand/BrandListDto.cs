using ETrade.Dto.Dtos.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Brand
{
    public class BrandListDto:BaseListDto
    {
        [JsonProperty(PropertyName = "brandName")]
        public string BrandName { get; set; }

        [JsonProperty(PropertyName = "imageId")]
        public long? ImageId { get; set; }

        //[JsonProperty(PropertyName = "ImageDto")]
        //public MediaDto ImageDto { get; set; }
    }
}
