using Tashgheel_Api.Helpers;
using Tashgheel_Api.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers
{
    public class ArticlesController : BaseController
    {
        private readonly IArticleServices _articleServices;

        public ArticlesController(IArticleServices articleServices)
        {
            _articleServices = articleServices;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> GetAll([FromQuery] ArticleFilter filter) => Ok(await _articleServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Article>> Create([FromBody] ArticleForm articleForm) => Ok(await _articleServices.Create(articleForm));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Update([FromBody] ArticleUpdate articleUpdate, Guid id) => Ok(await _articleServices.Update(id , articleUpdate));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(Guid id) =>  Ok( await _articleServices.Delete(id));
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetById(Guid id) => Ok(await _articleServices.GetById(id));
    }
}
