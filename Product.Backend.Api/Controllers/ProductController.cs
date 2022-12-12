using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Backend.Application.Product;

namespace Product.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productService.GetAllAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync(ProductDto newProduct)
        {
            var result = await _productService.SaveAsync(newProduct);
            
            if(result == null) return NoContent();

            return Ok(result);
        }
    }
}
