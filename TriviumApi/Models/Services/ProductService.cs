using Microsoft.EntityFrameworkCore;
using TriviumApi.Infra;
using TriviumApi.Models.Contracts;
using TriviumApi.Models.Entities.Products;

namespace TriviumApi.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _apiDbContext;

        public ProductService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<(ICollection<Product>, long count)> List()
        {
            var count = _apiDbContext.Products.LongCount();
            var products = await _apiDbContext.Products.ToListAsync();

            return (products, count);
        }

        public async Task<Product> Find(long id)
        {
            return await _apiDbContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
