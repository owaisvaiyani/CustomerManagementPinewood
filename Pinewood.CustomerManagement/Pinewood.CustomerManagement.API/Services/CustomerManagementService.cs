using Pinewood.CustomerManagement.API.Interface;
using Pinewood.CustomerManagement.API.Models;
using Pinewood.CustomerManagement.Core.Interface;
using Pinewood.CustomerManagement.Core.Repository;

namespace Pinewood.CustomerManagement.API.Services
{
    public class CustomerManagementService : ICustomerManagementService
    {
        private ICustomerManagementRepository _customerManagementRepository;
        private readonly ILogger<CustomerManagementService> _logger;

        public CustomerManagementService(ILogger<CustomerManagementService> logger, ICustomerManagementRepository customerManagementRepository) 
        {
            _logger = logger;
            _customerManagementRepository = customerManagementRepository;
        }

        public bool AddCustomer(CustomerDto addCustomer)
        {
            _logger.LogInformation("Starting AddCustomer");

            try
            {
                return _customerManagementRepository.AddCustomer(new Core.Entities.Customer { Email = addCustomer.Email, Name = addCustomer.Name });
            } 
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex);
            }
            
            return false;
        }

        public bool DeleteCustomer(int customerId)
        {
            _logger.LogInformation("Starting DeleteCustomer");

            try
            {
                return _customerManagementRepository.DeleteCustomer(customerId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex);
            }

            return false;
        }

        public bool EditCustomer(CustomerDto editCustomer)
        {
            _logger.LogInformation("Starting EditCustomer");

            try
            {
                return _customerManagementRepository.EditCustomer(new Core.Entities.Customer { Id = editCustomer.Id, Email = editCustomer.Email, Name = editCustomer.Name });
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex);
            }

            return false;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var resultCustomers = new List<CustomerDto>();

            _logger.LogInformation("Starting GetAllCustomers");

            try
            {
                var customers = _customerManagementRepository.GetAllCustomers();

                foreach (var customer in customers)
                {
                    var customerDto = new CustomerDto();
                    customerDto.Id = customer.Id;
                    customerDto.Name = customer.Name;
                    customerDto.Email = customer.Email;

                    resultCustomers.Add(customerDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex);
            }           

            return resultCustomers;
        }
    }
}
