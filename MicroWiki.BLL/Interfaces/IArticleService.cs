using MicroWiki.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.BLL.Interfaces
{
   public interface IArticleService
    {
        void MakeEdit(EditDTO editDTO);
        ArticleDTO GetArticle(int? id);
        IEnumerable<ArticleDTO> GetArticles();
        void Dispose();
    }
}
