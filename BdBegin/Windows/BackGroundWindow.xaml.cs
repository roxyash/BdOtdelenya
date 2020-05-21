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

namespace BdBegin.Windows
{
    /// <summary>
    /// Логика взаимодействия для BackGroundWindow.xaml
    /// </summary>
    public partial class BackGroundWindow : Window
    {
        public BackGroundWindow()
        {
            InitializeComponent();
        }
        public Windows.PropertiesWindow propertiesObject = new Windows.PropertiesWindow();
        public Windows.dataBase databaseObject = new Windows.dataBase();
        public Windows.Deportaments deportamentsObject = new Windows.Deportaments();
        public Windows.PasswordWindow paswordObject = new Windows.PasswordWindow();
        public Windows.Specials specialsObject = new Windows.Specials();
        public Windows.Teachers teachersObject = new Windows.Teachers();
        public MainWindow mainObject = new MainWindow();
        

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            propertiesObject.Show();
        }

        private void BlackBG(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Black);
            //propertiesObject.Background = new SolidColorBrush(Colors.Black);
            databaseObject.Background = new SolidColorBrush(Colors.Black);
            deportamentsObject.Background = new SolidColorBrush(Colors.Black);
            paswordObject.Background = new SolidColorBrush(Colors.Black);
            specialsObject.Background = new SolidColorBrush(Colors.Black);
            teachersObject.Background = new SolidColorBrush(Colors.Black);
            mainObject.Background = new SolidColorBrush(Colors.Black);
        }
        private void YellowBG(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Yellow);
        }
        private void DefaultBG(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
        }
        private void BlueBG(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Blue);
        }
    }
}
