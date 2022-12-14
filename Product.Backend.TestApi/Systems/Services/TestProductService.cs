using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Product.Backend.Application.Mapper;
using Product.Backend.Application.Product;
using Product.Backend.Infrastructure;
using Product.Backend.TestApi.MockData;

namespace Product.Backend.TestApi.Systems.Services
{
    public class TestProductService : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public TestProductService()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            
            // Setup Inmemory 
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureCreated();
            
        }

        [Fact]
        public async Task GetAllAsync_ReturnProductGetCollection()
        {
            //Arrange
            _dbContext.Products.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();

            var sut = new ProductService(_dbContext, _mapper);

            //Act
            var result = await sut.GetAllAsync();

            //Assert
            result.Should().HaveCount(ProductMockData.GetProducts().Count);
        }

        [Fact]
        public async Task SaveAsync_AddNewProduct()
        {
            //Arrange
            _dbContext.Products.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();

            var newProduct = ProductMockData.AddProduct();

            var sut = new ProductService(_dbContext, _mapper);

            //Act
            await sut.SaveAsync(newProduct);

            //Assert
            int expectedRecordCount = ProductMockData.GetProducts().Count + 1;
            _dbContext.Products.Count().Should().Be(expectedRecordCount);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnSuccess()
        {
            //Arrange
            _dbContext.Products.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();
            var idProduct = new Guid("a63797fa-1c14-438c-8df9-7a07d83091ed");

            var sut = new ProductService(_dbContext, _mapper);

            //Act
            var result = await sut.GetByIdAsync(idProduct);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ProductMockData.GetProducts()[0].ProductId, result.ProductId);
            Assert.True(ProductMockData.GetProducts()[0].ProductId == result.ProductId);
            
        }
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
        
    }
}
