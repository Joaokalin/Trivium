using Microsoft.EntityFrameworkCore;
using TriviumApi.Infra;
using TriviumApi.Models.Contracts;
using TriviumApi.Models.Entities.Customers;

namespace TriviumApi.Models.Services
{
    public class CustomerService : ICustomerService 
    {
        private readonly ApiDbContext _apiDbContext;

        public CustomerService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<Customer> Register(Customer customer) 
        {
            await _apiDbContext.Customers.AddAsync(customer);
            await _apiDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<(ICollection<Customer>, long count)> List()
        {
            var count = _apiDbContext.Customers.LongCount();
            var custumers = await _apiDbContext.Customers.ToListAsync();

            return (custumers, count);
        }
        
        public async Task<Customer> Find(long id)
        {
            return await _apiDbContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            _apiDbContext.Customers.Update(customer);
            await _apiDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task Delete(Customer customer)
        {
            _apiDbContext.Customers.Remove(customer);
            await _apiDbContext.SaveChangesAsync();
        }

    }
}
