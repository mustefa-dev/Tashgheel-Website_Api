using AutoMapper;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;

public interface IServiceServices
{
    Task<(Service? service, string? error)> Create(ServiceForm serviceForm);
    Task<(List<ServiceDto> services, int? totalCount, string? error)> GetAll(ServiceFilter filter);
    Task<(ServiceDto? service, string? error)> GetById(Guid id);
    Task<(Service? service, string? error)> Update(Guid id, ServiceUpdate serviceUpdate);
    Task<(Service? service, string? error)> Delete(Guid id);
}

public class ServiceServices : IServiceServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(Service? service, string? error)> Create(ServiceForm serviceForm)
    {
        var service = _mapper.Map<Service>(serviceForm);
        var response = await _repositoryWrapper.Service.Add(service);
        return response == null ? (null, "Error") : (response, null);
        
    }

    public async Task<(List<ServiceDto> services, int? totalCount, string? error)> GetAll(ServiceFilter filter)
    {
        var (services, totalCount) = await _repositoryWrapper.Service.GetAll<ServiceDto>(
            x =>
                (filter.Name == null || x.Name.Contains(filter.Name))
            , filter.PageNumber, filter.PageSize);
        
        return (services, totalCount, null);
        
    }

    public async Task<(ServiceDto? service, string? error)> GetById(Guid id)
    {
        var service = _repositoryWrapper.Service.GetById(id);
        if (service == null) return (null, "Service not found");
        var serviceDto = _mapper.Map<ServiceDto>(service);
        return (serviceDto, null);
        

    }

    public async Task<(Service? service, string? error)> Update(Guid id, ServiceUpdate serviceUpdate)
    {
        var service = await _repositoryWrapper.Service.GetById(id);
        if (service == null) return  (null, "Service not found");
        _mapper.Map(serviceUpdate, service);
        var response = await _repositoryWrapper.Service.Update(service);
        return response == null ? (null, "Error") : (response, null);
    }

    public async Task<(Service? service, string? error)> Delete(Guid id)
    {
        var service = await _repositoryWrapper.Service.GetById(id);
        if (service == null) return  (null, "Service not found");
        var response = await _repositoryWrapper.Service.SoftDelete(id);
        return response == null ? (null, "Error") : (response, null);
    }
}