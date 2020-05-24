using BdBegin.Data;
using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        private readonly IDataApp _dataApp;
        private const string _conString = @"Data Source=DESKTOP-TAH07PT; Initial Catalog=Karataev; Integrated Security=True";
        public Progress()
        {
            InitializeComponent();


            _dataApp = ((App)Application.Current).DataApp;
            this.DataContext = this;
            LoadProgress();
        }

        public ObservableCollection<Models.Progress> Progresses { get; set; }

        public Models.Progress SelectedProgress { get; set; }

        private void LoadProgress()
        {
            List<Models.Progress> progresses = _dataApp.Progress.GetAllByStudentId(((App)Application.Current).CurrentStudent.Id);
            Progresses = new ObservableCollection<Models.Progress>(progresses);
        }

        private void ButtonRemove(object sender, RoutedEventArgs e)
        {
            var progress = ProgressGrid.SelectedItem as Models.Progress;
            if (progress == null)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            _dataApp.Progress.Remove(progress.Id);
            Progresses.Remove(progress);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //this.Close();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.OneStudents oneStudentsObject = new Windows.OneStudents();
            oneStudentsObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This funtion not work now");
        }

        private void EmailButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This function not work now");
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            Windows.AddProgress AddProgressObject = new Windows.AddProgress(null);
            AddProgressObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ChangeButton(object sender, RoutedEventArgs e)
        {
            Windows.AddProgress AddProgressObject = new Windows.AddProgress(SelectedProgress);
            AddProgressObject.Visibility = Visibility.Visible;
            this.Close();
        }
        //private void LoadProgress()
        //{
        //    using (var cnn = new SqlConnection(_conString))
        //    using (var cmd = cnn.CreateCommand())
        //    {
        //        cmd.CommandText = @"SELECT [Number_Students]
        //                                     , [First_Name_Students]
        //                                     , [Mid_Name_Students]
        //                                     , [Last_Name_Students]
        //                                     , [Address_Students]
        //                                     , [Course_Students]
        //                                     , [Birthday_Students]
        //                                FROM Students;";
        //        cnn.Open();
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var student = GetStudentsClassFromReader(reader);
        //                StudentsList.Add(student);
        //                _tempStudents.Add(student);
        //            }
        //        }

        //        SetOrderNumbers();
        //    }
        //}
    }
}
