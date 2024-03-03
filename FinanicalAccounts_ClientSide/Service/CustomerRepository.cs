using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient _httpClient;

        public CustomerRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Customer customer)
        {
            try
            {
                customer.CustomerId = Guid.NewGuid();
                customer.BusinessUnitId = customer.CustomerId;
                customer.CreatedDate = DateTime.Now;
                customer.UpdatedDate = DateTime.Now;
                customer.CreatedId = customer.CustomerId;
                customer.UpdatedId = customer.CustomerId;
                var data = await _httpClient.PostAsJsonAsync("api/customers", customer);
                var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
                return response!;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<ServiceResponse> DeleteAsync(Guid Id)
        {
            var data = await _httpClient.DeleteAsync($"api/customers/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<Customer>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers")!;

        public async Task<Customer> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(Customer customer)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/customers", customer);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
