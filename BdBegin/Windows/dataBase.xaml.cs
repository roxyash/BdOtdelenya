using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

    //ну и где ошибка,

    /// <summary>
    /// Логика взаимодействия для dataBase.xaml
    /// </summary>
    public partial class dataBase : Window
    {
        private const string _conString = @"Data Source=(localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog=Karataev;" +
                                          "Integrated Security=True";
        public dataBase()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(_conString);
        private void ShutDownButton(object sender, RoutedEventArgs e)
        {
            connection.Close();
            MessageBox.Show("Вы отключены от сервера");
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Visible;
            this.Close();
        }

        private void StudentsButton(object sender, RoutedEventArgs e)
        {
            Deportaments deportamentsObject = new Deportaments();
            this.Visibility = Visibility.Collapsed;
            deportamentsObject.Show();
        }

        private void SpecialsButton(object sender, RoutedEventArgs e)
        {
            Specials specialsObject = new Specials();
            this.Visibility = Visibility.Collapsed;
            specialsObject.Show();
        }

        private void TeachersButton(object sender, RoutedEventArgs e)
        {
            Teachers teachersObject = new Teachers();
            this.Visibility = Visibility.Collapsed;
            teachersObject.Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.PasswordWindow pw = new Windows.PasswordWindow();
            pw.Visibility = Visibility.Visible;
            this.Close();
        }

        private void StudentsAllButton(object sender, RoutedEventArgs e)
        {
            StudentsAll studentsAllobject = new StudentsAll();
            this.Visibility = Visibility.Collapsed;
            studentsAllobject.Show();
        }

        private void DeportamentsButton(object sender, RoutedEventArgs e)
        {
            Windows.DeportamentsMenu DeportamentsMenuObj = new Windows.DeportamentsMenu();
            DeportamentsMenuObj.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
