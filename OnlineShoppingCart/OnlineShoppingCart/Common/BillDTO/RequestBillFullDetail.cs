using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Common.BillDTO
{
    public class RequestBillFullDetail : Base
    {
        public string? Code { get; set; }
        public DateTime? Date { get; set; }
        public string? PhoneNumber { get; set; }

        public int? CustomerId { get; set; }

        public List<BillDetailsDTO>? BillDetails { get; set; }
    }

    public class BillDetailsDTO : Base
    {
        public int? BillId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}