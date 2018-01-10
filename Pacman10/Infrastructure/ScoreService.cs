using DAL.Interfaces;
using DAL.Repositories;

namespace Pacman10.Infrastructure
{
    public class ScoreService
    {
        public static ScoreRepository ScoreRepository;

        public ScoreService(string connectionString)
        {
            ScoreRepository = new ScoreRepository(connectionString);
        }
    }
}