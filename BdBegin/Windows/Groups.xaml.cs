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
    /// Логика взаимодействия для Gorups.xaml
    /// </summary>
    public partial class Groups : Window
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.Deportaments DeportamentsObject = new Windows.Deportaments();
            DeportamentsObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void FirstGroup(object sender, RoutedEventArgs e)
        {
            Windows.FirsthGroup FirstGroupObject = new Windows.FirsthGroup("КС-201");
            FirstGroupObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void SecondGroup(object sender, RoutedEventArgs e)
        {
            Windows.FirsthGroup FirstGroupObject = new Windows.FirsthGroup("ПКС-306");
            FirstGroupObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ThirdGroup(object sender, RoutedEventArgs e)
        {
            Windows.FirsthGroup FirstGroupObject = new Windows.FirsthGroup("Р-113");
            FirstGroupObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void FourthGroup(object sender, RoutedEventArgs e)
        {
            Windows.FirsthGroup FirstGroupObject = new Windows.FirsthGroup("ИБ-409");
            FirstGroupObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void FifthGroup(object sender, RoutedEventArgs e)
        {
            Windows.FirsthGroup FirstGroupObject = new Windows.FirsthGroup("ЗИО-112");
            FirstGroupObject.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
