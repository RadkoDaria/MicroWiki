using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
    }
}
