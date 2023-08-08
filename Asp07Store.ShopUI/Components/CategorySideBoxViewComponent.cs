using Asp07Store.ShopUI.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp07Store.ShopUI.Components
{
    public class CategorySideBoxViewComponent : ViewComponent
    {
        private readonly IProduct product;

        public CategorySideBoxViewComponent(IProduct product)
        {
            this.product = product;
        }
        public IViewComponentResult Invoke()
        {
            var currentCategory = RouteData?.Values["category"];
            ViewBag.Category = currentCategory;
            return View(product.GetAllCategories());
        }
    }
}
