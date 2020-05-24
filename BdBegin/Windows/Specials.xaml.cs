using BdBegin.Data;
using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Specialization> _specializations = new ObservableCollection<Specialization>();
        private IDataApp dataApp = ((App)Application.Current).DataApp;
        public Specials()
        {
            InitializeComponent();
            LoadDataGridSpecials();
        }
        public void LoadDataGridSpecials()
        {
            List<Specialization> specializations = dataApp.Specializations.GetAll();
            specializations.ForEach(_specializations.Add);
            SpecialsGrid.ItemsSource = _specializations;
        }
        private void AddSpecial(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeSpecial(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveSpecial(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Windows.dataBase databaseObject = new Windows.dataBase();
            databaseObject.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
