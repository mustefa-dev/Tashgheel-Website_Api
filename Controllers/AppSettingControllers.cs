using Tashgheel_Api.Helpers;
using Tashgheel_Api.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;
using Tashgheel.Core.Helpers;

namespace Tashgheel_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]     
    public class AppSettingsController : BaseController
    {
        private readonly IAppSettingServices _appsettingServices;

        public AppSettingsController(IAppSettingServices appsettingServices)
        {
            _appsettingServices = appsettingServices;
        }
        
       
          [HttpPut("{id}")]
          public async Task<ActionResult> Update([FromBody] AppSettingUpdate appsettingUpdate, Guid id) 
          { 
              var language = Request.Headers["Accept-Language"].ToString();
              return Ok(await _appsettingServices.Update(id, appsettingUpdate, language)); 
          }  
       
        [HttpGet("GetMyAppSetting")]
        public async Task<ActionResult> GetMyAppSetting() => Ok(await _appsettingServices.GetMyAppSetting());
        
    }
}
