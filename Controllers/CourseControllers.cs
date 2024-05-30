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
    public class CoursesController : BaseController
    {
        private readonly ICourseServices _courseServices;

        public CoursesController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAll([FromQuery] CourseFilter filter) => Ok(await _courseServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Course>> Create([FromBody] CourseForm courseForm) => Ok(await _courseServices.Create(courseForm,Id));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> Update([FromBody] CourseForm courseUpdate, Guid id) => Ok(await _courseServices.Update(id , courseUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> Delete(Guid id) =>  Ok( await _courseServices.Delete(id));
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(Guid id) => Ok(await _courseServices.GetById(id));
        
        [HttpPost("{courseId}/chapters")]
        public async Task<ActionResult<Course>> AddChapterForCourse([FromBody] ChapterForm chapterForm, Guid courseId) => Ok(await _courseServices.AddChapterForCourse(chapterForm, courseId));
        [HttpPost("buycourse/{courseId}")]
        [Authorize]
        public async Task<ActionResult<Course>> BuyCourse(Guid courseId) => Ok(await _courseServices.BuyCourse(Id,courseId));
        
    }
}


//encryption
