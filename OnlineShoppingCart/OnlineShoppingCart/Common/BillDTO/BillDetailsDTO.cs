namespace OnlineShoppingCart.Common.BillDTO
{

    public class BillDetailsDto
    {
        public int? BillId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
