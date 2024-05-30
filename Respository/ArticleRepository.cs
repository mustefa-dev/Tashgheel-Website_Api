using AutoMapper;
using Tashgheel_Api.DATA;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Interface;

namespace Tashgheel_Api.Repository
{

    public class ArticleRepository : GenericRepository<Article , Guid> , IArticleRepository
    {
        public ArticleRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
