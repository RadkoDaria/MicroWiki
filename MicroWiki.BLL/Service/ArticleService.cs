using AutoMapper;
using MicroWiki.BLL.DTO;
using MicroWiki.BLL.Interfaces;
using MicroWiki.DAL.Entities;
using MicroWiki.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.BLL.Service
{
   public class ArticleService : IArticleService
    {
        IUnitOfWork Database { get; set; }

        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeEdit(EditDTO editDTO)
        {
            Article article = Database.Articles.Get(editDTO.Id);
            EditData edit = new EditData
            {
                Id = article.Id,
                Description = editDTO.Description,
                Owner = editDTO.Owner,
                Time = DateTime.Now
            };
            Database.Edits.Create(edit);
            Database.Save();
        }

        public ArticleDTO GetArticle(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id статьи");
            var article = Database.Articles.Get(id.Value);
            if (article == null)
                throw new ValidationException("Статья не найдена");

            return new ArticleDTO { Id = article.Id, Category = article.Category, Text = article.Text, Title = article.Title };
        }

        public IEnumerable<ArticleDTO> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
