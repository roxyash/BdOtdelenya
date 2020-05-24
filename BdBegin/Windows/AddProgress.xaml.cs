using BdBegin.Data;
using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddProgress.xaml
    /// </summary>
    public partial class AddProgress : Window, INotifyPropertyChanged
    {
        private readonly IDataApp _dataApp;
        private readonly int _studentId = ((App)Application.Current).CurrentStudent.Id;
        private readonly Models.Progress _editProgress;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddProgress(Models.Progress editProgress)
        {
            InitializeComponent();
            _dataApp = ((App)Application.Current).DataApp;
            this.DataContext = this;
            _editProgress = editProgress;

            LoadData();

            _dataPicker.DisplayDateStart = DateTime.Today;
            _dataPicker.DisplayDateEnd = DateTime.Today.AddDays(1000);
        }

        private void LoadData()
        {
            List<Discipline> discs = _dataApp.Disciplines.GetAll();
            Disciplines = new ObservableCollection<Discipline>(discs);
            var teachers = _dataApp.Teachers.GetAll();
            Teachers = new ObservableCollection<Teacher>(teachers);
            //если мы редактируем
            if (_editProgress != null)
            {
                SelectedScore = _editProgress.Score;
                SelectedTeacher = _editProgress.Teacher;
                SelectedDiscipline = _editProgress.Discipline;
            }
        }

        public List<int> Scores => new List<int> { 2, 3, 4, 5 };

        private int _SelectedScore;
        public int SelectedScore
        {
            get => _SelectedScore;
            set
            {
                _SelectedScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedScore)));
            }
        }

        public ObservableCollection<Teacher> Teachers { get; set; }

        private Teacher _SelectedTeacher;
        private Discipline selectedDiscipline;

        public Teacher SelectedTeacher
        {
            get => _SelectedTeacher;
            set
            {
                _SelectedTeacher = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTeacher)));
            }
        }

        public ObservableCollection<Discipline> Disciplines { get; set; }
        public Discipline SelectedDiscipline
        { 
            get => selectedDiscipline; 
            set
            {
               selectedDiscipline = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDiscipline)));
            }
        }
                

        public DateTime Date { get; set; } = DateTime.Today;


        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            Windows.Progress ProgressObject = new Windows.Progress();
            ProgressObject.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            if (_editProgress != null)
            {
                _editProgress.Discipline = SelectedDiscipline;
                _editProgress.DisciplineId = SelectedDiscipline.Id;
                _editProgress.Teacher = SelectedTeacher;
                _editProgress.TeacherId = SelectedTeacher.Id;
                _editProgress.Score = SelectedScore;
                _dataApp.Progress.Update(_editProgress);
            }
            else
            {
                _dataApp.Progress.Add(SelectedScore, SelectedDiscipline, SelectedTeacher, Date, _studentId);
            }
            Windows.Progress ProgressObject = new Windows.Progress();
            ProgressObject.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
