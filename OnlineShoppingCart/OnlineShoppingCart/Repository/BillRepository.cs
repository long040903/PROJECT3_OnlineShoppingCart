using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Common.BillDTO;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Repository
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Task<Bill> InsertFullDetailAsync(RequestBillFullDetail request);
        Task<List<BillCustomerDetailDTO>> GetBillCustomerDetailsAsync();

    }
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<Bill> InsertFullDetailAsync(RequestBillFullDetail request)
        {
            if (request != null)
            {
                if (request.Id == 0)
                {
                    var bill = new Bill()
                    {
                        Code = request.Code,
                        Date = request.Date,
                        PhoneNumber = request.PhoneNumber,
                        CustomerId = request.CustomerId // Gán CustomerId vào Bill
                    };

                    _context.Bills.Add(bill);
                    await _context.SaveChangesAsync();

                    var billDetails = new List<BillDetail>();

                    if (bill.Id > 0)
                    {
                        foreach (var item in request.BillDetails)
                        {
                            item.Id = 0;
                            item.BillId = bill.Id;
                            var detailItem = new BillDetail()
                            {
                                BillId = item.BillId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.Price
                            };
                            billDetails.Add(detailItem);
                        }
                        _context.BillDetails.AddRange(billDetails);
                        await _context.SaveChangesAsync();

                        return bill;
                    }
                }
            }
            return null;
        }

        public async Task<List<BillCustomerDetailDTO>> GetBillCustomerDetailsAsync()
        {
            var result = await (from b in _context.Bills
                                join c in _context.Customers on b.CustomerId equals c.Id
                                select new BillCustomerDetailDTO
                                {
                                    BillId = b.Id,
                                    BillCode = b.Code,
                                    BillDate = b.Date,
                                    CustomerId = c.Id,
                                    CustomerFullName = c.FullName,
                                    CustomerEmail = c.Email,
                                    CustomerPhoneNumber = c.PhoneNumber,
                                    CustomerAddress = c.Address
                                }).ToListAsync();

            return result;
        }

    }
}

