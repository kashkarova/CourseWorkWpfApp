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
    /// Interaction logic for viewCoachWindow.xaml
    /// </summary>
    public partial class viewCoachWindow : Window
    {
        public viewCoachWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    coachDataGrid.ItemsSource = Db.ViewCoaches.ToList();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ascSortCoachButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    coachDataGrid.ItemsSource = Db.ViewCoaches.OrderBy(x => x.surname).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void descSortCoachButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    coachDataGrid.ItemsSource = Db.ViewCoaches.OrderByDescending(x => x.surname).ToList();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addCoachButton_Click(object sender, RoutedEventArgs e)
        {
            addCoachWindow addCoachWindow = new addCoachWindow();
            addCoachWindow.Show();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            coachDataGrid.Items.Refresh();
        }

        private void editCoachButton_Click(object sender, RoutedEventArgs e)
        {
            Coach coach = new Coach();

            int row = coachDataGrid.SelectedIndex;
            int id = Convert.ToInt32((coachDataGrid.Columns[0].GetCellContent(coachDataGrid.Items[row]) as TextBlock).Text);

            MessageBox.Show(id.ToString());
            

            try
            {
                using (var Db = new DatabaseContext())
                {
                    coach = Db.Coach.FirstOrDefault(c => c.id == id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            addCoachWindow addCoachWindow = new addCoachWindow(coach);
            addCoachWindow.Show();
        }

        private void deleteCoachtButton_Click(object sender, RoutedEventArgs e)
        {
            int row = coachDataGrid.SelectedIndex;
            int id = Convert.ToInt32((coachDataGrid.Columns[0].GetCellContent(coachDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.Coach.Remove(Db.Coach.FirstOrDefault(c => c.id == id));
                    Db.SaveChanges();
                }

                MessageBox.Show("Запись удалена успешно!", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
