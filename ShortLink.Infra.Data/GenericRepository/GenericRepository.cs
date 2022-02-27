
using Microsoft.EntityFrameworkCore;
using ShortLink.Infra.Data.Models.Common;


namespace ShortLink.Infra.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly ShortLinkContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ShortLinkContext context)
        {
            _context=context;
            this._dbSet=_context.Set<T>();
        }
        public async Task Add(T entity)
        {
          await  _dbSet.AddAsync(entity);
           
        }
        public async Task<T> Get(int id)
        {
            var query= await  _dbSet.FirstOrDefaultAsync(_ => _.Id == id);
            return query;
        }

        public  IQueryable<T> GetAll()
        { 
            return _dbSet.AsQueryable();
        }

        public async void Remove(BaseEntity entity)
        {
            var ent = await Get(entity.Id);
            _dbSet.Remove(ent);
        }

        public async Task SaveChanges()
        {
          await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
