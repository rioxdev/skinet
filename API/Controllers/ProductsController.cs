using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _productRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productRepository.Get(id));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {

            return Ok(await _productRepository.GetBrands());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {

            return Ok(await _productRepository.GetTypes());
        }

    }
}
