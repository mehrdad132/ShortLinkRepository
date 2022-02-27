using ShortLink.Infra.Data.Models.Common;


namespace ShortLink.Infra.Data
{
    public interface IGenericRepository<T>: IDisposable where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T>  Get(int id);
        Task Add(T entity);
        void Update(T entity);
        void Remove(BaseEntity entity);
        Task SaveChanges();

    }
}
