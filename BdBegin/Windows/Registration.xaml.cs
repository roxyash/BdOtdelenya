using System;
using System.Collections.Generic;
using System.Data;
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
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace BdBegin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }


        private void SignIn(object sender, RoutedEventArgs e)
        {
            
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Users (Username,Password,Email,Name,LastName,Gender) VALUES (@Login,@Password,@Email,@Name,@LastName,@Gender)", connection);
            // if ((FirstName.Text != "") && (FirstName.Text != "Введите имя") && (LastName.Text != "") && (LastName.Text != "Введите фамилию") && (login.Text != "") && (login.Text != "Введите логин") && (pw.Password != ""))
            if (FirstName.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (FirstName.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (LastName.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (LastName.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (login.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (login.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (pw.Password == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if(isUserExists())
            {
                return;
            }
           if((Man.IsChecked == false) && (Girl.IsChecked==false))
            {
                MessageBox.Show("Выберите пол");
                return;
               
            }
           if(login.Text.Length<5)
            {
                MessageBox.Show("Логин слишком короткий!\nПридумайте другой.");
                return;
            }
            if (login.Text.Length > 12)
            {
                MessageBox.Show("Логин слишком длинный!\nПридумайте другой.");
                return;
            }
            if(pw.Password.Length<8)
            {
                MessageBox.Show("Пароль слишком короткий!\nПридумайте другой.");
                return;
            }
            if(pw.Password.Length>16)
            {
                MessageBox.Show("Пароль слишком длинный!\nПридумайте другой.");
                return;
            }
            if(email.Text == "")
            {
                MessageBox.Show("Введите поле Email\nНа вашу почту придет Логин и Пароль.");
                return;             
            }
            if(email.Text == "Введите email")
            {
                MessageBox.Show("Введите email");
                return;
            }
            
           
            if (pw.Password == repeatpw.Password)
                {
                    command.Parameters.Add("@Login", System.Data.SqlDbType.VarChar).Value = login.Text;
                    command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = pw.Password;
                    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = email.Text;
                    command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = FirstName.Text;
                    command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar).Value = LastName.Text;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("roxyashproduct@mail.ru"); // Адрес отправителя
                if(isValid(email.Text))
                {
                    mail.To.Add(new MailAddress($"{email.Text}")); // Адрес получателя
                }
                else
                {
                    MessageBox.Show("Не правильный формат Email.\nПовторите попытку!");
                    return;
                }
               
                mail.Subject = "Roxyash company inc";
                mail.Body =  $"Здравствуйте {FirstName.Text}! Вы успешно прошли регистраци. Мы рады видеть, что вы используете наше приложение. Вот ваш логин: {login.Text} и пароль {pw.Password} в случае, если вы забудете его. С наилучшими пожеланиями Roxyash company inc";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru";
                client.Port = 587; // Обратите внимание что порт 587
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("roxyashproduct@mail.ru", "TIME01081222MM"); // Ваши логин и пароль
                client.Send(mail);
                string man = "Мужской";
                string woman = "Женский";

                if(Man.IsChecked==true)
                {
                    command.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar).Value = man;
                }
                if(Girl.IsChecked == true)
                {
                    command.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar).Value = woman;
                }

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show($"Поздравляем {FirstName.Text}! Вы успешно прошли регистрацию\n Логин и пароль отправили на вашу почту!");
                        Windows.PasswordWindow pwObject = new Windows.PasswordWindow();

                        this.Close();
                        pwObject.Show();
                    }
                    else
                    {
                        MessageBox.Show("Аккаунт не был создан");
                    }
                }
            else
            {
                MessageBox.Show("Пароли не совпадают. Повторите попытку!");
                return;
            }
            connection.Close();   
        }
        public bool isUserExists()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");

            
            string cmd = "SELECT * FROM Users WHERE Username=@Login";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@Login", SqlDbType.VarChar).Value = login.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            
            if(table.Rows.Count>0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть.\nПовторите попытку!");
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void ShutDownButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            Windows.PasswordWindow pwObject = new Windows.PasswordWindow();
            pwObject.Show();
        }

        private void FirstName_Loaded(object sender, RoutedEventArgs e)
        {
            FirstName.Text = "Введите имя";
            FirstName.Foreground = new SolidColorBrush(Colors.Gray);
        }

        
        private void FirstName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(FirstName.Text == "Введите имя")
            {
                FirstName.Clear();
                FirstName.Foreground = new SolidColorBrush(Colors.Black);
            }    
        }

        private void LastName_Loaded(object sender, RoutedEventArgs e)
        {
            LastName.Text = "Введите фамилию";
            LastName.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LastName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(LastName.Text == "Введите фамилию")
            {
                LastName.Clear();
                LastName.Foreground = new SolidColorBrush(Colors.Black);
            }    
        }

        private void login_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(login.Text == "Введите логин")
            {
                login.Clear();
                login.Foreground = new SolidColorBrush(Colors.Black);
            }    
        }

        private void login_Loaded(object sender, RoutedEventArgs e)
        {
            login.Text = "Введите логин";
            login.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void email_Loaded(object sender, RoutedEventArgs e)
        {
            email.Text = "Введите email";
            email.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void email_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(email.Text == "Введите email")
            {
                email.Clear();
                email.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void login_MouseEnter(object sender, MouseEventArgs e)
        {
            login.ToolTip = "Минимальная длина 5 символов \nМаксимальная 12 символов";
        }

        private void pw_MouseEnter(object sender, MouseEventArgs e)
        {
            pw.ToolTip = "Минимальная длина пароля 8 символов \nМаксимальная 16";
        }
    }
}
