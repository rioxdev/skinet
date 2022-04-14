using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);

        Task<List<Product>> GetAll();

        Task<List<ProductBrand>> GetBrands();

        Task<List<ProductType>> GetTypes();
    }
}
