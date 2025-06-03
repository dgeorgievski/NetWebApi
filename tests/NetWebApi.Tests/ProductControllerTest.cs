namespace NetWebApi.Tests
{
    using Xunit;
    using Moq;
    using NetWebAPI.API.Controllers;
    using NetWebAPI.API.Models;
    using NetWebAPI.API.Services;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
        }

        [Fact]
        public async Task GetProductById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var productId = 1;
            var expectedProduct = new Product { Id = productId, Name = "Test Product" };
            _mockService.Setup(s => s.GetProductByIdAsync(productId)).ReturnsAsync(expectedProduct);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(expectedProduct.Id, returnedProduct.Id);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithProductList()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new() { Id = 1, Name = "Product A", Price = 10.99M },
                new() { Id = 2, Name = "Product B", Price = 15.99M }
            };

            _mockService.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(expectedProducts);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(expectedProducts.Count, returnedProducts.Count);
            Assert.Equal(expectedProducts[0].Name, returnedProducts[0].Name);
            Assert.Equal(expectedProducts[1].Price, returnedProducts[1].Price);
        }

        [Fact]
        public async Task AddProduct_ReturnsCreatedAtActionResult_WithNewProduct()
        {
            // Arrange
            var newProduct = new Product { Id = 3, Name = "New Product", Price = 20.99M };
            _mockService.Setup(s => s.AddProductAsync(It.IsAny<Product>())).ReturnsAsync(newProduct);

            // Act
            var result = await _controller.AddProduct(newProduct);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedProduct = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(newProduct.Id, returnedProduct.Id);
            Assert.Equal(newProduct.Name, returnedProduct.Name);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNoContent_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            _mockService.Setup(s => s.DeleteProductAsync(productId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 99; // Assume this product does not exist
            _mockService.Setup(s => s.DeleteProductAsync(productId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
