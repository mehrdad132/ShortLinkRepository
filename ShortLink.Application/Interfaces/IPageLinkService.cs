using ShortLink.Infra.Data.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShortLink.ApplicationService
{
    public interface IPageLinkService:IDisposable
    {
        List<PageLink> GetAll();    
        Task Add(PageLink entity);

       Task<PageLink> GetById(int id);
        void Update(PageLink entity);
        Task<bool> ExistShortKey(string shortKey);
        Task<PageLink> GetByShortKey(string shortKey);
        void SaveChange();
    }
}
