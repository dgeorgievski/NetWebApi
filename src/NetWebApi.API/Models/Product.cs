namespace NetWebAPI.API.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public Product() { }

    public Product(int id, string name, string description, decimal price )
    {
      Id = id;
      Name = name;
      Description = description;
      Price = price;
    }
  }
}
