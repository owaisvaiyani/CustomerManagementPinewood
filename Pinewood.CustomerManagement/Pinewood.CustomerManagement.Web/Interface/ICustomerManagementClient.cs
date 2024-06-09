using Pinewood.CustomerManagement.Web.Models;

namespace Pinewood.CustomerManagement.Web.Interface
{
    public interface ICustomerManagementClient
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();

        Task<bool> EditCustomerAsync(CustomerDto editCustomer);

        Task<bool> AddCustomerAsync(CustomerDto addCustomer);

        Task<bool> DeleteCustomerAsync(int customerId);

        Task<CustomerDto?> GetCustomerAsync(int customerId);
    }
}
