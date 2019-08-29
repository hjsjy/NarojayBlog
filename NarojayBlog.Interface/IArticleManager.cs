using NarojayBlog.ManagerEntity;
using System.Collections.Generic;

namespace NarojayBlog.IManager
{
    public interface IArticleManager
    {
        IEnumerable<ArticleEntity> GetArticles();

        ArticleEntity GetArticleById(string id);

        bool AddArticle(ArticleEntity articleEntity);
        int CalculateArticleWordsNumber();
        int GetArticleNumber();

    }
}
