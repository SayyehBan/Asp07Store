namespace Asp07Store.ShopUI.Models.Interface
{
    public interface IProduct
    {
        PageData<Product> GetAll(int pageNumber,int pageSize,string category);
        List<string> GetAllCategories();
        Product GetById(int id);
    }
}
