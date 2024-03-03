using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface IUserRepository
    {
        Task<ServiceResponse> AddAsync(User user);
        Task<ServiceResponse> UpdateAsync(User user);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(Guid Id);
    }
}
