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

namespace CourseWorkWpfApp
{
    /// <summary>
    /// Interaction logic for viewServiceWindow.xaml
    /// </summary>
    public partial class viewServiceWindow : Window
    {
        public viewServiceWindow()
        {
            InitializeComponent();
            
        }

        private void changeServiceComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            changeServiceComboBox.ItemsSource = new List<string>() { "Групповая", "Персональная" };
            changeServiceComboBox.SelectedIndex = -1;
        }

        private void changeServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var Db = new DatabaseContext())
            {

                serviceDataGrid.ItemsSource = Db.Service.ToList();

                if (changeServiceComboBox.SelectedIndex.Equals(0))
                {
                    changeServiceDataGrid.ItemsSource = Db.ViewGroupService.ToList();
                    changeServiceDataGrid.Items.Refresh();
                }

                if (changeServiceComboBox.SelectedIndex.Equals(1))
                {
                    changeServiceDataGrid.ItemsSource = Db.ViewPersonalService.ToList();
                    changeServiceDataGrid.Items.Refresh();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var Db = new DatabaseContext())
            {
                serviceDataGrid.ItemsSource = Db.Service.ToList();
            }
        }
    }
}
