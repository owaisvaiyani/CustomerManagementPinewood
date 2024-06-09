using Newtonsoft.Json;
using Pinewood.CustomerManagement.Web.Interface;
using Pinewood.CustomerManagement.Web.Models;
using System.Text;

namespace Pinewood.CustomerManagement.Web.Services
{
    public class CustomerManagementClient : ICustomerManagementClient
    {
        private static string url = "https://localhost:7234/api/Customer"; // TODO read from app settings
        private static readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var response = await client.GetAsync(url + "/GetAllCustomers");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(responseString);
            }

            return new List<CustomerDto>();
        }

        public async Task<bool> EditCustomerAsync(CustomerDto editCustomer)
        {
            var json = JsonConvert.SerializeObject(editCustomer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url + "/EditCustomer", data);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(responseString);
            }

            return false;
        }

        public async Task<bool> AddCustomerAsync(CustomerDto addCustomer)
        {
            var json = JsonConvert.SerializeObject(addCustomer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url + "/AddCustomer", data);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(responseString);
            }

            return false;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            //var json = JsonConvert.SerializeObject(customerId);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.DeleteAsync(url + "/DeleteCustomer?customerId=" + customerId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(responseString);
            }

            return false;
        }

        public async Task<CustomerDto?> GetCustomerAsync(int customerId) 
        {
            var response = await client.GetAsync(url + "/GetCustomer?customerId="+ customerId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerDto>(responseString);
            }

            return null;
        }
    }
}
