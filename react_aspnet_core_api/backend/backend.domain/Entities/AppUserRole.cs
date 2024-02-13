using backend.domain.Entities;

namespace API.Domain.Entities
{
    public class AppUserRole
    {
        public Guid Id { get; set; }
        public AppUser? User { get; set; }
        public AppRole? Role { get; set; }
    }
}