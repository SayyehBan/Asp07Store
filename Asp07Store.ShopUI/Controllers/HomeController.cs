using Asp07Store.ShopUI.Models;
using Asp07Store.ShopUI.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp07Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct iproduct;
        private int pageSize = 2;

        public HomeController(IProduct iproduct)
        {
            this.iproduct = iproduct;
        }
        public IActionResult Index(string category = "", int pageNumber = 1)
        {
            var viewModel = new ProductListViewModel
            {
                CurrentCategory = category,
                Data = iproduct.GetAll(pageNumber, pageSize, category)
            };
            return View(viewModel);
        }
    }
}
