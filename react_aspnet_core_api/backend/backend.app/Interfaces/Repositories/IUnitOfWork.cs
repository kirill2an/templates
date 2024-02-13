namespace backend.app.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        bool HasChanges();
    }
}