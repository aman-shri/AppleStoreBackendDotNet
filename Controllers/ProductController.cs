using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("products")]
    public IActionResult GetAllProducts()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("product/{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productService.GetProductById(id);
        if(product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost("buy/{id}")]
    public IActionResult BuyProduct(int id)
    {
        var success = _productService.BuyProduct(id);
        if(!success)
        {
            return BadRequest("Product is either sold out or not found");
        }
        return Ok("Product purchased successfully.");
    }

    [HttpGet("lastcustomer")]
    public IActionResult GetLastCustomer()
    {
        var customer = _productService.GetLastCustomer();
        return Ok(customer);
    }
}