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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void AddSpecialsButton(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Teachers (First_Name_Teacher,Last_Name_Teacher,Mid_Name_Teacher,Address_Teacher,Cod_Subject,Number_Group)values(@nm,@ln,@mn,@ad,@cs,@ng)";
            cmd.Parameters.AddWithValue("@ct", CodTeacher.Text);
            cmd.Parameters.AddWithValue("@nm", NameTeacher.Text);
            cmd.Parameters.AddWithValue("@ln", LastNameTeacher.Text);
            cmd.Parameters.AddWithValue("@mn", MidNameTeacher.Text);
            cmd.Parameters.AddWithValue("@ad", AddressTeacher.Text);
            cmd.Parameters.AddWithValue("@cs", CodSubject.Text);
            cmd.Parameters.AddWithValue("@ng", NumberGroups.Text);
            if ((NameTeacher.Text == "") && (LastNameTeacher.Text == "") && (MidNameTeacher.Text == "") && (AddressTeacher.Text == "") && (CodSubject.Text == "") && (NumberGroups.Text == ""))
            {
                MessageBox.Show("Данные не веедены, повторите попытку");
                return;

            }


            cmd.Connection = connection;
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Запись успешно добавлена");
                NameTeacher.Text = "";
                LastNameTeacher.Text = "";
                MidNameTeacher.Text = "";
                AddressTeacher.Text = "";
                CodSubject.Text = "";
                NumberGroups.Text = "";
         
            }
            else
            {
                MessageBox.Show("Ошибка ввода, повторите попытку!");
                return;
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.Teachers TeachersObj = new Windows.Teachers();
            TeachersObj.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
