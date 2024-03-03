using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class BankRepository : IBankRepository
    {
        private readonly HttpClient _httpClient;

        public BankRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(BankAccount bank)
        {
            try
            {
             
                var data = await _httpClient.PostAsJsonAsync("api/bankaccounts", bank);
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
            var data = await _httpClient.DeleteAsync($"api/bankaccounts/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<BankAccount>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<BankAccount>>("api/bankaccounts")!;

        public async Task<BankAccount> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<BankAccount>($"api/bankaccounts/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(BankAccount bank)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/bankaccounts", bank);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
