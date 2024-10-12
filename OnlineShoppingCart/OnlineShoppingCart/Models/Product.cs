using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Product : Base
    {
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public string? ImageProduct { get; set; }
        public string? BarCode { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
