using FinancialAccounts.Model.Entities;
using FinanicalAccountsClient.Dtos;

namespace FinanicalAccountsClient.IRepository
{
    public interface IProductRepository
    {
        Task<ServiceResponse> AddAsync(Product product);
        Task<ServiceResponse> UpdateAsync(Product product);
        Task<ServiceResponse> DeleteAsync(Guid Id);
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(Guid Id);
    }
}
