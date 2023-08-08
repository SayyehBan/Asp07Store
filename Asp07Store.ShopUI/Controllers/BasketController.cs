using Asp07Store.ShopUI.Models;

namespace Asp07Store.ShopUI.Controllers;

public class BasketController : Controller
{
    private readonly IProduct product;
    private readonly Basket sessionBasket;

    public BasketController(IProduct product, Basket sessionBasket)
    {
        this.product = product;
        this.sessionBasket = sessionBasket;
    }
    public IActionResult Index(string returnURL)
    {
        BasketPageViewModel basketPageViewModel = new ()
        {
            //basket = GetBasket(),
            basket=sessionBasket,
            ReturnURL = returnURL
        };

        return View(basketPageViewModel);
    }
    [HttpPost]
    public IActionResult AddToBasket(int ProductID, string returnURL)
    {
        var pro = product.GetById(ProductID);
        //var basket = GetBasket();
        //basket.Add(pro, 1);
        sessionBasket.Add(pro, 1);
        //SaveBasket(basket);
        return RedirectToAction("Index", new
        {
            returnURL = returnURL
        });
    }
    public IActionResult RemoveFromBasket(int ProductID, string returnURL)
    {
        var pro = product.GetById(ProductID);
        //var basket = GetBasket();
        //basket.Remove(pro);
        sessionBasket.Remove(pro);
        //SaveBasket(basket);
        return RedirectToAction("Index", new
        {
            returnURL = returnURL
        });
    }
    //private Basket GetBasket()
    //{
    //    return HttpContext.Session.GetJson<Basket>(DefaultValue.sessionKey);
    //}
    //private void SaveBasket(Basket basket)
    //{
    //    HttpContext.Session.SetJson(DefaultValue.sessionKey, basket);
    //}
}
