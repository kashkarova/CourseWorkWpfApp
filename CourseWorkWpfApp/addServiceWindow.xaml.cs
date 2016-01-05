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
    /// Interaction logic for addServiceWindow.xaml
    /// </summary>
    public partial class addServiceWindow : Window
    {
        public addServiceWindow()
        {
            InitializeComponent();
        }

        private void typeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            typeServiceComboBox.ItemsSource = new List<string>() { "Групповая", "Персональная" };
            typeServiceComboBox.SelectedIndex = 0;
        }

        private void typeServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeServiceComboBox.SelectedIndex.Equals(0))
            {
                roomNumLabel.Height = 25;
                roomNumTextBox.Height = 23;
                additionalPaymentLabel.Height = 0;
                additionalPaymentTextBox.Height = 0;

                addButton_Click(sender, e);
            }
            else
            {
                additionalPaymentLabel.Height = 25;
                additionalPaymentTextBox.Height = 23;
                roomNumLabel.Height = 0;
                roomNumTextBox.Height = 0;

                addButton_Click(sender, e);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            titleTextBox.Clear();
            descriptionTextBox.Clear();
            priceTextBox.Clear();
            additionalPaymentTextBox.Clear();
            roomNumTextBox.Clear();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            service.title = titleTextBox.Text;
            service.description = descriptionTextBox.Text;
            service.price = Convert.ToDouble(priceTextBox.Text);

            if (typeServiceComboBox.SelectedIndex.Equals(0))
            {
                GroupService groupService = new GroupService();
                groupService.room_num = Convert.ToInt32(roomNumTextBox.Text);

                if (AddDefend.AddGroupService(service.title, service.price, groupService.room_num) == true)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            groupService.service_id = service.id;

                            Db.Service.Add(service);
                            Db.GroupService.Add(groupService);
                            Db.SaveChanges();
                        }

                        MessageBox.Show("Данные об услуге добавлены успешно!", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                    addButton_Click(sender, e);
                }

            }
            else
            {
                PersonalService personalService = new PersonalService();
                personalService.additional_payment = Convert.ToDouble(additionalPaymentTextBox.Text);

                if (AddDefend.AddPersonalServiceDefend(service.title, service.price, personalService.additional_payment) == true)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            personalService.service_id = service.id;

                            Db.Service.Add(service);
                            Db.PersonalService.Add(personalService);
                            Db.SaveChanges();
                        }

                        MessageBox.Show("Данные об услуге добавлены успешно!", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                    addButton_Click(sender, e);
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenuWindow mainMenuWindow = new mainMenuWindow();
            mainMenuWindow.Show();

            this.Close();
        }
    }
}
