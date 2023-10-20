using ETrade.Dto.Dtos.ProductChat;
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
    public interface IProductChatService:IManager<ProductChatEntity>
    {
        public BusinessLayerResult<ProductChatListDto> AddProductChat(ProductChatDto productchatDto);
        public BusinessLayerResult<ProductChatListDto> UpdateProductChat(ProductChatDto productchatDto);
        public BusinessLayerResult<ProductChatListDto> DeleteProductChat(long productchatId);
        public BusinessLayerResult<ProductChatListDto> GetProductChat(long id);

        public BusinessLayerResult<List<ProductChatListDto>> Filter(ProductChatFilter productchatFilter);
        public BusinessLayerResult<ProductChatLoadMoreDto> FilterProductChatList(BaseLoadMoreFilter<ProductChatFilter> filter);
    }
}

