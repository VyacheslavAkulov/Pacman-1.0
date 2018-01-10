using Pacman10.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pacman10
{
    /// <summary>
    /// Логика взаимодействия для NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        public NewGame()
        {
            InitializeComponent();
            DataContext = new NewGameViewModel();
        }
    }
}
