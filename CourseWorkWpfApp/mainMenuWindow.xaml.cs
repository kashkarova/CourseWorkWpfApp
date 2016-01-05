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
    /// Interaction logic for mainMenuWindow1.xaml
    /// </summary>
    public partial class mainMenuWindow : Window
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

        public mainMenuWindow()
        {
            InitializeComponent();
        }

        private void menuAddClient_Click(object sender, RoutedEventArgs e)
        {
            addClientWindow addClientWindow = new addClientWindow();
            addClientWindow.Show();
            this.Close();
        }

        private void menuAddCoach_Click(object sender, RoutedEventArgs e)
        {
            addCoachWindow addCoachWindow = new addCoachWindow();
            addCoachWindow.Show();
            this.Close();
        }

        private void menuAddService_Click(object sender, RoutedEventArgs e)
        {
            addServiceWindow addServiceWindow = new addServiceWindow();
            addServiceWindow.Show();
            this.Close();
        }

        private void menuViewClient_Click(object sender, RoutedEventArgs e)
        {
            viewClientWindow viewClientWindow = new viewClientWindow();
            viewClientWindow.Show();
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

        private void menuFileExit_Click(object sender, RoutedEventArgs e)
        {
            menuExit_Click(sender, e);
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
    }
}
