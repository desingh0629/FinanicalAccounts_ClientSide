using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface ICustomerRepository
    {
        Task<ServiceResponse> AddAsync(Customer customer);
        Task<ServiceResponse> UpdateAsync(Customer customer);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<Customer>> GetAsync();
        Task<Customer> GetByIdAsync(Guid Id);
    }
}
