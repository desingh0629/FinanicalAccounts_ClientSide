using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;
using FinanicalAccountsClient.Model.Entities;

namespace FinanicalAccountsClient.IRepository
{
    public interface IUserLogInRepository
    {
       
        Task<ServiceResponse> LoginAsync(LoginModel loginViewModel);
    }
}
