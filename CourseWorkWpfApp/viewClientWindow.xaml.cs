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
    /// Interaction logic for viewClientWindow.xaml
    /// </summary>
    public partial class viewClientWindow : Window
    {
        public viewClientWindow()
        {
            InitializeComponent();

            clientDataGrid.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientDataGrid.ItemsSource = Db.Client.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ascSortClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientDataGrid.ItemsSource = Db.Client.OrderBy(x => x.surname).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void descSortClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientDataGrid.ItemsSource = Db.Client.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            clientDataGrid.Items.Refresh();
        }

        private void addClientButton_Click(object sender, RoutedEventArgs e)
        {
            addClientWindow addClientWindow = new addClientWindow();
            addClientWindow.Show();
        }

        private void deleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
