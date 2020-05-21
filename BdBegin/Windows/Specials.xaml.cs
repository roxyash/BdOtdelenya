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
    /// Логика взаимодействия для Specials.xaml
    /// </summary>
    public partial class Specials : Window
    {
        private const string _selectString = "SELECT * FROM Special";
        private readonly DataTable _dataTable;
        private const string _conString = @"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True";
        public Specials()
        {
            InitializeComponent();
            _dataTable = new DataTable("Special");
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
            cmd.CommandText = "select * From Special";
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            da.Fill(_dataTable);
            StudentsGrid.ItemsSource = _dataTable.DefaultView;

            removeButton.Click += removeButton_Click;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddSpecial AddSpecialObj = new Windows.AddSpecial();
            AddSpecialObj.Visibility = Visibility.Visible;
            this.Close();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var row = StudentsGrid.SelectedItem as DataRowView;
            if (row == null)
                return;

            row.Delete();
            try
            {
                using (var adp = new SqlDataAdapter(_selectString, _conString))
                using (var cmb = new SqlCommandBuilder(adp))
                {
                    var deleted = adp.Update(_dataTable);
                    MessageBox.Show("Запись удалена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchText.Text == "")
            {
                MessageBox.Show("Кого ищем?");
            }
            string id = SearchText.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter DataAdapter = new SqlDataAdapter("select * From special where Cod_Special = '" + id + "'", connection);
            DataAdapter.Fill(_dataTable);
            if (_dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Такого значения не существует");
                connection.Close();
            }
            else
            {
                DataSet a = new DataSet();
                DataAdapter.Fill(a);
                StudentsGrid.ItemsSource = a.Tables[0].DefaultView;
                connection.Close();
            }
        }
    }
}
