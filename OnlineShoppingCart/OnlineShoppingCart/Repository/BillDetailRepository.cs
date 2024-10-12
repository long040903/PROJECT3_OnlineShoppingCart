using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Common.BillDTO;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IBillDetailRepository : IBaseRepository<BillDetail>
    {
        Task<IEnumerable<BillDetailsDto>> GetBillDetailsByBillIdAsync(int billId);
    }

    public class BillDetailRepository : BaseRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<BillDetailsDto>> GetBillDetailsByBillIdAsync(int billId)
        {
            var billDetails = await _context.BillDetails
                .Include(bd => bd.Product) 
                .Where(bd => bd.BillId == billId)
                .Select(bd => new BillDetailsDto
                {
                    BillId = bd.BillId,
                    ProductId = bd.ProductId,
                    ProductName = bd.Product.ProductName, 
                    Price = bd.Price,
                    Quantity = bd.Quantity
                })
                .ToListAsync();

            return billDetails;
        }
    }
}
