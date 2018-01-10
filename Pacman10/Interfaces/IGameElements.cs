using Pacman10.Interfaces;
using Pacman10.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pacman10.Interfaces
{
    public interface IGameElements:IPacmanMove,IEnemiesMove
    {
        Image GetPackman(double height, double width);
        IEnumerable<Image> GetCoins(double height, double width, int count);
        IEnumerable<Polyline> GetField(int height, int width, int strokethickness, SolidColorBrush solidColorBrush);
        IEnumerable<Image> GetEnemy(double height, double width, int count);
       



    }
}
