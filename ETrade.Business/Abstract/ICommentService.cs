using ETrade.Dto.Dtos.Comment;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface ICommentService : IManager<CommentEntity>
    {
        public BusinessLayerResult<CommentListDto> AddComment(CommentDto commentDto);
        public BusinessLayerResult<CommentListDto> UpdateComment(CommentDto commentDto);
        public BusinessLayerResult<CommentListDto> DeleteComment(long commentId);
        public BusinessLayerResult<CommentListDto> GetComment(long id);

        public BusinessLayerResult<List<CommentListDto>> Filter(CommentFilter commentFilter);
        public BusinessLayerResult<CommentLoadMoreDto> FilterCommentList(BaseLoadMoreFilter<CommentFilter> filter);
    
    }
}
