using Pacman10.Interfaces;
using Pacman10.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainPlugin.Plugins.MainPlugin
{

    public class Elements : IGameElements
    {
        Cell[,] cells;
        static Random r = new Random();
        Canvas canvas;

        public Cell[,] Cells { get => cells; set => cells = value; }

        public Image GetPackman(double height, double width)
        {
            return new Image()
            {
                Height = height,
                Width = width,
                Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory()+ @"\Plagins\Images\1200px-Pac_Man.svg.png", UriKind.RelativeOrAbsolute)),
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
                    Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory()+@"\Plagins\Images\LX_One_Euro_Coin.png", UriKind.RelativeOrAbsolute)),
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
                @"\Plagins\Images\193957-200.png",
                @"\Plagins\Images\pacman.png"
            };
            List<Image> enemy = new List<Image>();
            for (int i = 0; i < count; i++)
            {
                enemy.Add(new Image()
                {
                    Height = height,
                    Width = width,
                    Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory()+images[r.Next(0, images.Length)],UriKind.RelativeOrAbsolute))
                });
            }
            return enemy;
        }
        public void MoveRight(Canvas canvas)
        {
            canvas.Children[0].RenderTransform = new RotateTransform(0, 17, 17);
            if (!(Canvas.GetLeft(canvas.Children[0]) + 3 > canvas.Width || (Cells[(int)(Canvas.GetLeft(canvas.Children[0])) / 60,
                (int)(Canvas.GetTop(canvas.Children[0]) - 10) / 60].Right == CellState.Close && (Canvas.GetLeft(canvas.Children[0])) % 60 >= 20)))
            {
                canvas.Children[0].SetValue(Canvas.LeftProperty, Canvas.GetLeft(canvas.Children[0]) + 6);
            }
        }

        public void MoveDown(Canvas canvas)
        {
            canvas.Children[0].RenderTransform = new RotateTransform(90, 17, 17);
            if (!(Canvas.GetTop(canvas.Children[0]) + 6 > canvas.Height
            || (Cells[(int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60, (int)(Canvas.GetTop(canvas.Children[0])) / 60].Bottom == CellState.Close
            && (Canvas.GetTop(canvas.Children[0])) % 60 >= 20)))
            {
                canvas.Children[0].SetValue(Canvas.TopProperty, Canvas.GetTop(canvas.Children[0]) + 6);
            }
        }

        public void MoveUp(Canvas canvas)
        {
            canvas.Children[0].RenderTransform = new RotateTransform(270, 17, 17);
            if (!(Canvas.GetTop(canvas.Children[0]) - 6 < 0 || (Cells[(int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60,
                (int)(Canvas.GetTop(canvas.Children[0])) / 60].Top == CellState.Close && (Canvas.GetTop(canvas.Children[0])) % 60 <= 6)))
            {
                canvas.Children[0].SetValue(Canvas.TopProperty, Canvas.GetTop(canvas.Children[0]) - 6);
            }
        }

        public void MoveLeft(Canvas canvas)
        {
            canvas.Children[0].RenderTransform = new RotateTransform(180, 17, 17);
            if (!(Canvas.GetLeft(canvas.Children[0]) - 6 < 0 || (Cells[(int)(Canvas.GetLeft(canvas.Children[0])) / 60,
                (int)(Canvas.GetTop(canvas.Children[0]) - 10) / 60].Left == CellState.Close && (Canvas.GetLeft(canvas.Children[0])) % 60 <= 6)))
            {
                canvas.Children[0].SetValue(Canvas.LeftProperty, Canvas.GetLeft(canvas.Children[0]) - 6);
            }
        }
        public void EmenyMoveRight(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand)
        {
            if (Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) + 3 > canvas.Width
            || (Cells[(int)(Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) / 60,
            (int)(Canvas.GetTop(canvas.Children[0]) - 10) / 60].Right == CellState.Close &&
            (Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) % 60 >= 25))
            {
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y), rand.Next(0, 4));
            }
            else
            {
                canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i].SetValue(Canvas.LeftProperty,
                    Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) + 3);
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X + 3, Enemies[i].Point.Y), Enemies[i].EnemiesSide);
            }
        }

        public void EmenyMoveLeft(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand)
        {
            if (Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 6 < 0 ||
                                    (Cells[(int)(Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) / 60,
                                    (int)(Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 10) / 60].Left == CellState.Close &&
                                    (Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) % 60 <= 12))
            {
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y), rand.Next(0, 4));
            }
            else
            {
                canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i].SetValue(Canvas.LeftProperty,
                    Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 3);
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X - 3, Enemies[i].Point.Y), Enemies[i].EnemiesSide);
            }
        }

        public void EmenyMoveUp(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand)
        {
            if (Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 6 < 0
            || (Cells[(int)(Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 10) / 60,
            (int)(Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) / 60].Top == CellState.Close
            && (Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) % 60 <= 12))
            {
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y), rand.Next(0, 4));
            }
            else
            {
                canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i].SetValue(Canvas.TopProperty,
                    Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 3);
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y - 3), Enemies[i].EnemiesSide);
            }
        }

        public void EmenyMoveDown(Canvas canvas, int i, List<EnemyPosition> Enemies, int coinsCount, Random rand)
        {
            if (Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) + 6 > canvas.Height
            || (Cells[(int)(Canvas.GetLeft(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) - 10) / 60,
            (int)(Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) / 60].Bottom == CellState.Close
            && (Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i])) % 60 >= 25))
            {
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y), rand.Next(0, 4));
            }
            else
            {
                canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i].SetValue(Canvas.TopProperty,
                    Canvas.GetTop(canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + i]) + 3);
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y + 3), Enemies[i].EnemiesSide);
            }
        }

        public bool HitOnEnemy(Canvas canvas, List<EnemyPosition> Enemies, int coinsCount)
        {
            if (Enemies.Find(enemy => (int)(enemy.Point.X / 60) == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60 &&
            (int)(enemy.Point.Y / 60) == (int)(Canvas.GetTop(canvas.Children[0])) / 60).Point != null)
            {
                EnemyPosition p = Enemies.Find(enemy => (int)(enemy.Point.X / 60) == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60 &&
                (int)(enemy.Point.Y / 60) == (int)(Canvas.GetTop(canvas.Children[0])) / 60);
                int index = Enemies.IndexOf(p);
                if (p.Point != null && index != -1)
                {
                    Image enemy = canvas.Children[canvas.Children.Count - coinsCount - Enemies.Count + index] as Image;
                    string path = Directory.GetCurrentDirectory().Replace("\\", "/");
                    if (enemy != null &&
                    (enemy.Source.ToString() ==  @"file:///"+path+ "/Plagins/Images/193957-200.png" ||
                    enemy.Source.ToString() == @"file:///" + path + "/Plagins/Images/pacman.png")
                    && Enemies.FindAll(enemies => (int)(enemies.Point.X / 60) == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60
                    && (int)(enemies.Point.Y / 60) == (int)(Canvas.GetTop(canvas.Children[0])) / 60) != null)
                    {
                        return true;
                    }

                }

            }
            return false;
        }
        public bool MoneyCollector(Canvas canvas, List<Point> Coins)
        {
            if (Coins.Find(coins => coins.X == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60 && coins.Y == (int)(Canvas.GetTop(canvas.Children[0])) / 60) != null)
            {
                Point p = Coins.Find(coins => coins.X == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60 && coins.Y == (int)(Canvas.GetTop(canvas.Children[0])) / 60);
                int index = Coins.IndexOf(p);
                if (p != null && index != -1)
                {
                    Image coin = canvas.Children[canvas.Children.Count - Coins.Count + index] as Image;               
                    string path = Directory.GetCurrentDirectory().Replace("\\", "/");
                    if (coin != null && coin.Source.ToString() == @"file:///" + path + "/Plagins/Images/LX_One_Euro_Coin.png"
                        && Coins.FindAll(coins => coins.X == (int)(Canvas.GetLeft(canvas.Children[0]) - 10) / 60 && coins.Y == (int)(Canvas.GetTop(canvas.Children[0])) / 60) != null)
                    {
                        canvas.Children.Remove(coin);
                    }
                    Coins.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

    }

}