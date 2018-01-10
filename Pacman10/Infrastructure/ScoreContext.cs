using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Pacman10
{
    class ScoreContext: DbContext
    {
        public ScoreContext()
                : base("DbConnection")
            { }

        public DbSet<Score> Scores { get; set; }

    }
}
