namespace NetWebAPI.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using NetWebAPI.API.Models;
  public class ProductController : ControllerBase
  {
    private static readonly List<Product> Products =
    [
        new Product(1, "Laptop", "High performance laptop", 999.99m),
        new Product(2, "Smartphone", "Latest model smartphone", 699.99m),
        new Product(3, "Tablet", "Portable tablet with stylus", 499.99m)
    ];

    [HttpGet("api/products")]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
      return Ok(Products);
    }

    [HttpGet("api/products/{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
      var product = Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
      {
        return NotFound();
      }
      return Ok(product);
    }

    [HttpPost("api/products")]
    public ActionResult<Product> CreateProduct([FromBody] Product product)
    {
      if (product == null || string.IsNullOrEmpty(product.Name) || product.Price <= 0)
      {
        return BadRequest("Invalid product data.");
      }

      product.Id = Products.Max(p => p.Id) + 1; // Simple ID generation
      Products.Add(product);
      return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("api/products/{id}")]
    public ActionResult<Product> UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
      if (updatedProduct == null || string.IsNullOrEmpty(updatedProduct.Name) || updatedProduct.Price <= 0)
      {
        return BadRequest("Invalid product data.");
      }

      var product = Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
      {
        return NotFound();
      }

      product.Name = updatedProduct.Name;
      product.Description = updatedProduct.Description;
      product.Price = updatedProduct.Price;

      return Ok(product);
    }
    
    [HttpDelete("api/products/{id}")]
    public ActionResult DeleteProduct(int id)
    {
      var product = Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
      {
        return NotFound();
      }

      Products.Remove(product);
      return NoContent();
    }
  }
}
