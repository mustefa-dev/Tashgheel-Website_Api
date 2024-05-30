using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;
using Tashgheel_Api.Repository;

namespace Tashgheel_Api.Repository
{

    public class AppointmentRepository : GenericRepository<Appointment, Guid>, IAppointmentRepository
    {
        public AppointmentRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
