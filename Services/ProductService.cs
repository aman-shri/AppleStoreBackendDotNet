using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name= "iPhone 16", Quantity = 10, Price = 79_900.00m},
        new Product { Id = 2, Name= "iPhone 16 Plus", Quantity = 8, Price = 89_900.00m},
        new Product { Id = 3, Name= "iPhone 16 Pro", Quantity = 5, Price = 1_19_900.00m},
        new Product { Id = 4, Name= "iPhone 16 Pro Max", Quantity = 5, Price = 1_44_900.00m},
        new Product { Id = 5, Name= "iPad Pro", Quantity = 5, Price = 89_900.00m},
        new Product { Id = 6, Name= "AirPods 4", Quantity = 25, Price = 12_900.00m},
        new Product { Id = 7, Name= "AirPods 4 with ANC", Quantity = 20, Price = 17_900.00m}
    };

    public IEnumerable<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public bool BuyProduct(int id)
    {
        var product = GetProductById(id);
        if (product != null && product.Quantity > 0)
        {
            product.Quantity--;
            return true;
        }
        return false;
    }

    public Customer GetLastCustomer()
    {
        using var client = new HttpClient();
        var result = client.GetStringAsync("https://randomuser.me/api/").Result;
        var customerData = JsonSerializer.Deserialize<JsonElement>(result);

        var firstName = customerData.GetProperty("results")[0].GetProperty("name").GetProperty("first").GetString();
        var lastName = customerData.GetProperty("results")[0].GetProperty("name").GetProperty("last").GetString();
        var email = customerData.GetProperty("results")[0].GetProperty("email").GetString();

        return new Customer { FirstName = firstName, LastName = lastName, Email = email };
    }
}