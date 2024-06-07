using Pinewood.CustomerManagement.Core.Entities;

namespace Pinewood.CustomerManagement.Core.Interface
{
    public interface ICustomerManagementRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        bool EditCustomer(Customer editCustomer);

        bool AddCustomer(Customer addCustomer);

        bool DeleteCustomer(int customerId);
    }
}
