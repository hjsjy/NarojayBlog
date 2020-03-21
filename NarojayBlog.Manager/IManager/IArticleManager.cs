using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using NarojayBlog.Manager.Entiy;

namespace NarojayBlog.Manager.IManager
{
    public interface IArticleManager
    {
        IEnumerable<ArticleEntity> GetArticles();

        ArticleEntity GetArticleById(string id);

        bool AddArticle(ArticleEntity articleEntity);
        int CalculateArticleWordsNumber();
        int GetArticleNumber();
        IEnumerable<ArticleEntity> GetArticles(int page, int size);

        Task<int> TestAsync(int id);

    }
}
