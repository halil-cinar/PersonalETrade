using ETrade.Dto.Dtos.ProductComment;
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
    public interface IProductCommentService:IManager<ProductCommentEntity>
    {
        public BusinessLayerResult<ProductCommentListDto> AddProductComment(ProductCommentDto productcommentDto);
        public BusinessLayerResult<ProductCommentListDto> UpdateProductComment(ProductCommentDto productcommentDto);
        public BusinessLayerResult<ProductCommentListDto> DeleteProductComment(long productcommentId);
        public BusinessLayerResult<ProductCommentListDto> GetProductComment(long id);

        public BusinessLayerResult<List<ProductCommentListDto>> Filter(ProductCommentFilter productcommentFilter);
        public BusinessLayerResult<ProductCommentLoadMoreDto> FilterProductCommentList(BaseLoadMoreFilter<ProductCommentFilter> filter);
    }
}

