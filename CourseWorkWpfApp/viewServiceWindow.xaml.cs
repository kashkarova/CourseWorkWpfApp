using CourseWorkWpfApp.DefendClasses;
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

            searchToolsLabel.Width = 0;
            searchTitleCheckBox.Width = 0;
            searchPriceCheckBox.Width = 0;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var Db = new DatabaseContext())
            {
                serviceDataGrid.ItemsSource = Db.Service.ToList();
            }
        }

        private void searchServiceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchServiceTextBox.Clear();
            searchToolsLabel.Width = 126;
            searchTitleCheckBox.Width = 73;
            searchPriceCheckBox.Width = 48;
        }

        private void searchServiceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void viewServiceComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            viewServiceComboBox.ItemsSource = new List<string>() { "Групповые", "Персональные", "Все" };
            viewServiceComboBox.SelectedIndex = 2;
        }

        private void viewServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            i = viewServiceComboBox.SelectedIndex;

            switch (i)
            {
                case 0:
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            serviceDataGrid.ItemsSource = Db.ViewGroupServices.ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с  базой данных!","", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case 1:
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            serviceDataGrid.ItemsSource = Db.ViewPersonalServices.ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с  базой данных!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                default:
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            serviceDataGrid.ItemsSource = Db.ViewServices.ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с  базой данных!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
            }
        }

        private void addServiceButton_Click(object sender, RoutedEventArgs e)
        {
            addServiceWindow addServiceWindow = new addServiceWindow();
            addServiceWindow.Show();
        }

        private void editServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            PersonalService pr_service = new PersonalService();
            GroupService gr_service = new GroupService();

            int row = serviceDataGrid.SelectedIndex;
            int id = Convert.ToInt32((serviceDataGrid.Columns[0].GetCellContent(serviceDataGrid.Items[row]) as TextBlock).Text);

            int group_id = 0;
            int personal_id = 0;

            addServiceWindow addServiceWindow;

            try
            {
                using (var Db = new DatabaseContext())
                {
                    service = Db.Service.FirstOrDefault(c => c.id == id);
                    try { group_id = Db.GroupService.Find(service.id).service_id; } catch { group_id = 0; }

                try { personal_id = Db.PersonalService.Find(service.id).service_id; } catch { personal_id = 0; }

                    if (group_id == 0)
                    {
                        pr_service = Db.PersonalService.FirstOrDefault(s => s.service_id == id);

                        addServiceWindow = new addServiceWindow(service, pr_service);
                        addServiceWindow.Show();
                    }
                    if (personal_id == 0)
                    {
                        gr_service = Db.GroupService.FirstOrDefault(s => s.service_id == id);

                        addServiceWindow = new addServiceWindow(service, gr_service);
                        addServiceWindow.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
            
        }

        private void saveServiceButton_Click(object sender, RoutedEventArgs e)
        {
            serviceDataGrid.Items.Refresh();
            viewServiceComboBox.SelectedIndex = 0;
            try
            {
                using (var Db = new DatabaseContext())
                {
                    serviceDataGrid.ItemsSource = Db.ViewServices.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            int row = serviceDataGrid.SelectedIndex;
            int id = Convert.ToInt32((serviceDataGrid.Columns[0].GetCellContent(serviceDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.Service.Remove(Db.Service.FirstOrDefault(c => c.id == id));
                    Db.SaveChanges();
                }

                MessageBox.Show("Запись удалена успешно!", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void searchServiceButton_Click(object sender, RoutedEventArgs e)
        {
            searchToolsLabel.Width = 126;
            searchTitleCheckBox.Width = 73;
            searchPriceCheckBox.Width = 48;

            string parameter = searchServiceTextBox.Text;

            if (searchTitleCheckBox.IsChecked == true)
            {

                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        var result = Db.ViewServices.Where(s => s.title.Contains(parameter)).Select(s => s);

                        if (result.Equals(null))
                        {
                            MessageBox.Show("По вашему запросу ничего не найдено!", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            serviceDataGrid.ItemsSource = result.ToList();
                            viewServiceComboBox.SelectedIndex = 2;
                        }

                    }
                }
                catch (Exception)
                {

                }
            }
            if (searchPriceCheckBox.IsChecked == true)
            {
                if (AddDefend.PriceParameter(parameter) == true)
                {
                    try
                    {

                        using (var Db = new DatabaseContext())
                        {
                            double i = Convert.ToDouble(parameter);

                            MessageBox.Show(i.ToString());

                            var result = Db.ViewServices.Where(s => s.Price == i).Select(s => s);

                            if (result.Equals(null))
                            {
                                MessageBox.Show("По вашему запросу ничего не найдено!", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                serviceDataGrid.ItemsSource = result.ToList();
                                viewServiceComboBox.SelectedIndex = 2;
                            }

                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Некорректный параметр поиска!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    searchServiceTextBox.Clear();
                }                      
            }
        }

        private void searchTitleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchPriceCheckBox.IsChecked = false;
            searchPriceCheckBox.IsEnabled = false;
        }

        private void searchPriceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchTitleCheckBox.IsChecked = false;
            searchTitleCheckBox.IsEnabled = false;
        }

        private void searchTitleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchPriceCheckBox.IsChecked = false;
            searchPriceCheckBox.IsEnabled = true;


            viewServiceComboBox_Loaded(sender, e);

            searchServiceTextBox.Clear();
            searchServiceTextBox.Text = "Найти...";
        }

        private void searchPriceCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchTitleCheckBox.IsChecked = false;
            searchTitleCheckBox.IsEnabled = true;

            viewServiceComboBox_Loaded(sender, e);

            searchServiceTextBox.Clear();
            searchServiceTextBox.Text = "Найти...";
        }
    }
}
