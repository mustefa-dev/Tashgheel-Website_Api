
using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;
using Tashgheel.Core.Helpers;
using Tweetinvi.Core.Models.Properties;

namespace Tashgheel_Api.Services;


public interface IAppSettingServices
{
Task<(AppSettingDto? appsetting , string? error)> Create(AppSettingForm appsettingForm);

Task<AppSettingDto> GetMyAppSetting();
Task<(AppSettingDto? appsetting, string? error)> Update(Guid id, AppSettingUpdate appsettingUpdate, string language);
Task<(AppSettingDto? appsetting, string? error)> Delete(Guid id);
}

public class AppSettingServices : IAppSettingServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AppSettingServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    

    public async Task<(AppSettingDto? appsetting, string? error)> Create(AppSettingForm appsettingForm)
    {
        var appsetting = _mapper.Map<AppSetting>(appsettingForm);
        appsetting = await _repositoryWrapper.AppSetting.Add(appsetting);
        return (_mapper.Map<AppSettingDto>(appsetting), null);

    }



    public async Task<(AppSettingDto? appsetting, string? error)> Update(Guid id, AppSettingUpdate appsettingUpdate, string language)
    {
        var appsetting = await _repositoryWrapper.AppSetting.GetById(id);
        if (appsetting == null) return (null, ErrorResponseException.GenerateErrorResponse("AppSetting not found", "لم يتم العثور على الاعدادات", language));
        _mapper.Map(appsettingUpdate, appsetting);
        appsetting = await _repositoryWrapper.AppSetting.Update(appsetting, id);
        return (_mapper.Map<AppSettingDto>(appsetting), null);
    }

    public async Task<(AppSettingDto? appsetting, string? error)> Delete(Guid id)
    {
        var appsetting = await _repositoryWrapper.AppSetting.GetById(id);
        if (appsetting == null) return (null, "AppSetting not found");
        await _repositoryWrapper.AppSetting.SoftDelete(id);
        return (_mapper.Map<AppSettingDto>(appsetting), null);

    }

    public async Task<AppSettingDto> GetMyAppSetting()
    {
        // Try to retrieve the AppSetting from the database
        var appsetting1 = await _repositoryWrapper.AppSetting.GetAll();
        var appsetting = appsetting1.data.FirstOrDefault();


        // If it doesn't exist, create a default one
        if (appsetting == null)
        {
            var defaultAppSetting = new AppSetting
            {
                // Set default values here
            };

            appsetting = await _repositoryWrapper.AppSetting.Add(defaultAppSetting);
        }

        // Map it to AppSettingDto and return
        return _mapper.Map<AppSettingDto>(appsetting);
    }
}