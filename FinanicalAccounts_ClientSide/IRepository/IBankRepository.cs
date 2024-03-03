using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface IBankRepository
    {
        Task<ServiceResponse> AddAsync(BankAccount bank);
        Task<ServiceResponse> UpdateAsync(BankAccount bank);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<BankAccount>> GetAsync();
        Task<BankAccount> GetByIdAsync(Guid Id);
    }
}
