using StoneSafety.Data;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoneSafety.ViewModels.CheckOut;
using System.Text;
using StoneSafety.Services;

namespace StoneSafety.Controllers
{
    public class CardController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IEmailService _emailService;

        public CardController(IHttpContextAccessor accessor,
                              AppDbContext context,
                              IProductService productService,
                              IEmailService emailService)
        {
            _accessor = accessor;
            _context = context;
            _productService = productService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BasketVM> basketDatas = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }

            var dbProducts = await _productService.GetAllAsync();
            List<BasketProductVM> basketProducts = new();

            foreach (var item in basketDatas)
            {
                var dbProduct = dbProducts.FirstOrDefault(m => m.Id == item.Id);

                if (dbProduct != null)
                {
                    basketProducts.Add(new BasketProductVM
                    {
                        Id = dbProduct.Id,
                        Name = dbProduct.Name,
                        Description = dbProduct.Description,
                        MainImage = dbProduct.ProductImages.FirstOrDefault(m => m.IsMain)?.Name,
                        Price = dbProduct.Price,
                        Count = item.Count
                    });
                }
            }

            BasketDetailVM basketDetail = new()
            {
                Products = basketProducts,
                TotalPrice = basketDatas.Sum(m => m.Count * m.Price),
                TotalCount = basketDatas.Sum(m => m.Count) // Исправлено: теперь сумма количества всех товаров
            };

            return View(basketDetail);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] BasketVM basketItem)
        {
            if (basketItem == null) return BadRequest();

            List<BasketVM> basketDatas = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }

            var existingItem = basketDatas.FirstOrDefault(b => b.Id == basketItem.Id);
            if (existingItem != null)
            {
                existingItem.Count += 1;
            }
            else
            {
                basketItem.Count = 1;
                basketDatas.Add(basketItem);
            }

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));

            int totalCount = basketDatas.Sum(b => b.Count);
            decimal totalPrice = basketDatas.Sum(b => b.Price * b.Count);

            var result = new
            {
                basketCount = totalCount,
                totalPrice = totalPrice
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult UpdateProductQuantity([FromBody] BasketVM basketItem)
        {
            if (basketItem == null) return BadRequest("Basket item is null.");

            List<BasketVM> basketDatas = new List<BasketVM>();

            var basketCookie = _accessor.HttpContext.Request.Cookies["basket"];
            if (basketCookie != null)
            {
                try
                {
                    basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
                }
                catch (JsonException ex)
                {
                    return BadRequest($"Error deserializing basket cookie: {ex.Message}");
                }
            }

            basketDatas = basketDatas ?? new List<BasketVM>();

            var existingItem = basketDatas.FirstOrDefault(b => b.Id == basketItem.Id);
            if (existingItem != null)
            {
                existingItem.Count += basketItem.Count; // Increment count
                if (existingItem.Count <= 0) // Remove item if count is zero or less
                {
                    basketDatas.Remove(existingItem);
                }
            }
            else
            {
                basketDatas.Add(basketItem); // Add new item if not exists
            }

            var updatedBasketData = JsonConvert.SerializeObject(basketDatas);
            _accessor.HttpContext.Response.Cookies.Append("basket", updatedBasketData, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7), // Example expiration
                HttpOnly = true,
                Secure = true // Only if using HTTPS
            });

            int totalCount = basketDatas.Sum(b => b.Count);
            decimal totalPrice = basketDatas.Sum(b => b.Price * b.Count);

            return Ok(new
            {
                basketCount = totalCount,               
                totalPrice
            });
        }

        [HttpPost]
        public IActionResult DeleteProductFromBasket([FromBody] BasketVM basketItem)
        {
            if (basketItem == null) return BadRequest("Basket item is null.");

            List<BasketVM> basketDatas = new List<BasketVM>();

            var basketCookie = _accessor.HttpContext.Request.Cookies["basket"];
            if (basketCookie != null)
            {
                try
                {
                    basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
                }
                catch (JsonException ex)
                {
                    return BadRequest($"Error deserializing basket cookie: {ex.Message}");
                }
            }

            basketDatas = basketDatas ?? new List<BasketVM>();

            basketDatas = basketDatas.Where(b => b.Id != basketItem.Id).ToList();

            var updatedBasketData = JsonConvert.SerializeObject(basketDatas);
            _accessor.HttpContext.Response.Cookies.Append("basket", updatedBasketData, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7), // Example expiration
                HttpOnly = true,
                Secure = true // Only if using HTTPS
            });

            int totalCount = basketDatas.Sum(b => b.Count);
            decimal totalPrice = basketDatas.Sum(b => b.Price * b.Count);

            return Ok(new
            {
                basketCount = totalCount,               
                totalPrice
            });        

        }

        [HttpPost]
        public async Task <IActionResult> CheckOutEmailSend (CheckOutVM checkOut)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction(nameof(Index));
            }

            List<BasketVM> basketDatas = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }

            var dbProducts = await _productService.GetAllAsync();
            List<BasketProductVM> basketProducts = new();

            foreach (var item in basketDatas)
            {
                var dbProduct = dbProducts.FirstOrDefault(m => m.Id == item.Id);

                if (dbProduct != null)
                {
                    basketProducts.Add(new BasketProductVM
                    {
                        Id = dbProduct.Id,
                        Name = dbProduct.Name,
                        Description = dbProduct.Description,
                        MainImage = dbProduct.ProductImages.FirstOrDefault(m => m.IsMain)?.Name,
                        Price = dbProduct.Price,
                        Count = item.Count
                    });
                }
            }

            var emailBody = new StringBuilder();

            emailBody.AppendLine("Your order has been placed successfully. Here are the details:");
            emailBody.AppendLine();
            emailBody.AppendLine($"Name: {checkOut.Name}, Surname: {checkOut.SurName}, Email: {checkOut.Email}, Phone: {checkOut.Phone},");


            foreach (var item in basketProducts)
            {
                emailBody.AppendLine($"Item: {item.Name}, Count: {item.Count}, Price: {item.Price}");
            }
            var userinfo = emailBody.ToString();

            _emailService.Send("amirastan.mereyev@gmail.com", "Sorgu", emailBody.ToString());

            Response.Cookies.Delete("basket");

            return RedirectToAction("Index","Home");
        }

    }
         

}
