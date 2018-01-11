using DAL.DbContexts;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ScoreRepository : IRepository
    {
        private ScoreContext db;

        public ScoreRepository(string connectionString)
        {
            this.db = new ScoreContext(connectionString);
        }

        public void Add(Score item)
        {
            db.Scores.Add(item);
            Save();
        }

        public IEnumerable<Score> GetTen()
        {
            return db.Scores.OrderByDescending(x => x.Points).Take(10).ToList();
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
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
