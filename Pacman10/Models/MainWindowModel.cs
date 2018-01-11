using DAL.Models;
using Pacman10.Infrastructure;
using Pacman10.Interfaces;
using Pacman10.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Pacman10.Models
{
    static class MainWindowModel
    {

        public static readonly string pluginPath;
        
        static DispatcherTimer dispatcherTimer;
        public static Random rand;

        public static List<EnemyPosition> Enemies;
        public static List<Point> Coins;

        static Score score;

        static IGameElements elements;

        static public IGameElements Elements { get => elements; set => elements = value; }
        static MainWindowModel()
        {
            pluginPath = @"Plagins";
            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            rand = new Random();
            Enemies = new List<EnemyPosition>();
            Coins = new List<Point>();
            score = new Score() { Name = GameModel.Name, Points = 0 };
        }

        public static void LoadAssembly()
        {
            int index = GameModel.AssemblyName.IndexOf(",");
            string path = GameModel.AssemblyName.Remove(index);

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginPath, path + ".dll");

            Assembly asm = Assembly.LoadFrom(pluginFiles.First());
            var type = asm.GetType(GameModel.ClassName);
            var plugin = asm.CreateInstance(type.FullName) as IGameElements;
            Elements = plugin;
        }
        public static void AddToCanvas(Canvas canvas)
        {
            //canvas.Children.Clear();
            Coins.Clear();
            Enemies.Clear();

            canvas.Children.Add(Elements.GetPackman(35, 35));
            canvas.Children[0].SetValue(Canvas.TopProperty, 10.0);
            canvas.Children[0].SetValue(Canvas.LeftProperty, 10.0);

            foreach (var item in Elements.GetField(13, 9, 6, Brushes.Red))
            {
                canvas.Children.Add(item);
            }

            foreach (var item in Elements.GetEnemy(35, 35, 10))
            {
                canvas.Children.Add(item);
                canvas.Children[canvas.Children.Count - 1].SetValue(Canvas.TopProperty, rand.Next(1, 9) * 60.0 + 10.0);
                canvas.Children[canvas.Children.Count - 1].SetValue(Canvas.LeftProperty, rand.Next(0, 13) * 60.0 + 10.0);
                Enemies.Add(new EnemyPosition(new Point((Canvas.GetLeft(canvas.Children[canvas.Children.Count - 1]) - 10), (Canvas.GetTop(canvas.Children[canvas.Children.Count - 1]) - 10)), 0));
            }

            foreach (var item in Elements.GetCoins(35, 35, 50))
            {
                canvas.Children.Add(item);
                canvas.Children[canvas.Children.Count - 1].SetValue(Canvas.TopProperty, rand.Next(0, 9) * 60.0 + 10.0);
                canvas.Children[canvas.Children.Count - 1].SetValue(Canvas.LeftProperty, rand.Next(0, 13) * 60.0 + 10.0);
                Coins.Add(new Point((Canvas.GetLeft(canvas.Children[canvas.Children.Count - 1]) - 10) / 60, (Canvas.GetTop(canvas.Children[canvas.Children.Count - 1]) - 10) / 60));
            }

            Timer(canvas);
        }
        public static void Timer(Canvas canvas)
        {
            dispatcherTimer.Tick += MovementOfEnemies;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i] = new EnemyPosition(new Point(Enemies[i].Point.X, Enemies[i].Point.Y), rand.Next(0, 4));
            }

            dispatcherTimer.Start();

            #region TimerEvent
            void MovementOfEnemies(object sender, EventArgs e)
            {

                for (int i = 0; i < Enemies.Count; i++)
                {
                    switch (Enemies[i].EnemiesSide)
                    {
                        case 0:
                            {
                                Elements.EmenyMoveDown(canvas, i, Enemies, Coins.Count, rand);
                                break;
                            }
                        case 1:
                            {
                                Elements.EmenyMoveUp(canvas, i, Enemies, Coins.Count, rand);
                                break;
                            }
                        case 2:
                            {
                                Elements.EmenyMoveLeft(canvas, i, Enemies, Coins.Count, rand);
                                break;
                            }
                        case 3:
                            {
                                Elements.EmenyMoveRight(canvas, i, Enemies, Coins.Count, rand);
                                break;
                            }
                        default:break;
                    }
                }

                if (Elements.HitOnEnemy(canvas, Enemies, Coins.Count))
                {
                    dispatcherTimer.Stop();
                    GameModel.Selected = false;
                    MessageBox.Show("Вы проиграли!!!", "Oooops", MessageBoxButton.OK);
                    canvas.Children.Clear();
                    ScoreService.ScoreRepository.Add(score);
                }
            }
            #endregion
        }
        public static void Moovment(Canvas canvas,ref Score Score)
        {
            if (Keyboard.IsKeyDown(Key.Down))
            {
                Elements.MoveDown(canvas);
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                Elements.MoveUp(canvas);
            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                Elements.MoveLeft(canvas);
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                Elements.MoveRight(canvas);
            }

            if (Elements.MoneyCollector(canvas, Coins))
            {
                Score.Points += 25;
                if (Coins.Count == 0)
                {
                    dispatcherTimer.Stop();
                    GameModel.Selected = false;
                    MessageBox.Show("Вы выиграли!!!", "Поздравляем", MessageBoxButton.OK);
                    canvas.Children.Clear();
                    ScoreService.ScoreRepository.Add(score);
                }
            }
        }

    }
}
