using ETrade.Dto.Dtos.Status;
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
    public interface IStatusService:IManager<StatusEntity>
    {
        public BusinessLayerResult<StatusListDto> AddStatus(StatusDto statusDto);
        public BusinessLayerResult<StatusListDto> UpdateStatus(StatusDto statusDto);
        public BusinessLayerResult<StatusListDto> DeleteStatus(long statusId);
        public BusinessLayerResult<StatusListDto> GetStatus(long id);

        public BusinessLayerResult<List<StatusListDto>> Filter(StatusFilter statusFilter);
        public BusinessLayerResult<StatusLoadMoreDto> FilterStatusList(BaseLoadMoreFilter<StatusFilter> filter);
    }
}

