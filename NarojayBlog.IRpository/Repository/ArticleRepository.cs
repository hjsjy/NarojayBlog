using System.Collections.Generic;
using System.Linq;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(NarojayContext context) : base(context, context.Articles)
        {
        }

        public IEnumerable<int> CalculateWords()
        {
            return DbSet.Select(x => x.Content.Length).ToList();
        }

        public int GetArticleNumber()
        {
            return DbSet.Select(x => x.Title).Count();
        }
    }
}
