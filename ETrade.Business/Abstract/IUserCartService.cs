using ETrade.Dto.Dtos.UserCart;
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
    public interface IUserCartService:IManager<UserCartEntity>
    {
        public BusinessLayerResult<UserCartListDto> AddUserCart(UserCartDto usercartDto);
        public BusinessLayerResult<UserCartListDto> UpdateUserCart(UserCartDto usercartDto);
        public BusinessLayerResult<UserCartListDto> DeleteUserCart(long usercartId);
        public BusinessLayerResult<UserCartListDto> GetUserCart(long id);

        public BusinessLayerResult<List<UserCartListDto>> Filter(UserCartFilter usercartFilter);
        public BusinessLayerResult<UserCartLoadMoreDto> FilterUserCartList(BaseLoadMoreFilter<UserCartFilter> filter);
    }
}

