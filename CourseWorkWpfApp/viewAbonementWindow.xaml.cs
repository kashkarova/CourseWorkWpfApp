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
    /// Interaction logic for viewAbonementWindow.xaml
    /// </summary>
    public partial class viewAbonementWindow : Window
    {
        public viewAbonementWindow()
        {
            InitializeComponent();

            searchAbonementTextBox.Clear();
            searchAbonementTextBox.Text = "Найти...";        
        }

        public viewAbonementWindow(string mainMenuFormTitle)
        {
            InitializeComponent();

            if (mainMenuFormTitle.Contains("Администратор"))
            {
                AdminMode();
            }
            else
            {
                UserMode();
            }

        }

        private void AdminMode()
        {
            this.Title = "";
            this.Title = "Администратор: Абонементы";
        }

        private void UserMode()
        {
            this.Title = "";
            this.Title = "Пользователь: Абонементы";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          //  try
           // {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.ToList();
                }
          //  }
         //   catch (Exception)
          //  {
              //  MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
          //  }
        }

        private void searchClientSurnameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchServiceTitleCheckBox.IsChecked = false;
            searchServiceTitleCheckBox.IsEnabled = false;
        }

        private void searchClientSurnameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchServiceTitleCheckBox.IsChecked = false;
            searchServiceTitleCheckBox.IsEnabled = true;
        }

        private void searchServiceTitleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchClientSurnameCheckBox.IsChecked = false;
            searchClientSurnameCheckBox.IsEnabled = false;
        }

        private void searchServiceTitleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchClientSurnameCheckBox.IsChecked = false;
            searchClientSurnameCheckBox.IsEnabled = true;
        }

        private void beginDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.Where(a => (a.date_begin == beginDateDatePicker.SelectedDate)).Select(a => a).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void endDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.Where(a => a.date_end == endDateDatePicker.SelectedDate).Select(a => a).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void searchAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            string parameter = searchAbonementTextBox.Text;

            if (searchServiceTitleCheckBox.IsChecked == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        var result = Db.ViewAbonements.Where(a => a.title.Contains(parameter)).Select(a => a);

                        abonementDataGrid.ItemsSource = result.ToList();
                    }
                }
                catch (Exception)
                {
                }
            }
            if (searchClientSurnameCheckBox.IsChecked == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        var result = Db.ViewAbonements.Where(a => a.surname.Contains(parameter)).Select(a => a);

                        abonementDataGrid.ItemsSource = result.ToList();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void searchAbonementTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchAbonementTextBox.Clear();
        }

        private void ascSortingAbonementsButton_Click(object sender, RoutedEventArgs e)
        {
            searchAbonementTextBox.Clear();
            searchAbonementTextBox.Text = "Найти...";

            try
            {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.OrderBy(x => x.surname).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void descSortingAbonementsButton_Click(object sender, RoutedEventArgs e)
        {
            searchAbonementTextBox.Clear();
            searchAbonementTextBox.Text = "Найти...";

            try
            {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.OrderByDescending(x => x.surname).ToList();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveChangesAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            abonementDataGrid.Items.Refresh();

            try
            {
                using (var Db = new DatabaseContext())
                {
                    abonementDataGrid.ItemsSource = Db.ViewAbonements.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void deleteAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            int row = abonementDataGrid.SelectedIndex;
            int id = Convert.ToInt32((abonementDataGrid.Columns[0].GetCellContent(abonementDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.Abonement.Remove(Db.Abonement.FirstOrDefault(c => c.id == id));
                    Db.SaveChanges();
                }

                MessageBox.Show("Запись удалена успешно!", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
