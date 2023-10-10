using ETrade.Dto.Dtos.Identity;
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
    public interface IIdentityService:IManager<IdentityEntity>
    {
        public BusinessLayerResult<IdentityListDto> AddIdentity(string password, string userName, long userId);
        //public BusinessLayerResult<IdentityListDto> UpdateIdentity(IdentityDto identityDto);
        //public BusinessLayerResult<IdentityListDto> DeleteIdentity(long identityId);
        //public BusinessLayerResult<IdentityListDto> GetIdentity(string username);

        //public BusinessLayerResult<List<IdentityListDto>> Filter(IdentityFilter identityFilter);
        //public BusinessLayerResult<IdentityLoadMoreDto> FilterIdentityList(BaseLoadMoreFilter<IdentityFilter> filter);
        public BusinessLayerResult<IdentityListDto> ChangePassword(IdentityDto identityDto);
        public BusinessLayerResult<IdentityListDto> CheckPassword(IdentityDto identityDto);



    }
}
