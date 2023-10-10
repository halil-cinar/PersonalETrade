using ETrade.Dto.Dtos.Address;
using ETrade.Dto.Filters;
using ETrade.Dto.LoadMoreDtos;
using ETrade.Dto.Result;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IAddressService:IManager<AddressEntity>
    {
        public BusinessLayerResult<AddressListDto> AddAddress(AddressDto addressDto);
        public BusinessLayerResult<AddressListDto> UpdateAddress(AddressDto addressDto);
        public BusinessLayerResult<AddressListDto> DeleteAddress(long addressId);
        public BusinessLayerResult<AddressListDto> GetAddress(long id);

        public BusinessLayerResult<List<AddressListDto>> Filter(AddressFilter addressFilter);
        public BusinessLayerResult<AddressLoadMoreDto> FilterAddressList(BaseLoadMoreFilter<AddressFilter> filter);
    }
}
