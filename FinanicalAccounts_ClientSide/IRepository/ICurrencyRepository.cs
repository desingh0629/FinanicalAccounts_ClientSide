using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface ICurrencyRepository
    {
        Task<ServiceResponse> AddAsync(Currency currency);
        Task<ServiceResponse> UpdateAsync(Currency currency);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<Currency>> GetAsync();
        Task<Currency> GetByIdAsync(Guid Id);
    }
}
