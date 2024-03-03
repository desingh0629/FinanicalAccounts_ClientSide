using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.IRepository;
using FinanicalAccountsClient.Model.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;


namespace FinanicalAccountsClient.Service
{
    public class UserLoginRespository : IUserLogInRepository
    {

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public UserLoginRespository(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        public async Task<ServiceResponse> LoginAsync(LoginModel loginViewModel)
        {
            try
            {
                var data = await _httpClient.PostAsJsonAsync("api/users/login", loginViewModel);
                //data.EnsureSuccessStatusCode(); 

                var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
                if(response.flaf)
                    _navigationManager.NavigateTo("/user", forceLoad: true);
                else
                    _navigationManager.NavigateTo("/loginindex", forceLoad: false);

                return response!;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new ServiceResponse(false, "An error occurred during login.");
            }
        }
    }
}
