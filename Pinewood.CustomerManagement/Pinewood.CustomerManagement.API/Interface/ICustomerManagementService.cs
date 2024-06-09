using Pinewood.CustomerManagement.API.Models;

namespace Pinewood.CustomerManagement.API.Interface
{
    public interface ICustomerManagementService
    {
        IEnumerable<CustomerDto> GetAllCustomers();

        bool EditCustomer(CustomerDto editCustomer);

        bool AddCustomer(CustomerDto addCustomer);

        bool DeleteCustomer(int customerId);
        CustomerDto? GetCustomer(int customerId);
    }
}
