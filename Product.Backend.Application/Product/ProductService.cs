using Microsoft.EntityFrameworkCore;
using Product.Backend.Domain;
using Product.Backend.Infrastructure;


namespace Product.Backend.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<ProductEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> SaveAsync(ProductDto newProduct)
        {
            var entity = new ProductEntity
            {
                ProductId = new Guid(),
                Code = newProduct.Code,
                Description = newProduct.Description,
                Name = newProduct.Name,
                IsActive = newProduct.IsActive
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
