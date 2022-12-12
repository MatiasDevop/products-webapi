using Product.Backend.Application.Product;
using Product.Backend.Domain;

namespace Product.Backend.TestApi.MockData
{
    public class ProductMockData
    {
        public static List<ProductEntity> GetProducts()
        {
            return new List<ProductEntity> {
                new ProductEntity {
                    ProductId = new Guid("a63797fa-1c14-438c-8df9-7a07d83091ed"),
                    Name = "DC",
                    Code = "ffff2",
                    Description = "Movies",
                    IsActive = true
                },
                new ProductEntity {
                    ProductId = new Guid("3addc985-b9c5-4620-bfe1-16ad88e383c1"),
                    Name = "item2",
                    Code = "123d",
                    Description = "electronics",
                    IsActive = true
                },
                new ProductEntity {
                    ProductId = new Guid("387f127c-c6a7-461b-a836-2d9078bc5bdb"),
                    Name = "item3",
                    Code = "x3x3",
                    Description = "electronics",
                    IsActive = true
                }
            };
        }

        public static List<ProductEntity> EmptyList()
        {
            return new List<ProductEntity>();
        }

        public static ProductDto AddProduct()
        {
            return new ProductDto
            {
                ProductId = new Guid("43f3444b-bcf1-47a4-9d83-38a5feb4ae9a"),
                Name = "item67660",
                Code = "x3x2s",
                Description = "Electronic",
                IsActive = true
            };
        }
    }
}
