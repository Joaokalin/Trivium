using TriviumApi.Models.Entities.Customers;

namespace TriviumApi.Models.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> Register(Customer customer);

        Task<(ICollection<Customer>, long count)> List();

        Task<Customer> Find(long id);

        Task<Customer> Update(Customer customer);

        Task Delete(Customer customer);

    }
}
