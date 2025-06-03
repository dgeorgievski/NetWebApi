namespace NetWebAPI.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using NetWebAPI.API.Models;
  using NetWebAPI.API.Services;
  public class ProductController(IProductService productService) : ControllerBase
  {
    private readonly IProductService _productService = productService;
    private static readonly List<Product> Products =
    [
        new Product(1, "Laptop", "High performance laptop", 999.99m),
        new Product(2, "Smartphone", "Latest model smartphone", 699.99m),
        new Product(3, "Tablet", "Portable tablet with stylus", 499.99m)
    ];

    [HttpGet("api/products")]
    public async Task<IActionResult> GetAllProducts() =>
      Ok(await _productService.GetAllProductsAsync());

    [HttpGet("api/products/{id:int}")]
    public async Task<IActionResult> GetProductById(int id) =>
        await _productService.GetProductByIdAsync(id) is { } product
            ? Ok(product)
            : NotFound();
    // public ActionResult<Product> GetProduct(int id)
    // {
    //   var product = Products.FirstOrDefault(p => p.Id == id);
    //   if (product == null)
    //   {
    //     return NotFound();
    //   }
    //   return Ok(product);
    // }

    [HttpPost("api/products")]
     public async Task<IActionResult> AddProduct([FromBody] Product product) =>
        product is null
            ? BadRequest()
            : CreatedAtAction(nameof(GetProductById),
                              new { id = (await _productService.AddProductAsync(product)).Id },
                              product);

    // public ActionResult<Product> CreateProduct([FromBody] Product product)
    // {
    //   if (product == null || string.IsNullOrEmpty(product.Name) || product.Price <= 0)
    //   {
    //     return BadRequest("Invalid product data.");
    //   }

    //   product.Id = Products.Max(p => p.Id) + 1; // Simple ID generation
    //   Products.Add(product);
    //   return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    // }

    [HttpPut("api/products/{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product) =>
        product is null || product.Id != id
            ? BadRequest()
            : Ok(await _productService.UpdateProductAsync(product));

    // public ActionResult<Product> UpdateProduct(int id, [FromBody] Product updatedProduct)
    // {
    //   if (updatedProduct == null || string.IsNullOrEmpty(updatedProduct.Name) || updatedProduct.Price <= 0)
    //   {
    //     return BadRequest("Invalid product data.");
    //   }

    //   var product = Products.FirstOrDefault(p => p.Id == id);
    //   if (product == null)
    //   {
    //     return NotFound();
    //   }

    //   product.Name = updatedProduct.Name;
    //   product.Description = updatedProduct.Description;
    //   product.Price = updatedProduct.Price;

    //   return Ok(product);
    // }

    [HttpDelete("api/products/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id) =>
        await _productService.DeleteProductAsync(id)
            ? NoContent()
            : NotFound();
    // public ActionResult DeleteProduct(int id)
    // {
    //   var product = Products.FirstOrDefault(p => p.Id == id);
    //   if (product == null)
    //   {
    //     return NotFound();
    //   }

    //   Products.Remove(product);
    //   return NoContent();
    // }
  }
}
