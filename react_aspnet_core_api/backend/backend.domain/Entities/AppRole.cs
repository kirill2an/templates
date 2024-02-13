using API.Domain.Entities;

namespace backend.domain.Entities
{
    public class AppRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AppUserRole>? UserRoles { get; set; }
    }
}