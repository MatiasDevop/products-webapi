using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Backend.Domain;
using Product.Backend.Infrastructure;

namespace Product.Backend.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            return await _context.Products.Where(x => x.ProductId == id).FirstAsync();
        }

        public async Task<ProductEntity> SaveAsync(ProductDto newProduct)
        {
            var entity = _mapper.Map<ProductEntity>(newProduct); 
      
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
