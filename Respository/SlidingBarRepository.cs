using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Repository
{

    public class SlidingBarRepository : GenericRepository<SlidingBar , Guid> , ISlidingBarRepository
    {
        public SlidingBarRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
