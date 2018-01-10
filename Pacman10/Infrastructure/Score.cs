using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman10
{
    public class Score : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private int points;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("iD");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
