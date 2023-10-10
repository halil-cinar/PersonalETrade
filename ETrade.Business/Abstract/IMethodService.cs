using ETrade.Dto.Dtos.Method;
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
    public interface IMethodService:IManager<MethodEntity>
    {
        public BusinessLayerResult<MethodListDto> AddMethod(MethodDto methodDto);
        public BusinessLayerResult<MethodListDto> UpdateMethod(MethodDto methodDto);
        public BusinessLayerResult<MethodListDto> DeleteMethod(long methodId);
        public BusinessLayerResult<MethodListDto> GetMethod(long id);

        public BusinessLayerResult<List<MethodListDto>> Filter(MethodFilter methodFilter);
        public BusinessLayerResult<MethodLoadMoreDto> FilterMethodList(BaseLoadMoreFilter<MethodFilter> filter);
    }
}
