using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(NarojayContext context) : base(context, context.Articles)
        {
        }
        
    }
}
