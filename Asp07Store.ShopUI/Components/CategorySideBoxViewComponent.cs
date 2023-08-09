using Asp07Store.ShopUI.Models;

namespace Asp07Store.ShopUI.Components;

public class CategorySideBoxViewComponent : ViewComponent
{
    private readonly ICategory category;

    public CategorySideBoxViewComponent(ICategory category)
    {
        this.category = category;
    }
    public IViewComponentResult Invoke()
    {
        var currentCategory = RouteData?.Values["category"];
        ViewBag.Category = currentCategory;
        return View(category.GetAllCategories());
    }
}
