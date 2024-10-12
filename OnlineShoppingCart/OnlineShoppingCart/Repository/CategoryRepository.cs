using OnlineShoppingCart.Data;
using OnlineShoppingCart.Models;
namespace OnlineShoppingCart.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
