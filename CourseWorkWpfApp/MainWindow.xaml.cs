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
        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Password;

            if (AuthorizationDefend.EntranceToSystem(login, password) == false)
            {
                MessageBoxResult result = new MessageBoxResult();
                result=MessageBox.Show("Ошибка авторизации! Неверный ввод логина и/или пароля.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);

                if (result == MessageBoxResult.OK)
                {
                    loginTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }
            else
            {
                mainMenuWindow mainMenuWindow = new mainMenuWindow();
                mainMenuWindow.Show();
                this.Close();
            }
        }

        private void registerReference_Click(object sender, RoutedEventArgs e)
        {
            registrationWindow registrWindow = new registrationWindow();
            registrWindow.Show();
            this.Close();
        }
    }
}
