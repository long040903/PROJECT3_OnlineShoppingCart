using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShoppingCart.Models
{
    public class Customer : Base
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }


    }
}
