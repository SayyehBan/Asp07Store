using Asp07Store.ShopUI.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp07Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct iproduct;
        private int pageSize = 4;

        public HomeController(IProduct iproduct)
        {
            this.iproduct = iproduct;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            return View(iproduct.GetAll(pageNumber, pageSize));
        }
    }
}
