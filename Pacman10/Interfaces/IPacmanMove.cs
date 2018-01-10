using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pacman10.Interfaces
{
    public interface IPacmanMove
    {
        void MoveLeft(Canvas canvas);
        void MoveRight(Canvas canvas);
        void MoveDown(Canvas canvas);
        void MoveUp(Canvas canvas);
        bool MoneyCollector(Canvas canvas, List<Point> Coins);
    }
}
