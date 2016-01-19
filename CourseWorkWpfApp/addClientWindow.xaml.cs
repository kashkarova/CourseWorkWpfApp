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
    public partial class addClientWindow : Window
    {
        private bool isAdd = true;
        private Client client_g;

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

        public addClientWindow(Client client)
        {
            InitializeComponent();

            surnameTextBox.Text = client.surname;
            nameTextBox.Text = client.name;
            if (client.sex == 1)
                FemaleRadioButton.IsChecked = true;
            else
                maleRadioButton.IsChecked = true;
            passportTextBox.Text = client.passp_num;
            addressTextBox.Text = client.address;
            telephoneTextBox.Text = client.telephone;

            isAdd = false;
            client_g = client;

            this.Title = "Редактирование клиента";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            if (isAdd == true)
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
            else
            {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            Db.Client.Find(client_g.id).surname = surnameTextBox.Text;
                            Db.Client.Find(client_g.id).name = nameTextBox.Text;
                            Db.Client.Find(client_g.id).sex = (maleRadioButton.IsChecked == true ? 0 : 1);
                            Db.Client.Find(client_g.id).passp_num = passportTextBox.Text;
                            Db.Client.Find(client_g.id).address = addressTextBox.Text;
                            Db.Client.Find(client_g.id).telephone = telephoneTextBox.Text;

                            if (AddDefend.AddClientDefend(Db.Client.Find(client_g.id).surname, Db.Client.Find(client_g.id).name, Db.Client.Find(client_g.id).sex, Db.Client.Find(client_g.id).passp_num, Db.Client.Find(client_g.id).address) == true)
                            {

                                Db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                        MessageBox.Show("Данные о клиенте изменены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
               
                
            }
        }
    }
}
