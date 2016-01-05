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
    /// Interaction logic for registrationWindow.xaml
    /// </summary>
    public partial class registrationWindow : Window
    {
        public registrationWindow()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            loginTextBox.Clear();
            passwordTextBox.Clear();
            repeatPasswordTextBox.Clear();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            clearButton_Click(sender, e);
            authorizationWindow authWindow = new authorizationWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
