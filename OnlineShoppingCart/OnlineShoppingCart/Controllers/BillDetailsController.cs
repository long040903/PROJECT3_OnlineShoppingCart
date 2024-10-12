using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Models;
using OnlineShoppingCart.Repository;

namespace OnlineShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillDetailsController : BaseController<BillDetail>
    {
        private readonly IBillDetailRepository _billDetailRepository;

        public BillDetailsController(IBaseRepository<BillDetail> repository, IBillDetailRepository billDetailRepository) : base(repository)
        {
            _billDetailRepository = billDetailRepository;
        }

        [HttpGet("details/{billId}")]
        public async Task<IActionResult> GetBillDetailsByBillId(int billId)
        {
            var billDetails = await _billDetailRepository.GetBillDetailsByBillIdAsync(billId);
            if (billDetails == null || !billDetails.Any())
            {
                return NotFound();
            }

            return Ok(billDetails);
        }
    }
}