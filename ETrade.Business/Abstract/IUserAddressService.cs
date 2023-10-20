using ETrade.Dto.Dtos.UserAddress;
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
    public interface IUserAddressService:IManager<UserAddressEntity>
    {
        public BusinessLayerResult<UserAddressListDto> AddUserAddress(UserAddressDto useraddressDto);
        public BusinessLayerResult<UserAddressListDto> UpdateUserAddress(UserAddressDto useraddressDto);
        public BusinessLayerResult<UserAddressListDto> DeleteUserAddress(long useraddressId);
        public BusinessLayerResult<UserAddressListDto> GetUserAddress(long id);

        public BusinessLayerResult<List<UserAddressListDto>> Filter(UserAddressFilter useraddressFilter);
        public BusinessLayerResult<UserAddressLoadMoreDto> FilterUserAddressList(BaseLoadMoreFilter<UserAddressFilter> filter);
    }
}

