using Tashgheel_Api.Helpers;
using Tashgheel_Api.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.Entities;
using System.Threading.Tasks;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers
{
    public class ChaptersController : BaseController
    {
        private readonly IChapterServices _chapterServices;

        public ChaptersController(IChapterServices chapterServices)
        {
            _chapterServices = chapterServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<ChapterDto>>> GetAll([FromQuery] ChapterFilter filter) => Ok(await _chapterServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterDto>> GetById(Guid id) => Ok(await _chapterServices.GetById(id));
        
      /*  [HttpPost]
        public async Task<ActionResult<Chapter>> Create([FromBody] ChapterForm chapterForm) => Ok(await _chapterServices.Create(chapterForm));*/

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Chapter>> Update([FromBody] ChapterUpdate chapterUpdate, Guid id) => Ok(await _chapterServices.Update(id , chapterUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapter>> Delete(Guid id) =>  Ok( await _chapterServices.Delete(id)); 
        [HttpPost("{chapterId}/videos")]
        public async Task<ActionResult<Chapter>> AddVideoToChapter([FromBody] VideoForm videoForm, Guid chapterId) => Ok(await _chapterServices.AddVideoToChapter(videoForm, chapterId));
        
    }
}
