using MicroWiki.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroWiki.Web.Models
{
    public class EditDataViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public virtual Article Owner { get; set; }
    }
}