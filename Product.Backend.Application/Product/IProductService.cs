using Product.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Backend.Application.Product
{
    public interface IProductService
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task<ProductEntity> SaveAsync(ProductDto newProduct);
    }
}
