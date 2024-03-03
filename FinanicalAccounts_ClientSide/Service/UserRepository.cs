using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using System.Net.Http.Json;

namespace FinanicalAccountsClient.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                user.BusinessUnitId = user.UserId;
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;
                user.CreatedId = user.UserId;
                user.UpdatedId = user.UserId;
                var data = await _httpClient.PostAsJsonAsync("api/users", user);
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
            var data = await _httpClient.DeleteAsync($"api/Users/{Id}");
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }

        public async Task<List<User>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<User>>("api/Users")!;

        public async Task<User> GetByIdAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<User>($"api/Users/{Id}")!;

        public async Task<ServiceResponse> UpdateAsync(User user)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Users", user);
            var responce = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return responce!;
        }
    }
}
