using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;

        public ProductRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Product product)
        {
            try
            {
             
                var data = await _httpClient.PostAsJsonAsync("api/products", product);
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
            var data = await _httpClient.DeleteAsync($"api/products/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<Product>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Product>>("api/products")!;

        public async Task<Product> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<Product>($"api/products/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(Product product)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/products", product);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
