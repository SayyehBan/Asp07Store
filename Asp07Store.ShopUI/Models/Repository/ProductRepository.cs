using Asp07Store.ShopUI.Models.Interface;

namespace Asp07Store.ShopUI.Models.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly StoreDbContext storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public PageData<Product> GetAll(int pageNumber, int pageSize, string category)
        {
            var result = new PageData<Product>
            {
                pageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber,

                }
            };

            result.Data = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category == category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.pageInfo.TotalCount = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category == category).Count();
            return result;
        }

        public List<string> GetAllCategories() => storeDbContext.Products.Select(c => c.Category).Distinct().ToList();

        public Product GetById(int id)
        {
            return storeDbContext.Products.FirstOrDefault(c => c.Id == id);
        }
    }
}
