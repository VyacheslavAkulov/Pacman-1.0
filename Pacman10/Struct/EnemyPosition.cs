using System.Windows;

namespace Pacman10.Struct
{
    public struct EnemyPosition
    {
        public Point Point;
        public int EnemiesSide;

        public EnemyPosition(Point point, int enemiesSide)
        {
            this.Point = point;
            EnemiesSide = enemiesSide;
        }
    }
}
