using Pacman10.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pacman10.Interfaces
{
    public interface IEnemiesMove
    {
        void EmenyMoveRight(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand);
        void EmenyMoveLeft(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand);
        void EmenyMoveUp(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand);
        void EmenyMoveDown(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand);
        bool HitOnEnemy(Canvas canvas, List<EnemyPosition> Enemies, int coinsCount);
    }
}
