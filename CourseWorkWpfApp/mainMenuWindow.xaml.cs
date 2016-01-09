using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Interaction logic for mainMenuWindow1.xaml
    /// </summary>
    public partial class mainMenuWindow : Window
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

        public mainMenuWindow()
        {
            InitializeComponent();
            dateBeginDatePicker.DisplayDateStart = DateTime.Now;
        }

        #region File

        private void menuAddClient_Click(object sender, RoutedEventArgs e)
        {
            addClientWindow addClientWindow = new addClientWindow();
            addClientWindow.Show();
        }

        private void menuAddCoach_Click(object sender, RoutedEventArgs e)
        {
            addCoachWindow addCoachWindow = new addCoachWindow();
            addCoachWindow.Show();
        }

        private void menuAddService_Click(object sender, RoutedEventArgs e)
        {
            addServiceWindow addServiceWindow = new addServiceWindow();
            addServiceWindow.Show();
        }

        private void menuAddContract_Click(object sender, RoutedEventArgs e)
        {
            addContractWindow addContractWindow = new addContractWindow();
            addContractWindow.Show();
        }

        private void menuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "Файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка чтения из файла!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void menuFilePrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PageRangeSelection = PageRangeSelection.AllPages;
            printDialog.UserPageRangeEnabled = true;
            bool? doPrint = printDialog.ShowDialog();
            if (doPrint != true)
            {
                return;
            }
        }

        private void menuFileExit_Click(object sender, RoutedEventArgs e)
        {
            menuExit_Click(sender, e);
        }

        #endregion

        private void menuViewClient_Click(object sender, RoutedEventArgs e)
        {
            viewClientWindow viewClientWindow = new viewClientWindow();
            viewClientWindow.Show();
        }

        private void menuViewAbonement_Click(object sender, RoutedEventArgs e)
        {
            viewAbonementWindow viewAbonementWindow = new viewAbonementWindow();
            viewAbonementWindow.Show();
        }

        private void menuViewService_Click(object sender, RoutedEventArgs e)
        {
            viewServiceWindow viewServiceWindow = new viewServiceWindow();
            viewServiceWindow.Show();
        }

        private void menuViewCoach_Click(object sender, RoutedEventArgs e)
        {
            viewCoachWindow viewCoachWindow = new viewCoachWindow();
            viewCoachWindow.Show();
        }

        private void menuViewContract_Click(object sender, RoutedEventArgs e)
        {
            viewContractWindow viewContractWindow = new viewContractWindow();
            viewContractWindow.Show();
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutAppWindow aboutAppWindow = new AboutAppWindow();
            aboutAppWindow.Show();
        }



        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            clientComboBox.SelectedIndex = -1;
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = new MessageBoxResult();
            result = MessageBox.Show("Вы уверены, что хотите выйти из системы?", "Выход из системы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                authorizationWindow authorizationWindow = new authorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }

        private void clientComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientComboBox.ItemsSource = Db.ClientsNames.Select(x => x.name).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                using (var Db = new DatabaseContext())
                {
                    int i = Db.ClientsNames.FirstOrDefault(n => n.name == (string)clientComboBox.SelectedValue).id;

                    var result = Db.CurrServicePositionId.Where(x => x.client_id == i && x.sP_id != null).Select(y => y.sP_id).ToList();

                    int id = 0;
                    string date_begin="";

                    foreach (int temp_id in result)
                    {
                        id = temp_id;
                    }

                    var dateBegin_result = Db.ViewAbonements.Where(x => x.id == i && x.date_begin != null).Select(x => x.date_begin).ToList();

                    bool flag = true;

                    foreach (DateTime date in dateBegin_result)
                    {
                        date_begin = date.ToString();

                        if (date < DateTime.Now)
                        {
                            flag = false;
                        }
                    }

                    dateBeginDatePicker.IsEnabled = flag;

                    dateBeginDatePicker.Text = date_begin;         

                    servicePositionDataGrid.ItemsSource = Db.ViewServicePosition.Where(j => j.id == id).Select(j => j).ToList();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
