using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Repository
{

    public class CategoryRepository : GenericRepository<Category , Guid> , ICategoryRepository
    {
        public CategoryRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
