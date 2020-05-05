using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.DAL.Entities
{
   public class WikiContext : DbContext 
    {
        static WikiContext()
        {
            Database.SetInitializer<WikiContext>(new WikiDbInitializer());
        }
        public WikiContext(string connectionString) : base(connectionString)
        //: base(@"Data Source=EPKZKARW0753;Initial Catalog=MVCexample;Integrated Security=True")
        {

        }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<EditData> Edits { get; set; }

        public class WikiDbInitializer : DropCreateDatabaseIfModelChanges<WikiContext>
        {
            protected override void Seed(WikiContext db)
            {
             
                db.SaveChanges();
            }
        }
    }
}
