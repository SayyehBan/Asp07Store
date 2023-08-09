using Asp07Store.Framework.Pagination;

namespace Asp07Store.ShopUI.Models.Interface
{
    public interface IProduct
    {
        PageData<Product> GetAll(int pageNumber, int pageSize, string category);
        Product GetById(int id);
    }
}