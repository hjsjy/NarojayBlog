using AutoMapper;
using Markdig;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.IManager;
using NarojayBlog.ManagerEntity;
using NarojayBlog.Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NarojayBlog.Manager
{
    public class ArticleManager : BaseManager<Article, ArticleEntity, ArticleRepository>, IArticleManager
    {
        public ArticleManager(ArticleRepository articleRepository, IMapper mapper) : base(articleRepository, mapper)
        {

        }
        public int GetArticleNumber()
        {
            return Repository.GetArticleNumber();
        }
        public int CalculateArticleWordsNumber()
        {
            return Repository.CalculateWords().Sum();
        }

        public IEnumerable<ArticleEntity> GetArticles()
        {
            var articleEntities = GetAll();
            foreach (var articleEntity in articleEntities)
            {
                articleEntity.Content = Markdown.ToHtml(articleEntity.Content);
            }

            return articleEntities;
        }

        public ArticleEntity GetArticleById(string id)
        {
            var articleEntity = GetById(id);
            var articleContent = articleEntity.Content;
            articleEntity.Content = Markdown.ToHtml(articleContent);
            return articleEntity;
        }

        public bool AddArticle(ArticleEntity articleEntity)
        {
            return InsertArticle(articleEntity);
        }
    }
}
