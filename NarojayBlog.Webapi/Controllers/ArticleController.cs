using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.IManager;
using NarojayBlog.ManagerEntity;
using NarojayBlog.ViewModel;

namespace NarojayBlog.Webapi.Controllers
{
    public class ArticleController:BaseController

    {
        private readonly IArticleManager _articleManager;

        public ArticleController(IArticleManager articleManager,IMapper mapper) : base(mapper)
        {
            _articleManager = articleManager;
        }
        [HttpGet]
        public IActionResult GetArticle(string id)
        {
            try
            {
                var articleEntity = _articleManager.GetArticleById(id);
                if (articleEntity == null)
                {
                    return BadRequest(new { Code= 1001,Content = "文章不存在"});
                }
                return Ok(articleEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleAddVIewModel articleAddVIewModel)
        {
            try
            {
                var result = _articleManager.AddArticle(Mapper.Map<ArticleEntity>(articleAddVIewModel));
                if (!result)
                {
                    return BadRequest(new {Code = 1002, Content = "文章添加失败"});
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
