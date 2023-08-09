using Asp07Store.ShopUI.Models;

public class CategoryRepository : ICategory
{
    private readonly StoreDbContext storeDbContext;

    public CategoryRepository(StoreDbContext storeDbContext)
    {
        this.storeDbContext = storeDbContext;
    }

    public List<string> GetAllCategories() => storeDbContext.Categories.Select(c => c.Name).ToList();
}
