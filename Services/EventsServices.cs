
using AutoMapper;
using Tashgheel_Api.Repository;
using Tashgheel_Api.Services;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Services;


public interface IEventsServices
{
Task<(Events? events, string? error)> Create(EventsForm eventsForm );
Task<(List<EventsDto> eventss, int? totalCount, string? error)> GetAll(EventsFilter filter);
Task<(Events? events, string? error)> Update(Guid id , EventsUpdate eventsUpdate);
Task<(Events? events, string? error)> Delete(Guid id);
Task<(EventRegistrationDto? registration, string? error)> Register(EventRegistrationForm registrationForm, Guid userId);
Task<(EventRegistrationDto? registration, string? error)> ChangeStatus(Guid id, EventRegistrationStatus status);
Task<(EventRegistrationDto? registration, string? error)> SendEmail(Guid id, string subject, string message);
Task<(List<EventRegistrationDto>? registration,int totalCount, string? error)> GetMyRegistrations(Guid userId);
}

public class EventsServices : IEventsServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EventsServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(Events? events, string? error)> Create(EventsForm eventsForm)
    {
        var events = _mapper.Map<Events>(eventsForm);
        var response = await _repositoryWrapper.Events.Add(events);
        return response == null ? (null, "Error") : (response, null);
    }



    public async Task<(List<EventsDto> eventss, int? totalCount, string? error)> GetAll(EventsFilter filter)
    {
        var (events, totalCount) = await _repositoryWrapper.Events.GetAll<EventsDto>(
            x =>
                (filter.Name == null || x.Name.Contains(filter.Name)) &&
                (filter.Address == null || x.Location.Contains(filter.Address)) &&
                // (filter.StartDateTime == null || (x.EventDate>=filter.StartDateTime)) &&

                (filter.EventType == null || x.EventType == filter.EventType)

            , filter.PageNumber, filter.PageSize);

        return (events, totalCount, null);



    }

    public async Task<(Events? events, string? error)> Update(Guid id, EventsUpdate eventsUpdate)
    {
        var events = await _repositoryWrapper.Events.GetById(id);
        if (events == null) return (null, "Events not found");
        _mapper.Map(eventsUpdate, events);
        var response = await _repositoryWrapper.Events.Update(events);
        return response == null ? (null, "Error") : (response, null);
    }

    public async Task<(Events? events, string? error)> Delete(Guid id)
    {
        var events = await _repositoryWrapper.Events.GetById(id);
        if (events == null) return (null, "Events not found");
        var response = await _repositoryWrapper.Events.SoftDelete(id);
        return response == null ? (null, "Error") : (response, null);
    }

    public async Task<(EventRegistrationDto? registration, string? error)> Register(
        EventRegistrationForm registrationForm, Guid userId)
    {
        var userExists = await _repositoryWrapper.User.GetById(userId);
        if (userExists == null) return (null, "User not found");

        var eventExists = await _repositoryWrapper.Events.GetById(registrationForm.EventId);
        if (eventExists == null) return (null, "Event not found");
        if (await _repositoryWrapper.EventRegistration.Get(x =>
                x.EventId == registrationForm.EventId && x.UserId == userId) !=
            null) return (null, "User already registered for this event");
        if (await _repositoryWrapper.EventRegistration.Get(x =>
                x.EventId == registrationForm.EventId && x.Email == registrationForm.Email) !=
            null) return (null, "Email already registered for this event");

        if (eventExists.CurrentParticipants >= eventExists.ParticipantsLimit)
            return (null, "Event is full, Cant register more participants.");

        var registration = _mapper.Map<EventRegistration>(registrationForm);
        registration.RegistrationDate = DateTime.UtcNow;
        registration.UserId = userId;

        var response = await _repositoryWrapper.EventRegistration.Add(registration);
        if (response == null) return (null, "Error creating event registration");
        var responseDto = _mapper.Map<EventRegistrationDto>(response);
        var emailService = new EmailService();
        await emailService.SendEmail(registration.Email, "Registration Confirmation",
            "Your registration form has been successfully completed. However, your registration is pending approval. You will receive an email once your registration is approved.");

        return (responseDto, null);
    }

    public async Task<(EventRegistrationDto? registration, string? error)> ChangeStatus(Guid id,
        EventRegistrationStatus status)
    {
        var registration = await _repositoryWrapper.EventRegistration.GetById(id);
        if (registration == null) return (null, "Event registration not found");
        var Event = await _repositoryWrapper.Events.GetById(registration.EventId);
        if (Event.CurrentParticipants >= Event.ParticipantsLimit && status == EventRegistrationStatus.Approved)
            return (null, "Event is full, Cant approve more participants.");
        registration.Status = status;
        var response = await _repositoryWrapper.EventRegistration.Update(registration);
        if (status == EventRegistrationStatus.Approved)
        {
            var emailService = new EmailService();
            await emailService.SendEmail(registration.Email, "Registration Approved",
                "Your registration has been approved. You can now attend the event.");
            Event.CurrentParticipants++;
            await _repositoryWrapper.Events.Update(Event);
        }
        else if (status == EventRegistrationStatus.Rejected)
        {
            var emailService = new EmailService();
            await emailService.SendEmail(registration.Email, "Registration Rejected",
                "Your registration has been rejected. You cannot attend the event.");
        }

        return response == null ? (null, "Error") : (_mapper.Map<EventRegistrationDto>(response), null);
    }

    public async Task<(EventRegistrationDto? registration, string? error)> SendEmail(Guid id, string subject,
        string message)
    {
        var registration = await _repositoryWrapper.EventRegistration.GetById(id);
        if (registration == null) return (null, "Event registration not found");
        var emailService = new EmailService();
        await emailService.SendEmail(registration.Email, subject, message);
        return (_mapper.Map<EventRegistrationDto>(registration), null);
    }

    public async Task<(List<EventRegistrationDto>? registration, int totalCount, string? error)> GetMyRegistrations(Guid userId)
    {
        var (registrations, totalCount) =
            await _repositoryWrapper.EventRegistration.GetAll<EventRegistrationDto>(x => x.UserId == userId);

        return (registrations, totalCount, null);

    }


}
