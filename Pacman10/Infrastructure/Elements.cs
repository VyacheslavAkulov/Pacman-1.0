using Pacman10.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pacman10.Infrastructure
{
    public class Elements:IGameElements
    {
        Cell[,] cells;
        static Random r = new Random();

        public Cell[,] Cells { get => cells; set => cells = value; }

        public Image GetPackman(double height, double width)
        {
            return new Image()
            {
                Height = height,
                Width = width,
                Source = new BitmapImage(new Uri(@"C:\Users\Viacheslav Akulov\source\repos\Pacman10\Pacman10\Images\1200px-Pac_Man.svg.png", UriKind.Absolute)),
            };
        }
        public IEnumerable<Image> GetCoins(double height, double width, int count)
        {
            List<Image> Coins = new List<Image>(count);
            for (int i = 0; i < count; i++)
            {
                Coins.Add(new Image()
                {
                    Height = height,
                    Width = width,
                    Source = new BitmapImage(new Uri(@"C:\Users\Viacheslav Akulov\source\repos\Pacman10\Pacman10\Images\LX_One_Euro_Coin.png", UriKind.Absolute)),
                });
            }
            return Coins;
        }
        public IEnumerable<Polyline> GetField(int height, int width, int strokethickness, SolidColorBrush solidColorBrush)
        {
          
            List<Polyline> polyline = new List<Polyline>();
            Cells = new ListCells().CreateCells(height, width);
            for (int y = 0; y < width; y++)
                for (int x = 0; x < height; x++)
                {
                    if (Cells[x, y].Top == CellState.Close)
                        polyline.Add(new Polyline()
                        {

                            Stroke = solidColorBrush,
                            StrokeThickness = strokethickness,
                            Points = new PointCollection(2) { new Point(60 * x, 60 * y), new Point(60 * x + 60, 60 * y) }
                            
                        });

                    if (Cells[x, y].Left == CellState.Close)
                        polyline.Add(new Polyline()
                        {
                            Stroke = solidColorBrush,
                            StrokeThickness = strokethickness,
                            Points = new PointCollection(2) { new Point(60 * x, 60 * y), new Point(60 * x, 60 * y + 60) }

                        });

                    if (Cells[x, y].Right == CellState.Close)
                        polyline.Add(new Polyline()
                        {
                            Stroke = solidColorBrush,
                            StrokeThickness = strokethickness,
                            Points = new PointCollection(2) { new Point(60 * x + 60, 60 * y), new Point(60 * x + 60, 60 * y + 60) }

                        });

                    if (Cells[x, y].Bottom == CellState.Close)
                        polyline.Add(new Polyline()
                        {
                            Stroke = solidColorBrush,
                            StrokeThickness = strokethickness,
                            Points = new PointCollection(2) { new Point(60 * x, 60 * y + 60), new Point(60 * x + 60, 60 * y + 60) }

                        });
                }
            return polyline;

        }
        public IEnumerable<Image> GetEnemy(double height, double width, int count)
        {
            string[] images = new string[]
            {
                @"C:\Users\Viacheslav Akulov\source\repos\Pacman10\Pacman10\Images\193957-200.png",
                @"C:\Users\Viacheslav Akulov\source\repos\Pacman10\Pacman10\Images\pacman.png"
            };
            List<Image> enemy = new List<Image>();
            for (int i = 0; i < count; i++)
            {
                enemy.Add(new Image()
                {
                    Height = height,
                    Width = width,
                    Source = new BitmapImage(new Uri(images[r.Next(0, images.Length)]))
                });
            }
            return enemy;
        }
    }
}
