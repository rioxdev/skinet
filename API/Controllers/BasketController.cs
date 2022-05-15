using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepo;

        public BasketController(IBasketRepository basketRepo)
        {
            _basketRepo = basketRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepo.GetAsync(id);

            return Ok(basket?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> Update(CustomerBasket basket)
        {
            var updated = await _basketRepo.Update(basket);

            return Ok(updated);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _basketRepo.DeleteAsync(id);
        }

    }
}
