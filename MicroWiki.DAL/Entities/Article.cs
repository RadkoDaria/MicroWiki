using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroWiki.DAL.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public string Text { get; set; }

        public virtual List<EditData> Edits { get; set; }
        
    }

}
