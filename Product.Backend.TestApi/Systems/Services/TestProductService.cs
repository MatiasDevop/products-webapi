using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Product.Backend.Application.Product;
using Product.Backend.Infrastructure;
using Product.Backend.TestApi.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Backend.TestApi.Systems.Services
{
    public class TestProductService : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public TestProductService()
        {
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

            var sut = new ProductService(_dbContext);

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

            var sut = new ProductService(_dbContext);

            //Act
            await sut.SaveAsync(newProduct);

            //Assert
            int expectedRecordCount = ProductMockData.GetProducts().Count + 1;
            _dbContext.Products.Count().Should().Be(expectedRecordCount);
        }
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
        
    }
}
