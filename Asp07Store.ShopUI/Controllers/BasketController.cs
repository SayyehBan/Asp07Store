using Asp07Store.ShopUI.Models;
using Asp07Store.ShopUI.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp07Store.ShopUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProduct product;

        public BasketController(IProduct product)
        {
            this.product = product;
        }
        public IActionResult Index(string returnURL)
        {
            BasketPageViewModel basketPageViewModel = new BasketPageViewModel
            {
                basket = GetBasket(),
                ReturnURL = returnURL
            };

            return View(basketPageViewModel);
        }
        [HttpPost]
        public IActionResult AddToBasket(int ProductID, string returnURL)
        {
            var pro = product.GetById(ProductID);
            var basket = GetBasket();
            basket.Add(pro, 1);
            SaveBasket(basket);
            return RedirectToAction("Index", new
            {
                returnURL = returnURL
            });
        }
        public IActionResult RemoveFromBasket(int ProductID, string returnURL)
        {
            var pro = product.GetById(ProductID);
            var basket = GetBasket();
            basket.Remove(pro);
            SaveBasket(basket);
            return RedirectToAction("Index", new
            {
                returnURL = returnURL
            });
        }
        private Basket GetBasket()
        {
            var basketString = HttpContext.Session.GetString("Basket");
            if (string.IsNullOrEmpty(basketString))
            {
                return new Basket();
            }
            return JsonConvert.DeserializeObject<Basket>(basketString);

        }
        private void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
        }
    }
}
