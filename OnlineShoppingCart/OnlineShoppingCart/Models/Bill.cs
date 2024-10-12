using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Bill : Base
    {
        public string? Code { get; set; }
        public DateTime? Date { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
    }
}
