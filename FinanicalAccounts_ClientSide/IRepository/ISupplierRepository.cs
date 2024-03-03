using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface ISupplierRepository
    {
        Task<ServiceResponse> AddAsync(Supplier customer);
        Task<ServiceResponse> UpdateAsync(Supplier customer);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<Supplier>> GetAsync();
        Task<Supplier> GetByIdAsync(Guid Id);
    }
}
