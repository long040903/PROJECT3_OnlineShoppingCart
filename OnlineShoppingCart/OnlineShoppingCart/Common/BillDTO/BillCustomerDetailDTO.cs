namespace OnlineShoppingCart.Common.BillDTO
{
    public class BillCustomerDetailDTO
    {
        public int BillId { get; set; }
        public string BillCode { get; set; }
        public DateTime? BillDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
    }
}
