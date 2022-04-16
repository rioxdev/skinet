using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task<T> Get(ISpecification<T> spec);
        
        Task<List<T>> GetAll(ISpecification<T> spec);

        Task<int> Count(ISpecification<T> spec);    
    }
}
