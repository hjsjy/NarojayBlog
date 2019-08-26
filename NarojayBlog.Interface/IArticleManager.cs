using System.Collections.Generic;
using NarojayBlog.ManagerEntity;

namespace NarojayBlog.IManager
{
    public interface IArticleManager
    {
        IEnumerable<ArticleEntity> GetArticles();

        ArticleEntity GetArticleById(string id);

        bool AddArticle(ArticleEntity articleEntity);
    }
}
