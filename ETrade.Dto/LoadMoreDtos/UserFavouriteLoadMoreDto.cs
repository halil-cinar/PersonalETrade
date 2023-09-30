
using ETrade.Dto.Dtos.Category;
using ETrade.Dto.Dtos.UserFavourite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
    {
        
        public class UserFavouriteLoadMoreDto:BaseLoadMoreDto
        {
        [JsonProperty(PropertyName ="userFavouriteListDtos")]
        public List<UserFavouriteListDto> UserFavouriteListDtos { get; set; }
            
        }
    }
    