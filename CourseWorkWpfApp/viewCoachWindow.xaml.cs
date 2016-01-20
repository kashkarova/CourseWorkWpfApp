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

            searchToolsLabel.Width = 0;
            searchSurnameCheckBox.Width = 0;
            searchPostCheckBox.Width = 0;
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
            searchCoachTextBox.Clear();
            searchCoachTextBox.Text = "Найти...";

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
            searchCoachTextBox.Clear();
            searchCoachTextBox.Text = "Найти...";

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

            //MessageBox.Show(id.ToString());
            

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

        private void searchCoachTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchCoachTextBox.Clear();

            searchToolsLabel.Width = 126;
            searchSurnameCheckBox.Width = 70;
            searchPostCheckBox.Width = 81;
        }

        private void searchSurnameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchPostCheckBox.IsChecked = false;
            searchPostCheckBox.IsEnabled = false;
        }

        private void searchSurnameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchPostCheckBox.IsChecked = false;
            searchPostCheckBox.IsEnabled = true;
        }

        private void searchPostCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchSurnameCheckBox.IsChecked = false;
            searchSurnameCheckBox.IsEnabled = false;
        }

        private void searchPostCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchSurnameCheckBox.IsChecked = false;
            searchSurnameCheckBox.IsEnabled = true;
        }

        private void searchCoachButton_Click(object sender, RoutedEventArgs e)
        {
            string parameter = searchCoachTextBox.Text;

            if (searchSurnameCheckBox.IsChecked == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        var result = Db.ViewCoaches.Where(c => c.surname.Contains(parameter)).Select(c => c);

                        coachDataGrid.ItemsSource = result.ToList();
                    }
                }
                catch (Exception)
                {

                }
            }

            if (searchPostCheckBox.IsChecked == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        var result = Db.ViewCoaches.Where(c => c.title.Contains(parameter)).Select(c => c);

                        coachDataGrid.ItemsSource = result.ToList();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
