using AutoMapper;
using backend.app.Interfaces.Repositories;
using backend.infrastructure.Data;

namespace backend.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationContext _context;
        readonly IMapper _mapper;
        public UnitOfWork(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}