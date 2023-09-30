
using ETrade.Dto.Dtos.CarouselItem;
using ETrade.Dto.Dtos.Category;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class CarouselItemLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="carouselItemListDtos")]
        public List<CarouselItemListDto> CarouselItemListDtos { get; set; }
            
        }
    }
    