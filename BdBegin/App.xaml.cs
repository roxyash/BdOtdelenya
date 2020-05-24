using BdBegin.Data;
using BdBegin.Data.TestData;
using BdBegin.Models;
using BdBegin.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BdBegin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Student CurrentStudent { get; set; }

        public IDataApp DataApp { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //подключение источника данных программы
            DataApp = new TestDataApp();

            MainWindow wnd = new MainWindow();
            wnd.Show();
        }
    }
}
