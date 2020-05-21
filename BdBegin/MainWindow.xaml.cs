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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace BdBegin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion
      //  SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
        
        Windows.PasswordWindow pwObject = new Windows.PasswordWindow();
        Windows.dataBase dataBaseObject = new Windows.dataBase();
       
        // MainWindow main = new MainWindow();
        private void ConnectionButton(object sender, RoutedEventArgs e)
        {
            try
            {
                //connection.Open();
                
                pwObject.Show();
                this.Visibility = Visibility.Collapsed;
             
            }
            catch(Exception)
            {
                MessageBox.Show("Подключение не удалось, повторите попытку");
            }
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ReferenceButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Версия приложения 0.0.1\n" +
                            "Создатель приложения Roxyash\n" +
                            "Спасибо, что используете наше приложение");
        }

        private void PropertiesButton(object sender, RoutedEventArgs e)
        {
            Windows.PropertiesWindow propertiesObject = new Windows.PropertiesWindow();
            propertiesObject.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
    
}
