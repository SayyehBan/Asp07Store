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
        public PageData<Product> GetAll(int pageNumber, int pageSize)
        {
            var result=new PageData<Product>
            {
                pageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                }
            };

            result.Data= storeDbContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.pageInfo.TotalCount = storeDbContext.Products.Count();
            return result;
        }
    }
}
