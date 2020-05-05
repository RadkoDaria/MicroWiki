using MicroWiki.DAL.Entities;
using MicroWiki.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MicroWiki.DAL.Repos
{
    public class EditRepository : IRepository<EditData>
    {
        private WikiContext db;

        public EditRepository(WikiContext context)
        {
            this.db = context;
        }

        public IEnumerable<EditData> GetAll()
        {
            return db.Edits;
        }

        public EditData Get(int id)
        {
            return db.Edits.Find(id);
        }

        public void Create(EditData edit)
        {
            db.Edits.Add(edit);
        }

        public void Update(EditData edit)
        {
            db.Entry(edit).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EditData edit = db.Edits.Find(id);
            if (edit != null)
                db.Edits.Remove(edit);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<EditData> Find(Func<EditData, bool> predicate)
        {
            return db.Edits.Where(predicate).ToList();
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
