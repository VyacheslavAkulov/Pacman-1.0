using Pacman10.Infrastructure;
using Pacman10.Interfaces;
using Pacman10.Models;
using Pacman10.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pacman10.ViewModel
{
    class NewGameViewModel : INotifyPropertyChanged
    {
        private readonly string pluginPath;

        private RelayCommand loaded;
        private RelayCommand startGame;

        private Type selectedAsm;
        public List<Type> Asm;

        private string name ;

        public NewGameViewModel()
        {
            pluginPath = "Plagins";
            Asm = new List<Type>();
            Name = "Guest";
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

        public Type SelectedAsm
        {
            get { return selectedAsm; }
            set
            {
                selectedAsm = value;
                OnPropertyChanged("SelectedAsm");
            }
        }

        public RelayCommand Loaded => loaded ?? (loaded = new RelayCommand(_listbox =>
        {
            ListBox listBox = _listbox as ListBox;
            NewGameModel.SearchAssemblies(listBox,pluginPath,Asm);
        }));

       

        public RelayCommand StartGame => startGame ?? (startGame = new RelayCommand(form =>
        {
            if (selectedAsm != null)
            {
                GameModel.Name = Name;
                GameModel.Selected = true;
                GameModel.AssemblyName = SelectedAsm.Assembly.FullName;
                GameModel.ClassName = SelectedAsm.FullName;

                Type FormType = Type.GetType("Pacman10." + form as string, false, true);
                ConstructorInfo ci = FormType.GetConstructor(new Type[] { });
                var ThisForm = ci.Invoke(new object[] { });
                MethodInfo ShowMethod = FormType.GetMethod("Show", new Type[] { });
                ShowMethod.Invoke(ThisForm, new Type[] { });
                var window = Application.Current.Windows[0];
                if (window != null)
                    window.Close();
            }
        }));

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
