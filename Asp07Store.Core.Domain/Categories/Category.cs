using System.ComponentModel;

namespace Asp07Store.ShopUI.Models
{
    public class Category
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("دسته بندی")]
        public string Name { get; set; }
    }
}
