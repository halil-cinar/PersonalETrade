using ETrade.Dto.Dtos.Category;
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
    public interface ICategoryService:IManager<CategoryEntity>
    {
        public BusinessLayerResult<CategoryListDto> AddCategory(CategoryDto categoryDto);
        public BusinessLayerResult<CategoryListDto> UpdateCategory(CategoryDto categoryDto);
        public BusinessLayerResult<CategoryListDto> DeleteCategory(long categoryId);
        public BusinessLayerResult<CategoryListDto> GetCategory(long id);

        public BusinessLayerResult<List<CategoryListDto>> Filter(CategoryFilter categoryFilter);
        public BusinessLayerResult<CategoryLoadMoreDto> FilterCategoryList(BaseLoadMoreFilter<CategoryFilter> filter);
    }
}
