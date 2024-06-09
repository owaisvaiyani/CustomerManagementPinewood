using Microsoft.EntityFrameworkCore;
using Pinewood.CustomerManagement.Core.Context;
using Pinewood.CustomerManagement.Core.Entities;
using Pinewood.CustomerManagement.Core.Interface;

namespace Pinewood.CustomerManagement.Core.Repository
{
    public class CustomerManagementRepository : ICustomerManagementRepository
    {   
        private readonly CustomerContext _customerContext;
        private readonly IDbContextFactory<CustomerContext> _dbContext;

        public CustomerManagementRepository(IDbContextFactory<CustomerContext> dbContext)
        {
            _dbContext = dbContext;
            _customerContext = _dbContext.CreateDbContext();
        }

        public bool AddCustomer(Customer addCustomer)
        {
            _customerContext.Customers.Add(addCustomer);
            _customerContext.SaveChanges();

            return true;
        }

        public bool DeleteCustomer(int customerId)
        {
           var findCustomer = _customerContext.Customers.Where(x => x.Id == customerId).FirstOrDefault();

            if (findCustomer!=null)
            {
                _customerContext.Customers.Remove(findCustomer);
                _customerContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool EditCustomer(Customer editCustomer)
        {
            var findCustomer = _customerContext.Customers.Where(x=>x.Id == editCustomer.Id).FirstOrDefault();

            if (findCustomer!=null)
            {
                findCustomer.Email = editCustomer.Email;
                findCustomer.Name = editCustomer.Name;
                _customerContext.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerContext.Customers;
        }

        public Customer? GetCustomer(int customerId)
        {
            var findCustomer = _customerContext.Customers.Where(x => x.Id == customerId).FirstOrDefault();

            if (findCustomer != null)
            {
                return findCustomer;
            }

            return null;
        }
    }
}
