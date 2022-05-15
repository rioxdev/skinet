using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetAsync(string id);
        Task<CustomerBasket> Update(CustomerBasket basket);
        Task<bool> DeleteAsync(string id);
    }
}
