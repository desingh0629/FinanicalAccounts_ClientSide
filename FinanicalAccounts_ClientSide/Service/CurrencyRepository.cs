using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly HttpClient _httpClient;

        public CurrencyRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Currency currency)
        {
            try
            {
                currency.CurrencyId = Guid.NewGuid();
                currency.BusinessUnitId = currency.CurrencyId;
                currency.CreatedDate = DateTime.Now;
                currency.UpdatedDate = DateTime.Now;
                currency.CreatedId = currency.CurrencyId;
                currency.UpdatedId = currency.CurrencyId;
                var data = await _httpClient.PostAsJsonAsync("api/currencies", currency);
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
            var data = await _httpClient.DeleteAsync($"api/currencies/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<Currency>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Currency>>("api/currencies")!;

        public async Task<Currency> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<Currency>($"api/currencies/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(Currency currency)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/currencies", currency);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
