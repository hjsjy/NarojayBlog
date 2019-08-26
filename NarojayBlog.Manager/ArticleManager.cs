using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.IManager;
using NarojayBlog.ManagerEntity;
using NarojayBlog.Repository.Repository;
using System;
using System.Collections.Generic;

namespace NarojayBlog.Manager
{
    public class ArticleManager : BaseManager<Article, ArticleEntity, ArticleRepository>, IArticleManager
    {
        public ArticleManager(ArticleRepository articleRepository, IMapper mapper) : base(articleRepository, mapper)
        {
       
        }

        public IEnumerable<ArticleEntity> GetArticles()
        {
            return GetAll();
        }

        public ArticleEntity GetArticleById(string id)
        {
            
            return GetById(id);
        }

        public bool AddArticle(ArticleEntity articleEntity)
        {
           return InsertArticle(articleEntity);
        }
    }
}
