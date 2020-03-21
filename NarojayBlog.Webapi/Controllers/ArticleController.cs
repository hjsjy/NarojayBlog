using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.Manager.Entiy;
using NarojayBlog.Manager.IManager;
using NarojayBlog.ViewModel;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NarojayBlog.Webapi.Controllers
{
    public class ArticleController : BaseController

    {
        private readonly IArticleManager _articleManager;
        private  readonly NarojayContext _context;

        public ArticleController(IArticleManager articleManager, IMapper mapper, NarojayContext context) : base(mapper)
        {
            _articleManager = articleManager;
            _context = context;
        }

        [HttpGet("WordsNumber")]
        public IActionResult GetWordsNumber()
        {
            var numbers = _articleManager.CalculateArticleWordsNumber();
            return Ok(numbers);
        }

        [HttpGet("Title")]
        public IActionResult GetTitleNumber()
        {
            var numbers = _articleManager.GetArticleNumber();
            return Ok(numbers);
        }

        [HttpGet("Articles")]
        public IActionResult GetArticles()
        {
            var articleEntities = _articleManager.GetArticles();
            if (!articleEntities.Any())
            {
                return NoContent();
            }

            return Ok(articleEntities);

        }
        [HttpGet("Articles/{page}")]
        public IActionResult GetArticlePage(int page, int size = 2)
        {
            var articles = _articleManager.GetArticles(page, size);
            var total = _articleManager.GetArticleNumber();
            var PageModel = new PageModel<ArticleEntity>
            {
                Values = articles,
                Total = total,
                PageSize = Math.Ceiling(Convert.ToDecimal(total / (double)size))
            };
            return Ok(PageModel);
        }
        ///
        [HttpGet("Article/{id}")]
        public IActionResult GetArticle(string id)
        {
            var articleEntity = _articleManager.GetArticleById(id);
            if (articleEntity == null)
            {
                return NoContent();
            }
            return Ok(articleEntity);
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleAddViewModel articleAddViewModel)
        {
            var result = _articleManager.AddArticle(Mapper.Map<ArticleEntity>(articleAddViewModel));
            if (!result)
            {
                return BadRequest(new { Code = 1002, Content = "文章添加失败" });
            }
            return Ok();
        }
        [HttpPost("test")]
        public async Task<IActionResult> test()
        {

            try
            {
                var result =   LongRunningCancellableOperation();
                return Ok(await result);
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        private async   Task<string> LongRunningCancellableOperation() 
        {
            var httpClient = new HttpClient();
        
            var stringAsyn1c = await  httpClient.GetStringAsync("http://www.taobao.com");
            var stringAsyn2c = await httpClient.GetStringAsync("http://www.baidu.com");
            var stringAsyn3c = await httpClient.GetStringAsync("http://www.github.com");
            return stringAsyn1c;
        }
         
    }
}
