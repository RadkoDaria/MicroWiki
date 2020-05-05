using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.DAL.Entities
{
    public class EditData
    {
        [Key]
        [ForeignKey("Article")]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public virtual Article Owner { get; set; }

        public Article Article { get; set; }
    }
}
