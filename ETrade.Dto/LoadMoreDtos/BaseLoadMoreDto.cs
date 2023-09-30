using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class BaseLoadMoreDto
    {
        public int PageCount { get; set; }
        public int ContentCount { get; set; }

        public bool NextPage { get; set; }

        public bool PreviousPage { get; set; }

    }
}
