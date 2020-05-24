using BdBegin.Data;
using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BdBegin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Teachers.xaml
    /// </summary>
    public partial class Teachers : Window
    {
        private ObservableCollection<Teacher> _teachers = new ObservableCollection<Teacher>();
        private IDataApp dataApp = ((App)Application.Current).DataApp;
        public Teachers()
        {
            InitializeComponent();
            LoadDataGridTeacher();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.dataBase dataBaseObject = new Windows.dataBase();
            dataBaseObject.Visibility = Visibility.Visible;
            this.Close();
        }

        public void LoadDataGridTeacher()
        {
            List<Teacher> teachers = dataApp.Teachers.GetAll();
            teachers.ForEach(_teachers.Add);
            TeachersGrid.ItemsSource = _teachers;
            //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            //connection.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * From Teachers";
            //cmd.Connection = connection;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("Teachers");
            //da.Fill(dt);
            //TeachersGrid.ItemsSource = dt.DefaultView;

        }

        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            var std = new Teacher()
            {
                FirstName = "имя",
                LastName = "фамилия",
                MiddleName = "отчество",
                
            };
            Windows.AddTeacher AddTeachersObj = new Windows.AddTeacher();
            AddTeachersObj.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ChangeTeacher(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveTeacher(object sender, RoutedEventArgs e)
        {

        }
    }
}
