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

namespace BdBegin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Teachers.xaml
    /// </summary>
    public partial class Teachers : Window
    {
        public Teachers()
        {
            InitializeComponent();
            binddatagrid();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.dataBase dataBaseObject = new Windows.dataBase();
            dataBaseObject.Visibility = Visibility.Visible;
            this.Close();
        }

        public void binddatagrid()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * From Teachers";
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Teachers");
            da.Fill(dt);
            TeachersGrid.ItemsSource = dt.DefaultView;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddTeacher AddTeachersObj = new Windows.AddTeacher();
            AddTeachersObj.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
