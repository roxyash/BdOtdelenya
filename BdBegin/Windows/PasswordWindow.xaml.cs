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
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    ///

    public partial class PasswordWindow : Window
    {
        Windows.dataBase dataBaseObject = new Windows.dataBase();
        private const string _conString = @"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True";
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void SignButton(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();

            string Log = Login.Text;
            string pw = Password.Password;
            string cmd = "SELECT * FROM Users  where Username='" + Log + "' and Password='" + pw + "' ";
            SqlCommand createCommand = new SqlCommand(cmd, connection);

            createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                count++;
            }




            
            if (count==1)
            {
                MessageBox.Show($"Здравствуйте {Log}!");
                this.Close();
                 dataBaseObject.Show();
            }
            if (count < 1)
            {
                //if(Log.Length<5 && Log.Length>12)
                //{
                //    MessageBox.Show("Логин должен содержать от 6 до 11 символов");
                //    return;
                //}
                //if(pw.Length < 8 && pw.Length>16)
                //{
                //    MessageBox.Show("Пароль должен содержать от 9 до 15 символов");
                //    return;
                //}
                MessageBox.Show("Логин или пароль не правильный");
                Login.Clear();
                Password.Clear();
            }
            if (count > 1)
            {
               
                MessageBox.Show("Логин или пароль не правильный");
                Login.Clear();
                Password.Clear();
            }

           

        }
        
        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Visible;
            this.Close();
            
        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            Windows.Registration regObject = new Windows.Registration();
            this.Close();
            regObject.Show();
        }
    }
}
