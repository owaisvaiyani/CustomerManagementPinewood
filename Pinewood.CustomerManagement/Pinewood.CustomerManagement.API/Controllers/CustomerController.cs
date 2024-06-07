using Microsoft.AspNetCore.Mvc;
using Pinewood.CustomerManagement.API.Interface;
using Pinewood.CustomerManagement.API.Models;

namespace Pinewood.CustomerManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {        
        private ICustomerManagementService _customerManagementService;

        public CustomerController( ICustomerManagementService customerManagementService)
        {   
            _customerManagementService = customerManagementService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            
            return _customerManagementService.GetAllCustomers();
        }

        [HttpPost]
        public bool EditCustomer(CustomerDto editCustomer)
        {           
            return _customerManagementService.EditCustomer(editCustomer);         
        }

        [HttpPost]
        public bool AddCustomer(CustomerDto addCustomer)
        {         
            return _customerManagementService.AddCustomer(addCustomer);            
        }

        [HttpDelete]
        public bool DeleteCustomer(int customerId)
        {            
            return _customerManagementService.DeleteCustomer(customerId);
        }
    }
}
