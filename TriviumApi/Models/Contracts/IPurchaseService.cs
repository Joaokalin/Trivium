using TriviumApi.Models.Entities.Purchases;

namespace TriviumApi.Models.Contracts
{
    public interface IPurchaseService
    {
        Task<(ICollection<Purchase>, long count)> List();

        Task<Purchase> Find(long id);

        Task<List<PurchaseCustomerHistory>> CustomerHistory(long custumerId);

        Task<PurchaseProductHistory> ProductHistory(long producId);
    }
}
