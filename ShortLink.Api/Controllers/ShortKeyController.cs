using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.ViewModels;
using ShortLink.ApplicationService;
using ShortLink.Infra.Data.Models.Link;

namespace ShortLink.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShortKeyController : ControllerBase
    {
        private readonly IPageLinkService _pageLinkService;
        public ShortKeyController(IPageLinkService pageLinkService)
        {
            _pageLinkService = pageLinkService;
        }



        [HttpGet]
        public IActionResult GetAllShortLinks()
        {
            return new ObjectResult(_pageLinkService.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return new ObjectResult(_pageLinkService.GetById(id));
        }


        [HttpPost]
        public async void PostPageLink(PageLinkDto pageLinkDto)
        {
            try
            {
                PageLink pageLink = new();
                if (pageLinkDto is not null)
                {
                    pageLink = new()
                    {
                        CountView = 0,
                        CreateDate = DateTime.Now,
                        ShortKey = await GenerateShortKeyAsync(),
                        Description = pageLinkDto.Description,
                        Title = pageLinkDto.Title,
                        IsDelete = false,
                    };
                }

                await _pageLinkService.Add(pageLink);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        [HttpGet]
        private async Task<string> GenerateShortKeyAsync(int lenght = 4)
        {
            string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, lenght);

            while (await _pageLinkService.ExistShortKey(key.ToString()))
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, lenght);
            }

            return key;
        }

        [Route("p/{key}")]
        [HttpGet]
        public async Task<IActionResult> GetShortKeyRedirect(string key)
        {
            try
            {
                var pageLink = _pageLinkService.GetByShortKey(key).Result;

                if (pageLink == null)
                {
                    return NotFound();
                }
                Uri uri = new Uri("http://localhost:7015" + "/Page/" + pageLink.Id + "/" + pageLink.Title.Trim().Replace(" ", "-"));
                var pageLinkUpdate = await _pageLinkService.GetById(pageLink.Id);
                pageLinkUpdate.CountView += 1;
                _pageLinkService.Update(pageLinkUpdate);
                return new ObjectResult(uri);
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }
    }

}
