using ETrade.Dto.Dtos.RoleMethod;
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
    public interface IRoleMethodService:IManager<RoleMethodEntity>
    {
        public BusinessLayerResult<RoleMethodListDto> AddRoleMethod(RoleMethodDto roleMethodDto);
        public BusinessLayerResult<RoleMethodListDto> UpdateRoleMethod(RoleMethodDto roleMethodDto);
        public BusinessLayerResult<RoleMethodListDto> DeleteRoleMethod(long roleMethodId);
        public BusinessLayerResult<RoleMethodListDto> GetRoleMethod(long id);

        public BusinessLayerResult<List<RoleMethodListDto>> Filter(RoleMethodFilter roleMethodFilter);
        public BusinessLayerResult<RoleMethodLoadMoreDto> FilterRoleMethodList(BaseLoadMoreFilter<RoleMethodFilter> filter);
    }
}
