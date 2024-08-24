using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewComponents;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    public async Task<IActionResult> Index()
    {
        // Get the products from the service
        var products = await _productService.GetAllAsync();

        // Return the view with the products
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductDetails(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var mainImage = product.ProductImages.FirstOrDefault(i => i.IsMain)?.Name;

        var productDetails = new
        {
            name = product.Name,
            mainImage = mainImage,
            description = product.Description,
            price = product.Price,
            productCode = product.ProductCode,
            rating = product.Rating
        };

        return Json(productDetails);
    }



}
