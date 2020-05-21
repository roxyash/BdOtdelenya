using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
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
    /// Логика взаимодействия для OneStudents.xaml
    /// </summary>
    public partial class OneStudents : Window
    {
       
        public OneStudents(StudentsClass student)
        {
            InitializeComponent();
            SetProperties(student);
            ((App)Application.Current).CurrentStudent = student;

        }

        private void SetProperties(StudentsClass student)
        {
            Name.Content = student.LastName + " " + student.FirstName + " " + " " + student.MidName;

            Address.Content = student.Address;
            Course.Content = student.Course;
        }

        public OneStudents()
        {
            InitializeComponent();
            SetProperties(((App)Application.Current).CurrentStudent);
             
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Deportaments DeportamentsObj = new Deportaments();
            DeportamentsObj.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.Progress ProgressObj = new Windows.Progress();
            ProgressObj.Visibility = Visibility.Visible;
            this.Close();
            
        }
    }
}
