using API.Domain.Entities;

namespace backend.domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public ICollection<AppUserRole>? UserRoles { get; set; }
    }
}