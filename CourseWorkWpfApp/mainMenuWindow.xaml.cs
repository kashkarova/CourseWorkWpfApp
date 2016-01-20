using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void UserMode()
        {
            menuAddContract.IsEnabled = false;
            menuAddCoach.IsEnabled = false;
            menuAddService.IsEnabled = false;
            menuSettingChangePassword.IsEnabled = false;
            menuSettingsAddPost.IsEnabled = false;

            menuViewContract.IsEnabled = false;

            menuSettingChangeUserIsAdmin.IsEnabled = false;
            menuSettingChangeUserIsAdmin.IsCheckable = false;
            menuSettingChangeUserIsUser.IsChecked = true;

            this.Title = "";
            this.Title = "Пользователь: Главное меню";

        }

        private void AdminMode()
        {
            menuAddContract.IsEnabled = true;
            menuAddCoach.IsEnabled = true;
            menuAddService.IsEnabled = true;
            menuSettingChangePassword.IsEnabled = true;
            menuSettingsAddPost.IsEnabled = true;

            menuViewContract.IsEnabled = true;

            this.Title = "";
            this.Title = "Администратор: Главное меню";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Title.Contains("Администратор")==true)
            {
                menuSettingChangeUserIsAdmin.IsChecked = true;
            }
            else
            {
                menuSettingChangeUserIsUser.IsChecked = true;

                UserMode();
            }
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

        private void menuFileSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
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
            viewClientWindow viewClientWindow = new viewClientWindow(this.Title);
            viewClientWindow.Show();
        }

        private void menuViewAbonement_Click(object sender, RoutedEventArgs e)
        {
            viewAbonementWindow viewAbonementWindow = new viewAbonementWindow(this.Title);
            viewAbonementWindow.Show();
        }

        private void menuViewService_Click(object sender, RoutedEventArgs e)
        {
            viewServiceWindow viewServiceWindow = new viewServiceWindow(this.Title);
            viewServiceWindow.Show();
        }

        private void menuViewCoach_Click(object sender, RoutedEventArgs e)
        {
            viewCoachWindow viewCoachWindow = new viewCoachWindow(this.Title);
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
           
        }

       

        private void deleteMain_MenuButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void menuSettingsAddPost_Click(object sender, RoutedEventArgs e)
        {
            addPostWindow addPostWindow = new addPostWindow();
            addPostWindow.Show();
        }

        private void menuHelpSpravkaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "Help.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveMain_MenuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void menuSettingChangeUserIsAdmin_Checked(object sender, RoutedEventArgs e)
        {
            menuSettingChangeUserIsUser.IsChecked = false;

            if(this.IsEnabled==true)
                AdminMode();
        }

        private void menuSettingChangeUserIsAdmin_Unchecked(object sender, RoutedEventArgs e)
        {
            menuSettingChangeUserIsUser.IsChecked = true;
            
            UserMode();
        }

        private void menuSettingChangeUserIsUser_Checked(object sender, RoutedEventArgs e)
        {
            menuSettingChangeUserIsAdmin.IsChecked = false;

            UserMode();
        }

        private void menuSettingChangeUserIsUser_Unchecked(object sender, RoutedEventArgs e)
        {
            UserMode();
        }

        private void menuSettingChangePassword_Click(object sender, RoutedEventArgs e)
        {
            changePasswordWindow changePasswordWindow = new changePasswordWindow();
            changePasswordWindow.Show();    
        }
    }
}
