using MicroWiki.DAL.Entities;
using MicroWiki.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWiki.DAL.Repos
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private WikiContext db;
        private EditRepository editRepository;
        private ArticleRepository articleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new WikiContext(connectionString);
        }
        public IRepository<EditData> Edits
        {
            get
            {
                if (editRepository == null)
                    editRepository = new EditRepository(db);
                return editRepository;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
