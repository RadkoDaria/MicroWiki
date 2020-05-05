using MicroWiki.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.BLL.DTO
{
   public class EditDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public Article Owner { get; set; }
    }
}
