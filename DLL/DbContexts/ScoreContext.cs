using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    class ScoreContext : DbContext
    {
        public ScoreContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Score> Scores { get; set; }
    }
}
