using ETrade.Dto.Dtos.Session;
using ETrade.Dto.Dtos.Session;
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
    public interface ISessionService:IManager<SessionEntity>
    {
        public BusinessLayerResult<SessionListDto> AddSession(SessionDto sessionDto);
        public BusinessLayerResult<SessionListDto> UpdateSession(SessionDto sessionDto);
        public BusinessLayerResult<SessionListDto> DeleteSession(long sessionId);
        public BusinessLayerResult<SessionListDto> GetSession(long id);

        public BusinessLayerResult<List<SessionListDto>> Filter(SessionFilter sessionFilter);
        public BusinessLayerResult<SessionLoadMoreDto> FilterSessionList(BaseLoadMoreFilter<SessionFilter> filter);

        public BusinessLayerResult<SessionListDto> GetSessionByToken(Guid token);

        public BusinessLayerResult<SessionListDto> GetSessionByIpAddress(string ipAdress);
    }

}
