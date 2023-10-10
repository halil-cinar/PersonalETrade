using ETrade.Dto.Dtos.Notify;
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
    public interface INotifyService:IManager<NotifyEntity>
    {
        public BusinessLayerResult<NotifyListDto> AddNotify(NotifyDto notifyDto);
        public BusinessLayerResult<NotifyListDto> UpdateNotify(NotifyDto notifyDto);
        public BusinessLayerResult<NotifyListDto> DeleteNotify(long notifyId);
        public BusinessLayerResult<NotifyListDto> GetNotify(long id);
        public BusinessLayerResult<NotifyListDto> GetNotifyByToken(string token);


        public BusinessLayerResult<List<NotifyListDto>> Filter(NotifyFilter notifyFilter);
        public BusinessLayerResult<NotifyLoadMoreDto> FilterNotifyList(BaseLoadMoreFilter<NotifyFilter> filter);

    }
}
