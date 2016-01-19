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
        }

        private void RefreshClientDataGrid()
        {
            clientDataGrid.Items.Refresh();

            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientDataGrid.ItemsSource = Db.ViewClients.ToList();
                }

                clientDataGrid.Items.Refresh();
            }
            catch (Exception) { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientDataGrid.ItemsSource = Db.ViewClients.ToList();
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
                    clientDataGrid.ItemsSource = Db.ViewClients.OrderBy(x => x.surname).ToList();
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
                    clientDataGrid.ItemsSource = Db.ViewClients.OrderByDescending(x => x.surname).ToList();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshClientDataGrid();
        }

        private void addClientButton_Click(object sender, RoutedEventArgs e)
        {
            addClientWindow addClientWindow = new addClientWindow();
            addClientWindow.Show();
        }

        private void deleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            int row = clientDataGrid.SelectedIndex;
            int id = Convert.ToInt32((clientDataGrid.Columns[0].GetCellContent(clientDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.Client.Remove(Db.Client.FirstOrDefault(c => c.id==id));
                    Db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Client cl = new Client();

            int row = clientDataGrid.SelectedIndex;
            int id = Convert.ToInt32((clientDataGrid.Columns[0].GetCellContent(clientDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {
                    cl = Db.Client.FirstOrDefault(c => c.id == id);
                }
            }
            catch (Exception)
            { 

                MessageBox.Show("Ошибка соединения с базой данных!","Ошибка соединения",MessageBoxButton.OK, MessageBoxImage.Error);
            }

            addClientWindow addClientWindow = new addClientWindow(cl);
            addClientWindow.Show();
        }
    }
}
