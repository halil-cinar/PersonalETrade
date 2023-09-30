using ETrade.Dto.Dtos.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Filters
{
    public class BrandFilter
    {
        [JsonProperty(PropertyName = "brandName")]
        public string BrandName { get; set; }

        
    }
}
