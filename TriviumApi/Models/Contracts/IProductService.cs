using TriviumApi.Models.Entities.Products;

namespace TriviumApi.Models.Contracts
{
    public interface IProductService
    {
        Task<(ICollection<Product>, long count)> List();

        Task<Product> Find(long id);
    }
}
