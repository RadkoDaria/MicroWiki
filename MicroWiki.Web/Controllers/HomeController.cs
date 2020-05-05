using AutoMapper;
using MicroWiki.BLL.DTO;
using MicroWiki.BLL.Infrastructure;
using MicroWiki.BLL.Interfaces;
using MicroWiki.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MicroWiki.Web.Controllers
{
    public class HomeController : Controller
    {
        IArticleService articleService;
        public HomeController(IArticleService serv)
        {
            articleService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<ArticleDTO> articleDtos = articleService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            return View(articles);
        }

        public ActionResult GetArticle(int? id)
        {
            try
            {
                ArticleDTO article = articleService.GetArticle(id);
                var edit = new EditDataViewModel { Id = article.Id };

                return View(edit);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeEdit(EditDataViewModel edit)
        {
            try
            {
                var editDto = new EditDTO { Id = edit.Id, Description = edit.Description, Owner = edit.Owner, Time = edit.Time };
                articleService.MakeEdit(editDto);
                return Content("<h2>Статья создана</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(edit);
        }

        protected override void Dispose(bool disposing)
        {
            articleService.Dispose();
            base.Dispose(disposing);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


//var context = new WikiContext(connectionString);
//var pages = context.Articles.OrderByDescending(o => o.Id).ToList();
//return View(pages);