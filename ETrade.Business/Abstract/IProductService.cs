using ETrade.Dto.Dtos.Product;
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
    public interface IProductService:IManager<ProductEntity>
    {
        public BusinessLayerResult<ProductListDto> AddProduct(ProductDto productDto);
        public BusinessLayerResult<ProductListDto> UpdateProduct(ProductDto productDto);
        public BusinessLayerResult<ProductListDto> DeleteProduct(long productId);
        public BusinessLayerResult<ProductListDto> GetProduct(long id);

        public BusinessLayerResult<List<ProductListDto>> Filter(ProductFilter productFilter);
        public BusinessLayerResult<ProductLoadMoreDto> FilterProductList(BaseLoadMoreFilter<ProductFilter> filter);
    }
}
