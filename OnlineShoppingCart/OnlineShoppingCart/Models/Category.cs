using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShoppingCart.Models
{
    public class Category : Base
    {
        public string? CategoryName { get; set; }
        
        public virtual ICollection<Product>? Products { get; set; }

    }
}
