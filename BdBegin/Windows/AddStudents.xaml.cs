using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Window
    {
        private const string _conString = @"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True";
        public AddStudents(StudentsClass student)
        {
            InitializeComponent();
            Student = student;
            this.Name.Text = Student.FirstName;
            this.LastName.Text = Student.LastName;
            this.MidName.Text = Student.MidName;
            this.Address.Text = Student.Address;
            this.Course.Text = Student.Course.ToString();
            //this.Birthdate.Text = Student.Course.ToString();


        }
        public StudentsClass Student { get; set; }
        



        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.Deportaments DeportamentsObject = new Windows.Deportaments();
            DeportamentsObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void AddStudentsButton(object sender, RoutedEventArgs e)
        {
            if (Student.NumberStudents > 0)
            {
                UpdateStudent();
            }
            else
            {
                AddStudent();
            }

            


        }

        private void AddStudent()
        {
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Students (First_Name_Students,Last_Name_Students,Mid_Name_Students,Address_Students,Course_Students)values(@nm,@ln,@mn,@ad,@co)";
            cmd.Parameters.AddWithValue("@nm", this.Name.Text);
            cmd.Parameters.AddWithValue("@ln", this.LastName.Text);
            cmd.Parameters.AddWithValue("@mn", this.MidName.Text);
            cmd.Parameters.AddWithValue("@ad", this.Address.Text);
            cmd.Parameters.AddWithValue("@co", this.Course.Text);
            if ((this.Name.Text == "") && (this.LastName.Text == "") && (this.MidName.Text == "") && (this.Address.Text == "") && (this.Course.Text == ""))
            {
                MessageBox.Show("Данные не веедены, повторите попытку");
                return;

            }


            cmd.Connection = connection;
            try
            {
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("Запись успешно добавлена");
                    Name.Text = "";
                    LastName.Text = "";
                    MidName.Text = "";
                    Address.Text = "";
                    Course.Text = "";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные ввода не корректны, повторите попытку.");
            }
        }

        private void UpdateStudent()
        {
            int updated = 0;
            try
            {
                using (var cnn = new SqlConnection(_conString))
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Students
                                    SET First_Name_Students=@fname,Mid_Name_Students=@mname, Last_Name_Students=@lname, Address_Students=@address, Course_Students = @course, Birthday_Students=@bd
                                    WHERE Number_Students = @id";
                    cmd.Parameters.AddWithValue("@fname", this.Name.Text);
                    cmd.Parameters.AddWithValue("@lname", this.LastName.Text);
                    cmd.Parameters.AddWithValue("@mname", this.MidName.Text);
                    cmd.Parameters.AddWithValue("@address", this.Address.Text);
                    cmd.Parameters.AddWithValue("@course", this.Course.Text);
                    cmd.Parameters.AddWithValue("@bd", DateTime.Today);
                    cmd.Parameters.AddWithValue("@id", Student.NumberStudents);

                    cnn.Open();
                    updated = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show($"Обновлено {updated}");
        }
    }
}
