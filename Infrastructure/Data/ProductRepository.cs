using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<List<ProductBrand>> GetBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<List<ProductType>> GetTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
