using Newtonsoft.Json.Bson;
using Xunit;

namespace AppleStoreBackend.Tests;

public class ProductServiceTests
{
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _service = new ProductService();
    }

    [Fact]
    public void ShouldReturnAllProductsWhenGetAllProductsCalled()
    {
        var products = _service.GetAllProducts();
        Assert.NotEmpty(products);
    }

    [Fact]
    public void ShouldReduceQuantityWhenExistingProductBought()
    {
        var initialProduct = _service.GetProductById(1);
        var initialQuantity = initialProduct.Quantity;

        var result = _service.BuyProduct(1);

        Assert.True(result);
        Assert.Equal(initialQuantity - 1, initialProduct.Quantity);
    }

    [Fact]
    public void ShouldReturnFalseWhenProductIsSoldOut()
    {
        var product = _service.GetProductById(2);
        product.Quantity = 0;

        var result = _service.BuyProduct(2);

        Assert.False(result);
    }


}