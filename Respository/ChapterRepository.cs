using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Repository
{

    public class ChapterRepository : GenericRepository<Chapter , Guid> , IChapterRepository
    {
        public ChapterRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
