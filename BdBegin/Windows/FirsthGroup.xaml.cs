using BdBegin.Data;
using BdBegin.Models;
using BdBegin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для FirsthGroup.xaml
    /// </summary>
    public partial class FirsthGroup : Window, INotifyPropertyChanged
    {
        private readonly IDataApp _dataApp;
        private readonly string _nameGroup;

        public event PropertyChangedEventHandler PropertyChanged;

        public FirsthGroup(string nameGroup)
        {
            InitializeComponent();
            _dataApp = ((App)Application.Current).DataApp;
            _nameGroup = nameGroup;
            Results = new ObservableCollection<StudentResult>();

            DateFrom.DisplayDateStart = DateTime.Today;
            DateFrom.DisplayDateEnd = DateTime.Today.AddDays(-182);
            DateTo.DisplayDateStart = DateTime.Today;
            DateTo.DisplayDateEnd = DateTime.Today;

            this.DataContext = this;
            LoadStudents();
        }

        private ObservableCollection<StudentResult> _Results;
        public ObservableCollection<StudentResult> Results
        {
            get => _Results;
            set
            { 
                _Results = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Results)));
            }
        }


        private DateTime _From;
        public DateTime From
        {
            get => _From;
            set
            {
                _From = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(From)));
            }
        }

        private DateTime _To;
        public DateTime To
        {
            get => _To;
            set
            {
                _To = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(To)));
            }
        }

        public double GroupFivesProcents => GetFivesProcents();
        public double GroupFourAndFiveProcents => GetFourAndFiveProcents();

        private double GetFourAndFiveProcents()
        {
            double akk = 0;
            foreach (var result in Results)
            {
                akk += result.CountFivesAndFoures;
            }

            return akk / Results.SelectMany(r => r.Progresses).Select(p => p).Count() * 100;
        }

        public double GroupThreesAndFourAndFiveProcents => GetThreesAndFourAndFiveProcents();

        private double GetThreesAndFourAndFiveProcents()
        {
            double akk = 0;
            foreach (var result in Results)
            {
                akk += result.CountThreesAndFouresAndFives;
            }

            return akk / Results.SelectMany(r => r.Progresses).Select(p => p).Count() * 100;
        }

        public double GroupTwoesProcents => GetTwoesProcents();

        private double GetTwoesProcents()
        {
            double akk = 0;
            foreach (var result in Results)
            {
                akk += result.CountTwos;
            }

            return akk / Results.SelectMany(r => r.Progresses).Select(p => p).Count() * 100;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.Groups GroupsObject = new Windows.Groups();
            GroupsObject.Visibility = Visibility.Visible;
            this.Close();

        }
        public void LoadStudents()
        {
            From = DateTime.Today.AddDays(-182);
            To = DateTime.Today;

            List<Student> students = _dataApp.Students.GetByGroup(_nameGroup);
            int num = 0;
            foreach (var student in students)
            {
                var result = new StudentResult();
                result.OrderNumber = ++num;
                result.Student = student;
                result.Progresses = _dataApp.Progress.GetFromToByStudentId(From, To, student.Id);
                Results.Add(result);
            }
        }

        private double GetFivesProcents()
        {
            double akk = 0;
            foreach (var result in Results)
            {
                akk += result.CountFives;
            }

            return akk / Results.SelectMany(r => r.Progresses).Select(p => p).Count() * 100;
        }
    }
}
