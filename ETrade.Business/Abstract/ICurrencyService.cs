using ETrade.Dto.Dtos.Currency;
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
    public interface ICurrencyService:IManager<CurrencyEntity>
    {
        public BusinessLayerResult<CurrencyListDto> AddCurrency(CurrencyDto currencyDto);
        public BusinessLayerResult<CurrencyListDto> UpdateCurrency(CurrencyDto currencyDto);
        public BusinessLayerResult<CurrencyListDto> DeleteCurrency(long currencyId);
        public BusinessLayerResult<CurrencyListDto> GetCurrency(long id);

        public BusinessLayerResult<List<CurrencyListDto>> Filter(CurrencyFilter currencyFilter);
        public BusinessLayerResult<CurrencyLoadMoreDto> FilterCurrencyList(BaseLoadMoreFilter<CurrencyFilter> filter);
    }
}
