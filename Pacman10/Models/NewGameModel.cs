using Pacman10.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Pacman10.Models
{
    static class NewGameModel
    {
        public static void SearchAssemblies(ListBox listBox,string pluginPath,List<Type> Asm)
        {
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

            foreach (var file in pluginFiles)
            {
                //Console.WriteLine(Assembly.LoadFrom(file).ToString());
                Console.WriteLine(file);
                Assembly asm = Assembly.LoadFrom(Path.GetFullPath(file));

                var types = asm.GetTypes().
                            Where(t => t.GetInterfaces().
                            Where(i => i.FullName == typeof(IGameElements).FullName).Any());

                Asm.AddRange(types);

            }
            listBox.ItemsSource = Asm;
        }

    }
}