using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductType> typeRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var spec = new ProductWithTypesAndBrandsSpec();

            var products = await _productRepo.GetAll(spec);

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(products));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpec(id);

            var product = await _productRepo.Get(spec);

            return Ok(_mapper.Map<Product, ProductDto>(product));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {

            return Ok(await _brandRepo.GetAll());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {

            return Ok(await _typeRepo.GetAll());
        }

    }
}
