using Microsoft.EntityFrameworkCore;
using TriviumApi.Infra;
using TriviumApi.Models.Contracts;
using TriviumApi.Models.Entities.Purchases;

namespace TriviumApi.Models.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ApiDbContext _apiDbContext;

        public PurchaseService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<(ICollection<Purchase>, long count)> List()
        {
            var count = _apiDbContext.Purchases.LongCount();
            var purchases = await _apiDbContext.Purchases.ToListAsync();

            return (purchases, count);
        }

        public async Task<Purchase> Find(long id)
        {
            return await _apiDbContext.Purchases.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PurchaseCustomerHistory>> CustomerHistory(long custumerId)
        {
            var purchases = await _apiDbContext.Purchases
                .Where(p=> p.CustomerId == custumerId)
                .Include(p => p.PurchaseItens)
                    .ThenInclude(p => p.Product)
                .ToListAsync();
            var history = purchases.Select(item => PurchaseCustomerHistory.Map(item)).ToList();

            return history;
        }

        public async Task<PurchaseProductHistory> ProductHistory(long producId)
        {
            var purchases = await _apiDbContext.PurchaseItems
                .Where(p => p.ProductId == producId)
                .Include(p => p.Product)
                .ToListAsync();

            return PurchaseProductHistory.Map(purchases); 
        }

    }
}
