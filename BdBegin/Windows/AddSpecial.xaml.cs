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
    /// Логика взаимодействия для AddSpecial.xaml
    /// </summary>
    public partial class AddSpecial : Window
    {
        public AddSpecial()
        {
            InitializeComponent();
        }



        private void AddSpecialsButton(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Special (Cod_Special,Name_Special,Number_Deportaments)values(@cs,@ns,@nd)";
            cmd.Parameters.AddWithValue("@cs", CodSpecial.Text);
            cmd.Parameters.AddWithValue("@ns", NameSpecial.Text);
            cmd.Parameters.AddWithValue("@nd", NumberDeportaments.Text);

            if ((CodSpecial.Text == "") && (NameSpecial.Text == "") && (NumberDeportaments.Text == ""))
            {
                MessageBox.Show("Данные не веедены, повторите попытку");
                return;

            }


            cmd.Connection = connection;
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Запись успешно добавлена");
                CodSpecial.Text = "";
                NameSpecial.Text = "";
                NumberDeportaments.Text = "";
  
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.Specials SpecialsObject = new Windows.Specials();
            SpecialsObject.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
