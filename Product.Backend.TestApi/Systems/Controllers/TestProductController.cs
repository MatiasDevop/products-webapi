
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Product.Backend.Api.Controllers;
using Product.Backend.Application.Product;
using Product.Backend.TestApi.MockData;

namespace Product.Backend.TestApi.Systems.Controllers
{
    public class TestProductController
    {
        private readonly Mock<IProductService> productService;
        public TestProductController()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetAllASync_ShouldReturn200Status()
        {
            //Arrange
            //var proService = new Mock<IProductService>();
            //proService.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.GetProducts());
            var listProducts = ProductMockData.GetProducts();
            productService.Setup(x => x.GetAllAsync()).ReturnsAsync(listProducts);

            //sut = system under test
            var sut = new ProductController(productService.Object);
            
            //Act
            var result = await sut.GetAllAsync();

            ///Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        //[Fact]
        //public async Task GetAllASync_ShouldReturnStatus204()
        //{
        //    //Arrange
        //    var proService = new Mock<IProductService>();
        //    proService.Setup(x => x.GetAllAsync()).ReturnsAsync(ProductMockData.EmptyList()); //
        //    //sut = system under test
        //    var sut = new ProductController(proService.Object);

        //    //Act
        //    var result = await sut.GetAllAsync();

        //    ///Assert
        //    result.GetType().Should().Be(typeof(NoContentResult));
        //    (result as NoContentResult).StatusCode.Should().Be(204);
        //}

        //[Fact]
        //public async Task SaveAsync_ShouldCallProductSaveAsyncOnce()
        //{
        //    //Arrange
        //    var proService = new Mock<IProductService>();
        //    var newPro = ProductMockData.AddProduct();
        //    var sut = new ProductController(proService.Object);

        //    //Act
        //    var result = await sut.SaveAsync(newPro);

        //    //Assert
        //    proService.Verify(x => x.SaveAsync(newPro), Times.Exactly(1));
        //}
    }
}
