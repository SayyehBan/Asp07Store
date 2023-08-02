using System.ComponentModel;

namespace Asp07Store.ShopUI.Models
{
    public class Product
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("دسته بندی")]
        public string Category { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("قیمت")]
        public int Price { get; set; }
    }
}
