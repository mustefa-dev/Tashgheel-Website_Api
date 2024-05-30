using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Repository
{

    public class UserCourseRepository : GenericRepository<UserCourse , Guid> , IUserCourseRepository
    {
        public UserCourseRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
