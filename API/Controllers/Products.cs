using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly StoreContext _dbContext;

        public Products(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task< IActionResult> GetProduct()
        {
            return Ok(await _dbContext.Procucts.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _dbContext.Procucts.FindAsync(id));
        }
    }
}
