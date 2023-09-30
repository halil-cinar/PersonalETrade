
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.Country;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class CountryLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="countryListDtos")]
        public List<CountryListDto> CountryListDtos { get; set; }
            
        }
    }
    