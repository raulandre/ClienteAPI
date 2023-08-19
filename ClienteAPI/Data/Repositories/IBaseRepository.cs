namespace ClienteAPI.Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        IQueryable<T> List();
        Task Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task Commit();
    }
}
