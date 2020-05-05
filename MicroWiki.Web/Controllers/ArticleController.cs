using MicroWiki.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroWiki.Web.Controllers
{
    public class ArticleViewModelController : Controller
    {
        // GET: ArticleViewModel
        public ActionResult Index(string name)
        {
            var context = new WikiContext(connectionString);
            List<ArticleViewModel> pages = null;
            if (name == null)
                pages = context.ArticleViewModels.ToList();
            else pages = context.ArticleViewModels.Where(o => o.Title == name).ToList();
            return View(pages);
        }

        public ActionResult Create()
        {
            var page = new Models.ArticleViewModel();
            return View(page);
        }

        [HttpPost]
        public ActionResult Submit()
        {
            var title = Request["title"];
            var category = Request["category"];
            var content = Request["content"];
            var id = 0;
            int.TryParse(Request["pId"], out id);

            ArticleViewModel page = null;
            if (content != null && title != null && category != null)
            {
                page = new ArticleViewModel()
                {
                    Name = title,
                    Category = category,
                    Text = content,
                    Edits = new List<EditData>()
                    {
                        new EditData() { Owner = page, Description = "ArticleViewModel Created", Time = DateTime.UtcNow }
                    }
                };
                try
                {
                    var wc = new WikiContext();
                    if (id == 0)
                        wc.ArticleViewModels.Add(page);
                    else
                    {
                        var p = wc.ArticleViewModels.First(o => o.Id == id);
                        p.Name = title;
                        p.Text = content;
                        p.Category = category;
                        p.Edits.Add(new EditData() { Owner = p, Time = DateTime.UtcNow, Description = Request["edit"] });
                        page = p;
                    }
                    wc.SaveChanges();
                }
                catch { page = null; }
            }
            return View(page);
        }

        public ActionResult Show(int id)
        {
            var page = new WikiContext().ArticleViewModels.Where(o => o.Id == id).FirstOrDefault();
            if (page != null)
                ViewBag.Title = page.Name;
            else ViewBag.Title = "Error";
            return View(page);
        }

        public ActionResult Edit(int id)
        {
            var page = new WikiContext().ArticleViewModels.FirstOrDefault(o => o.Id == id);
            return View(page);
        }
    }