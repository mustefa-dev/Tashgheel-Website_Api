 using AutoMapper;
 using Tashgheel;
 using Tashgheel_Api.Entities;
 using Tashgheel_Api.Interface;

 namespace Tashgheel_Api.Services;

 public interface IAppointmentService
 {
    Task<AppointmentDto> Create (AppointmentForm appointment,Guid userId);
    Task<AppointmentDto> Update (AppointmentForm appointment , Guid id);
   Task<AppointmentDto> Delete (Guid id);
    Task<(List<AppointmentDto>,int)> GetAll ();
    Task<(List<AppointmentDto>,int)> GetAllMyAppointments (Guid userId);
    Task<AppointmentDto> GetById (Guid id);
    Task<AppointmentDto> UpdateStatus (Guid id,AppointmentStatus status);
    Task<AppointmentDto> SendEmail (Guid id, string subject, string message);
    //Task<AppointmentDto> SendEmail (Guid id, string subject, string message, string senderEmail, string senderPassword);
    
}

 public class AppointmentService : IAppointmentService
 {
    private readonly IMapper _mapper;
     private readonly IRepositoryWrapper _repositoryWrapper;

        public AppointmentService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }
     
     public async Task<AppointmentDto> Create(AppointmentForm appointment,Guid userId)
     {
         var mappedAppointment = _mapper.Map<Appointment>(appointment);
         mappedAppointment.UserId = userId;
        mappedAppointment= await _repositoryWrapper.Appointment.Add(mappedAppointment);
        return _mapper.Map<AppointmentDto>(mappedAppointment);
     }

     public async Task<AppointmentDto> Update(AppointmentForm appointment, Guid id)
     {
         var appointmentToUpdate = await _repositoryWrapper.Appointment.GetById(id);
         if (appointmentToUpdate == null) return null;
        _mapper.Map(appointment,appointmentToUpdate);
         appointmentToUpdate= await _repositoryWrapper.Appointment.Update(appointmentToUpdate,id);
         return _mapper.Map<AppointmentDto>(appointmentToUpdate);
     }

     public async Task<AppointmentDto> Delete(Guid id)
     {
         var appointmentToDelete = await _repositoryWrapper.Appointment.GetById(id);
         if (appointmentToDelete == null) return null;
         await _repositoryWrapper.Appointment.SoftDelete(id);
         return _mapper.Map<AppointmentDto>(appointmentToDelete);
     }

     public async Task<(List<AppointmentDto>,int)> GetAll()
     {
            var appointments = await _repositoryWrapper.Appointment.GetAll();
            return (_mapper.Map<List<AppointmentDto>>(appointments.data), appointments.totalCount);
     }

     public async Task<AppointmentDto> GetById(Guid id)
     {
            var appointment = await _repositoryWrapper.Appointment.GetById(id);
            if (appointment == null) return null;
            return _mapper.Map<AppointmentDto>(appointment);
        }
     public async Task<(List<AppointmentDto>,int)> GetAllMyAppointments(Guid userId)
     {
         var appointments = await _repositoryWrapper.Appointment.GetAll(a => a.UserId == userId);
         return (_mapper.Map<List<AppointmentDto>>(appointments.data), appointments.totalCount);
    }
         
         public async Task<AppointmentDto> UpdateStatus(Guid id, AppointmentStatus status)
         {
             var appointmentToUpdate = await _repositoryWrapper.Appointment.GetById(id);          
             if (appointmentToUpdate == null) return null;
             appointmentToUpdate.AppointmentStatus = status;
         
             appointmentToUpdate = await _repositoryWrapper.Appointment.Update(appointmentToUpdate, id);
             if (status == AppointmentStatus.Approved)
             {
                 var email = new EmailService();
                 await email.SendEmail(appointmentToUpdate.Email, "Appointment Approved", "Your appointment has been approved");
             }
             else if (status == AppointmentStatus.Rejected)
             {
                 var email = new EmailService();
                 await email.SendEmail(appointmentToUpdate.Email, "Appointment Rejected", "Your appointment has been rejected");
             }
             
             return _mapper.Map<AppointmentDto>(appointmentToUpdate);
         }
       /*  public async Task<AppointmentDto> SendEmail(Guid id, string subject, string message, string senderEmail, string senderPassword)
         {
             var appointment = await _repositoryWrapper.Appointment.GetById(id);
             if (appointment == null) return null;
             var email = new EmailService();
                await email.SendEmailUsingSenderEmail(appointment.Email, subject, message, senderEmail, senderPassword);
             
            
             return _mapper.Map<AppointmentDto>(appointment);
         }*/
        public async Task<AppointmentDto> SendEmail(Guid id, string subject, string message)
        {
            var appointment = await _repositoryWrapper.Appointment.GetById(id);
            if (appointment == null) return null;
            var email = new EmailService();
               await email.SendEmail(appointment.Email, subject, message);


            return _mapper.Map<AppointmentDto>(appointment);
        }
         
 }