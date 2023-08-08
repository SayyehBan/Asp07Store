using Asp07Store.ShopUI.Models;

namespace Asp07Store.ShopUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly Basket basket;

        public OrderController(IOrders orders, Basket basket)
        {
            this.orders = orders;
            this.basket = basket;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(CheckoutViewModel model)
        {
            if (!basket.Items.Any())
            {
                ModelState.AddModelError("توجه", "محصولی در سبد کالا نیست");
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                };
                foreach (var item in basket.Items)
                {
                    order.orderDetails.Add(new OrderDetail
                    {
                        Product = item.Product,
                        Quantity = item.Quantity,
                    });
                }
                orders.Save(order);
                basket.Clear(); 
                return RedirectToAction("Compelete");
            }
            return View(model);
        }
        public IActionResult Compelete()
        {
            return View();
        }
    }
}
