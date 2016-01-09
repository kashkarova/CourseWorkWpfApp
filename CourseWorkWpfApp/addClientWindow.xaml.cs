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
    /// Interaction logic for addClientWindow.xaml
    /// </summary>
    public partial class addClientWindow : Window
    {
        public addClientWindow()
        {
            InitializeComponent();
            surnameTextBox.Clear();
            nameTextBox.Clear();
            maleRadioButton.IsChecked = false;
            FemaleRadioButton.IsChecked = false;
            passportTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            surnameTextBox.Clear();
            nameTextBox.Clear();
            maleRadioButton.IsChecked = false;
            FemaleRadioButton.IsChecked = false;
            passportTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();         

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();

            client.surname = surnameTextBox.Text;
            client.name = nameTextBox.Text;
            client.sex = (maleRadioButton.IsChecked == true ? 0 : 1);
            client.passp_num = passportTextBox.Text;
            client.address = addressTextBox.Text;
            client.telephone = telephoneTextBox.Text;

            if (AddDefend.AddClientDefend(client.surname, client.name, client.sex, client.passp_num, client.address) == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        Db.Client.Add(client);
                        Db.SaveChanges();
                    }

                    MessageBox.Show("Данные о клиенте успешно добавлены!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка добавления данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
