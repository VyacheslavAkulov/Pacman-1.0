using DAL.Models;
using DAL.Repositories;
using Pacman10.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman10
{
    class LeaderboardViewModel:INotifyPropertyChanged
    {
        private Score selectedScore;

        public IEnumerable<Score> Score { get;}

        public Score SelectedScore
        {
            get { return selectedScore; }
            set
            {
                selectedScore = value;
                OnPropertyChanged("SelectedScore");
            }
        }

        public LeaderboardViewModel()
        {
            Score = ScoreService.ScoreRepository.GetTen();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
