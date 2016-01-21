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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWorkWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class authorizationWindow : Window
    {
        public authorizationWindow()
        {
            InitializeComponent();

            loginComboBox.SelectedIndex = 0;

        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginComboBox.SelectedValue.ToString();
            string password = passwordTextBox.Password;          

            if (AuthorizationDefend.EntranceToSystem(login, password) == false)
            {
                MessageBoxResult result = new MessageBoxResult();
                result=MessageBox.Show("Ошибка авторизации! Неверный ввод пароля.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);

                if (result == MessageBoxResult.OK)
                {
                    loginComboBox.SelectedIndex = 0;
                    passwordTextBox.Clear();
                }
            }
            else
            {
                mainMenuWindow mainMenuWindow = new mainMenuWindow();

                if (loginComboBox.SelectedIndex == 0)
                {
                    mainMenuWindow.Title = "Администратор: Главное меню";
                }
                else
                {
                    mainMenuWindow.Title = "Пользователь: Главное меню";
                }
                
                mainMenuWindow.Show();
                this.Close();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    loginComboBox.ItemsSource = Db.User.Select(u => u.login).ToList();
                }          
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
