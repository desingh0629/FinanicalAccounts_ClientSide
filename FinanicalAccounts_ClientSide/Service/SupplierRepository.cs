using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly HttpClient _httpClient;

        public SupplierRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Supplier supplier)
        {
            try
            {
                supplier.SupplierId = Guid.NewGuid();
                supplier.BusinessUnitId = supplier.SupplierId;
                supplier.CreatedDate = DateTime.Now;
                supplier.UpdatedDate = DateTime.Now;
                supplier.CreatedId = supplier.SupplierId;
                supplier.UpdatedId = supplier.SupplierId;
                var data = await _httpClient.PostAsJsonAsync("api/suppliers", supplier);
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
            var data = await _httpClient.DeleteAsync($"api/suppliers/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<Supplier>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Supplier>>("api/suppliers")!;

        public async Task<Supplier> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<Supplier>($"api/suppliers/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(Supplier supplier)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/suppliers", supplier);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
