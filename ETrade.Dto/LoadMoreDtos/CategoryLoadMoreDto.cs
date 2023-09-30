
using ETrade.Dto.Dtos.Category;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class CategoryLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="categoryListDtos")]
        public List<CategoryListDto> CategoryListDtos { get; set; }
            
        }
    }
    