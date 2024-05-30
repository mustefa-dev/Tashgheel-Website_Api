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
    public class VideosController : BaseController
    {
        private readonly IVideoServices _videoServices;

        public VideosController(IVideoServices videoServices)
        {
            _videoServices = videoServices;
        }

        
       /* [HttpGet]
        public async Task<ActionResult<List<VideoDto>>> GetAll([FromQuery] VideoFilter filter) => Ok(await _videoServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Video>> Create([FromBody] VideoForm videoForm) => Ok(await _videoServices.Create(videoForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Video>> Update([FromBody] VideoUpdate videoUpdate, Guid id) => Ok(await _videoServices.Update(id , videoUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Video>> Delete(Guid id) =>  Ok( await _videoServices.Delete(id)); */
        [HttpGet("GetVideoParts")]
        public async Task<ActionResult<List<string>>> GetVideoParts(string fileName) => Ok(await _videoServices.GetVideoParts(fileName));
        
    }
}
