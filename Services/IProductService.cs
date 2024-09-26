public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    bool BuyProduct(int id);
    Customer GetLastCustomer();
}