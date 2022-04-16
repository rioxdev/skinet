using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpec : BaseSpecification<Product>
    {

        public ProductWithTypesAndBrandsSpec(ProductSpecParams productParams) :
            base(p => (String.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                      (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
                      (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)
                )
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            AddOrderBy(x => x.Name);

            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!String.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc": AddOrderBy(x => x.Price); break;
                    case "priceDesc": AddOrderByDescending(x => x.Price); break;
                    default: AddOrderBy(x => x.Name); break;
                }
            }

        }

        public ProductWithTypesAndBrandsSpec(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}
