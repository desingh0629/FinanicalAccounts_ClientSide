using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FinancialAccounts.Model.Entities
{
    public class User
    {
        public User() => Roles = new List<Role>();
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
