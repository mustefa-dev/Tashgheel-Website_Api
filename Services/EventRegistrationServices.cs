
using AutoMapper;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;


public interface IEventRegistrationServices
{
Task<(EventRegistration? eventregistration, string? error)> Create(EventRegistrationForm eventregistrationForm );
Task<(List<EventRegistrationDto> eventregistrations, int? totalCount, string? error)> GetAll(EventRegistrationFilter filter);
Task<(EventRegistration? eventregistration, string? error)> Update(Guid id , EventRegistrationUpdate eventregistrationUpdate);
Task<(EventRegistration? eventregistration, string? error)> Delete(Guid id);
}

public class EventRegistrationServices : IEventRegistrationServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public EventRegistrationServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(EventRegistration? eventregistration, string? error)> Create(EventRegistrationForm eventregistrationForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<EventRegistrationDto> eventregistrations, int? totalCount, string? error)> GetAll(EventRegistrationFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(EventRegistration? eventregistration, string? error)> Update(Guid id ,EventRegistrationUpdate eventregistrationUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(EventRegistration? eventregistration, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
