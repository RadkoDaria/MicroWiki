using MicroWiki.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.DAL.EF
{
   public class MigrationsContextFactory : IDbContextFactory<WikiContext>
    {
        public WikiContext Create()
        {
            return new WikiContext("DefaultConnection");
        }
    }
}
