using CourseWorkWpfApp.DefendClasses;
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

        private bool isAbonement = true;
        private int abonement_id_g = 0;

        public mainMenuWindow()
        {
            InitializeComponent();

            dateBeginDatePicker.DisplayDateStart = DateTime.Now;
            dateendDatePicker.DisplayDateStart = DateTime.Now;

            roomNumLabel.Width = 0;
            roomNumTextBox.Width = 0;
            coachComboBox.Width = 0;
            coachLabel.Width = 0;

            additionalPaymentTextBox.Text = "0";
            

            InsertToAbonement();
        }

        private void InsertToAbonement()
        {
            isAbonement = true;

            clientComboBox.IsEditable = true;
            clientComboBox.IsEnabled = true;

            serviceTypeComboBox.IsEnabled = false;
            serviceTitleComboBox.IsEnabled = false;
            countTimesServiceComboBox.IsEnabled = false;

            addServiceToAbonementButton.IsEnabled = false;
            deleteServiceFromAbonementButton.IsEnabled = false;
            saveServiceOnAbonementButton.IsEnabled = false;

            servicePositionDataGrid.IsEnabled = false;

            dateendDatePicker.IsEnabled = false;
            additionalPaymentTextBox.IsEnabled = false;
            generalSumTextBox.IsEnabled = false;

            servicePositionDataGrid.Items.Refresh();

        }

        private void InsertToServicePosition()
        {
            isAbonement = false;

            clientComboBox.IsEnabled = false;

            serviceTypeComboBox.IsEnabled = true;
            serviceTitleComboBox.IsEnabled = true;
            countTimesServiceComboBox.IsEnabled = true;

            addServiceToAbonementButton.IsEnabled = true;
            deleteServiceFromAbonementButton.IsEnabled = true;
            saveServiceOnAbonementButton.IsEnabled = true;

            servicePositionDataGrid.IsEnabled = true;

            dateendDatePicker.IsEnabled = true;
            additionalPaymentTextBox.IsEnabled = true;
            generalSumTextBox.IsEnabled = true;
        }

        private void ItemsSourseToTable()
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    servicePositionDataGrid.ItemsSource = Db.ViewServicePosition.Where(sp => sp.abonement_id == abonement_id_g).Select(sp => sp).ToList();
                    servicePositionDataGrid.Items.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupServiceSum()
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    additionalPaymentTextBox.Text = "0";

                    double d = 0;

                    var result = Db.ViewServicePosition.Where(a => a.abonement_id == abonement_id_g).Select(a => a.cost).ToList();

                    foreach (double s in result)
                    {
                        d += s;
                    }

                    generalSumTextBox.Text = d.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PersonalServiceSum()
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    double d = 0;

                    var result = Db.ViewServicePosition.Where(a => a.abonement_id == abonement_id_g).Select(a => a.cost).ToList();

                    foreach (double s in result)
                    {
                        d += s;
                    }

                    double add_p = 0;

                    var add_payment = Db.PersonalServiceInAbonement.Where(ab => ab.abonement == abonement_id_g).Select(ab => ab.additional_payment).ToList();

                    foreach (double add_s in add_payment)
                    {
                        add_p += add_s;
                    }

                    
                    additionalPaymentTextBox.Text = add_p.ToString();

                    double sum = 0;

                    sum = d + add_p;

                    generalSumTextBox.Text = sum.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        #region Modes

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

        #endregion

        #region menu File

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

            InsertToAbonement();
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

        #region menu View

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

        #endregion

        #region menu Settings

        private void menuSettingsAddPost_Click(object sender, RoutedEventArgs e)
        {
            addPostWindow addPostWindow = new addPostWindow();
            addPostWindow.Show();
        }

        private void menuSettingChangeUserIsAdmin_Checked(object sender, RoutedEventArgs e)
        {
            menuSettingChangeUserIsUser.IsChecked = false;

            if (this.IsEnabled == true)
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

        #endregion

        #region menu Help

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

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutAppWindow aboutAppWindow = new AboutAppWindow();
            aboutAppWindow.Show();
        }

        #endregion

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Title.Contains("Администратор") == true)
            {
                menuSettingChangeUserIsAdmin.IsChecked = true;
            }
            else
            {
                menuSettingChangeUserIsUser.IsChecked = true;

                UserMode();
            }
        }

        private void clientComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    clientComboBox.ItemsSource = Db.ClientsNames.Select(n => n.name).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void serviceTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            serviceTypeComboBox.ItemsSource = new List<string>() { "Групповые", "Персональные"};
            serviceTypeComboBox.SelectedIndex = -1;
        }

        private void countTimesServiceComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            countTimesServiceComboBox.ItemsSource = new List<string>() { "1", "8", "12"};
            countTimesServiceComboBox.SelectedIndex = 0;
        }

        private void serviceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            i = serviceTypeComboBox.SelectedIndex;

            switch (i)
            {
                case 0:
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            serviceTitleComboBox.ItemsSource = Db.GroupServicesForAbonement.Select(gs => gs.title).ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    coachComboBox.Width = 0;
                    coachLabel.Width = 0;

                    roomNumLabel.Width = 75;
                    roomNumTextBox.Width = 120;

                    additionalPaymentTextBox.Text = "0";

                    break;

                case 1:
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            serviceTitleComboBox.ItemsSource = Db.PersonalServicesForAbonement.Select(ps => ps.title).ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    roomNumLabel.Width = 0;
                    roomNumTextBox.Width = 0;

                    coachComboBox.Width = 226;
                    coachLabel.Width = 50;

                   
                    break;
            }
        }

        private void serviceTitleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    int id = Db.PersonalServiceCoaches.FirstOrDefault(p => p.title == (string)serviceTitleComboBox.SelectedValue).id;

                    coachComboBox.ItemsSource = Db.PersonalServiceCoaches.Where(c => c.service_id == id).Select(c => c.name).ToList();


                }
            }
            catch (Exception)
            {
               // MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void coachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    int id = Db.PersonalServiceCoaches.FirstOrDefault(p => p.title == (string)serviceTitleComboBox.SelectedValue).id;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addServiceToAbonementButton_Click(sender, e);

            InsertToAbonement();

            dateBeginDatePicker.SelectedDate = null;

            clientComboBox.SelectedIndex = -1;

        }

        private void deleteMain_MenuButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void saveMain_MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (isAbonement == true)
            {
                try
                {
                    if (AddDefend.AddAbonementDefend((string)clientComboBox.SelectedValue, Convert.ToDateTime(dateBeginDatePicker.SelectedDate)) == true)
                    {
                        using (var Db = new DatabaseContext())
                        {
                            Abonement abonement = new Abonement();

                            abonement.client_id=Db.ClientsNames.FirstOrDefault(c=>c.name == (string)clientComboBox.SelectedValue).id;

                            abonement.date_begin = Convert.ToDateTime(dateBeginDatePicker.SelectedDate);

                            Db.Abonement.Add(abonement);
                            Db.SaveChanges();

                            abonement_id_g = 0;

                            abonement_id_g = abonement.id;
                        }

                        isAbonement = false;                  
                        InsertToServicePosition();
                        
                        dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate);
                    }
                    else
                    {
                        MessageBox.Show("Возможно, были введены некорректные данные!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception)
                {
                     MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                }   
            }
            else
            {
                InsertToServicePosition();

                dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate);
            }

            ItemsSourseToTable();
        }

        private void addServiceToAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            serviceTypeComboBox.SelectedIndex = -1;
            countTimesServiceComboBox.SelectedIndex = 0;
            coachComboBox.SelectedIndex = -1;
            serviceTitleComboBox.SelectedIndex = -1;
            roomNumTextBox.Clear();
        }

        private void deleteServiceFromAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            int row = servicePositionDataGrid.SelectedIndex;
            int id = Convert.ToInt32((servicePositionDataGrid.Columns[0].GetCellContent(servicePositionDataGrid.Items[row]) as TextBlock).Text);
            try
            {
                using (var Db = new DatabaseContext())
                {

                    Db.ServicePosition.Remove(Db.ServicePosition.FirstOrDefault(sp => sp.id == id));
                    Db.SaveChanges();
                }

                MessageBox.Show("Запись удалена успешно!", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                ItemsSourseToTable();

                if (serviceTypeComboBox.SelectedIndex == 0) { GroupServiceSum(); }

                if (serviceTypeComboBox.SelectedIndex == 1) { PersonalServiceSum(); }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void saveServiceOnAbonementButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceTypeComboBox.SelectedIndex == 0)
            {
                if(AddDefend.AddServicePositionDefendGroup((string)serviceTypeComboBox.SelectedValue, (string)serviceTitleComboBox.SelectedValue, roomNumTextBox.Text) == true)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            ServicePosition serviceposition = new ServicePosition();

                            serviceposition.abonement_id = abonement_id_g;
                            serviceposition.service_id= Db.GroupServicesForAbonement.FirstOrDefault(gs => gs.title == (string)serviceTitleComboBox.SelectedValue).id;
                            
                            int i=countTimesServiceComboBox.SelectedIndex;

                            switch (i)
                            {
                                case 1:
                                    serviceposition.count = 8;                         

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;

                                case 2:
                                    serviceposition.count = 12;

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;

                                default:
                                    serviceposition.count = 1;

                                   // dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate);

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;
                            }

                            Db.ServicePosition.Add(serviceposition);
                            Db.SaveChanges();

                            additionalPaymentTextBox.Text = "0";

                            GroupServiceSum();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Возможно, были введены некорректные данные!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (serviceTypeComboBox.SelectedIndex == 1)
            {
                if(AddDefend.AddServicePositionDefendPersonal((string)serviceTypeComboBox.SelectedValue, (string)serviceTitleComboBox.SelectedValue, (string)coachComboBox.SelectedValue) == true)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            ServicePosition serviceposition = new ServicePosition();

                            serviceposition.abonement_id = abonement_id_g;
                            serviceposition.service_id = Db.PersonalServicesForAbonement.FirstOrDefault(ps => ps.title == (string)serviceTitleComboBox.SelectedValue).id;

                            int i = countTimesServiceComboBox.SelectedIndex;

                            switch (i)
                            {
                                case 1:
                                    serviceposition.count = 8;

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;

                                case 2:
                                    serviceposition.count = 12;                        

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;

                                default:
                                    serviceposition.count = 1;

                                    serviceposition.date_end = Convert.ToDateTime(dateendDatePicker.SelectedDate);

                                    break;
                            }


                            Db.ServicePosition.Add(serviceposition);
                            Db.SaveChanges();

                            PersonalServiceSum();

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Возможно, были введены некорректные данные!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            ItemsSourseToTable();

        }

        private void countTimesServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = countTimesServiceComboBox.SelectedIndex;

            switch (i)
            {
                case 1:

                    dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate).AddMonths(1);
                    break;

                case 2:

                    dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate).AddMonths(1);
                    break;

                default:

                    dateendDatePicker.SelectedDate = Convert.ToDateTime(dateBeginDatePicker.SelectedDate);

                    break;
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            menuFilePrint_Click(sender, e);
        }
    }
}
