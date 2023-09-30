using ETrade.Dto.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.LoadMoreDtos
{
    public class CommentLoadMoreDto:BaseLoadMoreDto
    {
        public List<CommentListDto> commentListDtos { get; set; }
    }
}
