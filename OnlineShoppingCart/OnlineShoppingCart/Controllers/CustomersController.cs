using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Models;
using OnlineShoppingCart.Repository;

namespace OnlineShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {
        private readonly IBillRepository _billRepository;
        public CustomersController(IBaseRepository<Customer> repository, IBillRepository billRepository) : base(repository)
        {
            _billRepository = billRepository;
        }

        [HttpGet("GetCustomerAndBill")]
        public async Task<IActionResult> GetBillCustomerDetails()
        {
            var details = await _billRepository.GetBillCustomerDetailsAsync();
            if (details == null || details.Count == 0)
            {
                return NotFound();
            }

            return Ok(details);
        }
    }
}
