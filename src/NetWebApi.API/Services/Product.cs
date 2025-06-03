namespace NetWebAPI.API.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NetWebAPI.API.Models;

    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> _products = [];

        public Task<Product?> GetProductByIdAsync(int id)
        {
            var product = _products.Find(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product> AddProductAsync(Product product)
        {
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<Product?> UpdateProductAsync(Product product)
        {
            var existingProduct = _products.Find(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
            return Task.FromResult(existingProduct);
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
