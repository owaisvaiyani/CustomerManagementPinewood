using Microsoft.AspNetCore.Mvc;
using Pinewood.CustomerManagement.Web.Interface;
using Pinewood.CustomerManagement.Web.Models;
using System.Diagnostics;

namespace Pinewood.CustomerManagement.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerManagementClient _customerManagementClient;

        public CustomerController(ILogger<CustomerController> logger, ICustomerManagementClient customerManagementClient)
        {
            _logger = logger;
            _customerManagementClient = customerManagementClient;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerManagementClient.GetAllCustomersAsync();

            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            var customer = new CustomerDto();

            return View(customer);
        }

        public async Task<IActionResult> Edit()
        {
            var customer = new CustomerDto();

            return View(customer);
        }

        public async Task<IActionResult> Delete()
        {
            var customer = new CustomerDto();

            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}