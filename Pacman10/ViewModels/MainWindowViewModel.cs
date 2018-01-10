using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Pacman10.Infrastructure;
using System.Windows.Media;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Threading;
using DAL.Models;
using System.Reflection;
using Pacman10.Struct;
using Pacman10.Interfaces;
using System.IO;
using Pacman10.Models;
using System.Threading;

namespace Pacman10
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        private RelayCommand openLeaderboard;
        private RelayCommand openNewGame;
        private RelayCommand loaded;
        private RelayCommand keydown;
        Score score;

        public MainWindowViewModel(string connectionString)
        {
            new ScoreService(connectionString);
            score = new Score() { Name = GameModel.Name, Points = 0 };
        }

        public string Score
        {
            get { return "Score: " + score.Points; }
            set
            {
                score.Points = Convert.ToInt32(value);
                OnPropertyChanged("Score");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public RelayCommand OpenLeaderboard => openLeaderboard ?? (openLeaderboard = new RelayCommand(form =>
        {
            Type FormType = Type.GetType("Pacman10." + form as string, false, true);
            ConstructorInfo ci = FormType.GetConstructor(new Type[] { });
            var ThisForm = ci.Invoke(new object[] { });
            MethodInfo ShowMethod = FormType.GetMethod("Show", new Type[] { });
            ShowMethod.Invoke(ThisForm, new Type[] { });
        }));
        public RelayCommand OpenNewGame => openNewGame ?? (openNewGame = new RelayCommand(form =>
        {
            Type FormType = Type.GetType("Pacman10." + form as string, false, true);
            ConstructorInfo ci = FormType.GetConstructor(new Type[] { });
            var ThisForm = ci.Invoke(new object[] { });
            MethodInfo ShowMethod = FormType.GetMethod("Show", new Type[] { });
            ShowMethod.Invoke(ThisForm, new Type[] { });
            var window = Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }));
        public RelayCommand Load => loaded ?? (loaded = new RelayCommand(_canvas =>
                                                     {
                                                         if (GameModel.Selected)
                                                         {
                                                             MainWindowModel.LoadAssembly();
                                                             Canvas canvas = _canvas as Canvas;
                                                             MainWindowModel.AddToCanvas(canvas);
                                                         }
                                                     }));
        public RelayCommand KeyDown => keydown ?? (keydown = new RelayCommand(_canvas =>
        {
            if (GameModel.Selected)
            {
                Canvas canvas = _canvas as Canvas;
                MainWindowModel.Moovment(canvas, ref score);
                Score = score.Points.ToString();
            }
        }));



    }
}
