using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp07Store.ShopUI.Models
{
    public class CheckoutViewModel
    {
        [DisplayName("نام")]
        [Required]
        public string Name { get; set; }
        [DisplayName("شهر")]
        [Required]
        public string City { get; set; }
        [DisplayName("نشانی")]
        [Required]
        public string Address { get; set; }
    }
}
