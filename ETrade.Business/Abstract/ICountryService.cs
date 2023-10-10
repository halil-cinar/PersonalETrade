using ETrade.Dto.Dtos.Country;
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
    public interface ICountryService:IManager<CountryEntity>
    {
        public BusinessLayerResult<CountryListDto> AddCountry(CountryDto countryDto);
        public BusinessLayerResult<CountryListDto> UpdateCountry(CountryDto countryDto);
        public BusinessLayerResult<CountryListDto> DeleteCountry(long countryId);
        public BusinessLayerResult<CountryListDto> GetCountry(long id);

        public BusinessLayerResult<List<CountryListDto>> Filter(CountryFilter countryFilter);
        public BusinessLayerResult<CountryLoadMoreDto> FilterCountryList(BaseLoadMoreFilter<CountryFilter> filter);
    }
}
