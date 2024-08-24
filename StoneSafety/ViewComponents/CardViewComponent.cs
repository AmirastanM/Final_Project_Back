using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Baskets;

namespace StoneSafety.ViewComponents
{
    public class CardViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;
        private readonly AppDbContext _context;

        public CardViewComponent(IProductService productService, IHttpContextAccessor accessor, AppDbContext context)
        {
            _productService = productService;
            _accessor = accessor;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Получаем данные корзины из куки
            var basketCookie = _accessor.HttpContext.Request.Cookies["basket"];
            var basketDatas = basketCookie != null
                ? JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie)
                : new List<BasketVM>();

            // Загружаем все продукты, которые есть в корзине
            var productIds = basketDatas.Select(item => item.Id).ToList();
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            // Создаем список CardVM для отображения
            var items = products.Select(product => new CardVM
            {
                Id = product.Id,
                Image = product.ProductImages.FirstOrDefault(m => m.IsMain)?.Name,
                Name = product.Name,
                Description = product.Description,
                Count = basketDatas.FirstOrDefault(m => m.Id == product.Id)?.Count ?? 0,
                Price = product.Price
            }).ToList();

            // Подсчитываем общую стоимость
            var totalPrice = basketDatas.Sum(m => m.Price * m.Count);

            var model = new TotalBasketVM
            {
                Product = items,
                Price = totalPrice
            };

            return View(model);
        }
    }

    public class CardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }

    public class TotalBasketVM
    {
        public List<CardVM> Product { get; set; }
        public decimal Price { get; set; }
    }
}
