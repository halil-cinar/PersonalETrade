using ETrade.Dto.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class BrandLoadMoreDto:BaseLoadMoreDto
    {
        public List<BrandListDto> BrandListDtos { get; set; }
    }
}
