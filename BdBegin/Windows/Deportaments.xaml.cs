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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BdBegin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Deportaments.xaml
    /// </summary>
    public partial class Deportaments : Window
    {
        private const string _conString = @"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True";
        private ObservableCollection<StudentsClass> _tempStudents;
        //public ET DataBase = new ET();
        public Deportaments()
        {
            InitializeComponent();
            StudentsList = new ObservableCollection<StudentsClass>();
            _tempStudents = new ObservableCollection<StudentsClass>();
            LoadStudents();

            this.PreviewKeyDown += Deportaments_PreviewKeyDown;
        }

        private void Deportaments_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var txt = SearchText.Text.Trim();
            if (String.IsNullOrEmpty(txt))
            {
                //отобразить список полностью
                StudentsList.Clear();
                _tempStudents.ToList().ForEach(StudentsList.Add);
                return;
            }

            var list = StudentsList.Where(s => s.LastName.StartsWith(txt)).ToList();
            StudentsList.Clear();
            list.ForEach(StudentsList.Add);
        }

        public ObservableCollection<StudentsClass> StudentsList { get; } 

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.dataBase dataBaseObject = new Windows.dataBase();
            dataBaseObject.Visibility = Visibility.Visible;
            this.Close();
        }

        /// <summary>
        /// Загрузка полного списка студентов
        /// </summary>
        public void LoadStudents()
        {
            if (StudentsList.Count > 0)
            {
                StudentsList.Clear();
                _tempStudents.Clear();
            }
                

            try
            {
                using (var cnn = new SqlConnection(_conString))
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [Number_Students]
                                             , [First_Name_Students]
                                             , [Mid_Name_Students]
                                             , [Last_Name_Students]
                                             , [Address_Students]
                                             , [Course_Students]
                                             , [Birthday_Students]
                                        FROM Students;";
                    cnn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = GetStudentsClassFromReader(reader);
                            StudentsList.Add(student);
                            _tempStudents.Add(student);
                        }
                    }

                    SetOrderNumbers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DeportamentsGrid.ItemsSource = StudentsList;
            removeButton.Click += removeButton_Click;
        }

        private StudentsClass GetStudentsClassFromReader(SqlDataReader reader)
        {
            return new StudentsClass(reader.GetInt32(0))
            {
                FirstName = reader.IsDBNull(1) ?
                            "Неизвестно" : reader.GetString(1),
                MidName = reader.IsDBNull(2) ?
                            "Неизвестно" : reader.GetString(2),
                LastName = reader.IsDBNull(3) ?
                            "Неизвестно" : reader.GetString(3),
                Address = reader.IsDBNull(4) ?
                            "Неизвестно" : reader.GetString(4),
                Course = reader.IsDBNull(5) ?
                            0 : reader.GetInt32(5),
                BirthDay = reader.IsDBNull(6) ?
                            DateTime.Today : reader.GetDateTime(6)
            };
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var std = DeportamentsGrid.SelectedItem as StudentsClass;
            Windows.AddStudents addStudentsObject = new Windows.AddStudents(std);
            addStudentsObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadStudents();
        }

     
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var search = SearchText.Text;
            if (String.IsNullOrEmpty(search))
            {
                //если строка поиска пустая загружаем всех
                LoadStudents();
                return;
            }

            StudentsList.Clear();
            try
            {
                using (var cnn = new SqlConnection(_conString))
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [Number_Students]
                                             , [First_Name_Students]
                                             , [Mid_Name_Students]
                                             , [Last_Name_Students]
                                             , [Address_Students]
                                             , [Course_Students]
                                             , [Birthday_Students]
                                        FROM Students
                                        WHERE First_Name_Students LIKE CONCAT(@search, '%')
                                          OR Mid_Name_Students LIKE CONCAT(@search, '%')
                                          OR Last_Name_Students LIKE CONCAT(@search, '%');";
                    cmd.Parameters.AddWithValue("@search", search);
                    cnn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = GetStudentsClassFromReader(reader);
                            StudentsList.Add(student);
                        }
                    }
                    SetOrderNumbers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SetOrderNumbers()
        {
            //пронумеровываем
            int num = 0;
            foreach (var student in StudentsList)
            {
                student.OrderNumber = ++num;
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var person = DeportamentsGrid.SelectedItem as StudentsClass;
            if (person == null)
                return;

            try
            {
                using (var cnn = new SqlConnection(_conString))
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Students WHERE Number_Students = @id";
                    cmd.Parameters.AddWithValue("@id", person.NumberStudents);
                    cnn.Open();
                    var deleted = cmd.ExecuteNonQuery();
                    Trace.WriteLine($"Удалено {deleted}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadStudents();
        }


        private void DeportamentsGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Windows.OneStudents OneStudentsObj = new OneStudents((StudentsClass)DeportamentsGrid.SelectedItem);
            OneStudentsObj.Visibility = Visibility.Visible;
            this.Close();
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            var std = DeportamentsGrid.SelectedItem as StudentsClass;
            var AddStudents = new AddStudents(std);
            
            AddStudents.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
