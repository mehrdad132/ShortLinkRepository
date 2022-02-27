using ShortLink.Infra.Data;
using ShortLink.Infra.Data.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.ApplicationService
{
    public class PageLinkService : IPageLinkService
    {
        private readonly IGenericRepository<PageLink> _genericRepository;

        private readonly ShortLinkContext _context;
        public PageLinkService(IGenericRepository<PageLink> genericRepository, ShortLinkContext shortLinkContext)
        {
            _genericRepository = genericRepository;
            _context = shortLinkContext;
        }

        public async Task Add(PageLink entity)
        {
          await  _genericRepository.Add(entity);
            SaveChange();


        }

        public void Dispose()
        {
            _genericRepository?.Dispose();
        }

        public List<PageLink> GetAll()
        {
            return _genericRepository.GetAll().ToList();
        }

        public async Task<PageLink> GetById(int id)
        {
           return await _genericRepository.Get(id);
        }

        public async Task<bool> ExistShortKey(string shortKey)
        {
            return _context.Set<PageLink>().Any(_ => _.ShortKey == shortKey);
        }

        public void SaveChange()
        {
            _genericRepository.SaveChanges();
        }

        public async Task<PageLink> GetByShortKey(string shortKey)
        {
            if(shortKey !=null)
            {
                var pagelink =  _context.Set<PageLink>().SingleOrDefault(_=>_.ShortKey== shortKey);
                return pagelink;
            }
            return null;
        }

        public void Update(PageLink entity)
        {
            _genericRepository.Update(entity);
            _genericRepository.SaveChanges();
        }
    }
}
