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
        private bool isAdd = true;
        private Service service_g;

        private GroupService gr_service_g;
        private PersonalService pr_service_g;
        public addServiceWindow()
        {
            InitializeComponent();

            additionalPaymentLabel.Height = 0;
            additionalPaymentTextBox.Height = 0;

            roomNumLabel.Height = 0;
            roomNumTextBox.Height = 0;
        }

        public addServiceWindow(Service service, GroupService gr_service)
        {
            InitializeComponent();

            titleTextBox.Text = service.title;
            descriptionTextBox.Text = service.description;
            priceTextBox.Text = service.price.ToString();
            roomNumTextBox.Text = gr_service.room_num.ToString();

            typeServiceComboBox.SelectedIndex = 0;

            isAdd = false;
            service_g = service;
            gr_service_g = gr_service;
            this.Title = "Редактирование услуги";

            MessageBox.Show(service_g.title);
        }

        public addServiceWindow(Service service, PersonalService pers_service)
        {
            InitializeComponent();

            titleTextBox.Text = service.title;
            descriptionTextBox.Text = service.description;
            priceTextBox.Text = service.price.ToString();

            typeServiceComboBox.SelectedIndex = 1;

           // roomNumLabel.Width = 0;
          //  roomNumTextBox.Width = 0;

            additionalPaymentTextBox.Text = pers_service.additional_payment.ToString();

            isAdd = false;
            service_g = service;
            pr_service_g = pers_service;
            this.Title = "Редактирование услуги";

            MessageBox.Show(service_g.title);
        }

        private void typeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            typeServiceComboBox.ItemsSource = new List<string>() { "Групповая", "Персональная" };
           // typeServiceComboBox.SelectedIndex = 0;
        }

        private void typeServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeServiceComboBox.SelectedIndex.Equals(0))
            {
                roomNumLabel.Height = 25;
                roomNumTextBox.Height = 23;
                additionalPaymentLabel.Height = 0;
                additionalPaymentTextBox.Height = 0;

              //  addButton_Click(sender, e);
            }
            else
            {
                additionalPaymentLabel.Height = 25;
                additionalPaymentTextBox.Height = 23;
                roomNumLabel.Height = 0;
                roomNumTextBox.Height = 0;

              //  addButton_Click(sender, e);
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
            if (isAdd == true)
            {
                Service service = new Service();

                if (typeServiceComboBox.SelectedIndex.Equals(0))
                {
                    GroupService groupService = new GroupService();


                    if (AddDefend.AddGroupService(titleTextBox.Text, priceTextBox.Text, roomNumTextBox.Text) == true)
                    {
                        service.title = titleTextBox.Text;
                        service.description = descriptionTextBox.Text;
                        service.price = Convert.ToDouble(priceTextBox.Text);
                        groupService.room_num = Convert.ToInt32(roomNumTextBox.Text);
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


                    if (AddDefend.AddPersonalServiceDefend(titleTextBox.Text, priceTextBox.Text, additionalPaymentTextBox.Text) == true)
                    {
                        service.title = titleTextBox.Text;
                        service.description = descriptionTextBox.Text;
                        service.price = Convert.ToDouble(priceTextBox.Text);
                        personalService.additional_payment = Convert.ToDouble(additionalPaymentTextBox.Text);

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
            else
            {
                if (gr_service_g == null)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            Db.Service.Find(service_g.id).title = titleTextBox.Text;
                            Db.Service.Find(service_g.id).description = descriptionTextBox.Text;
                            MessageBox.Show("trololo personal service");

                            if (AddDefend.AddPersonalServiceDefend(titleTextBox.Text, priceTextBox.Text, additionalPaymentTextBox.Text) == true)
                            {
                                Db.Service.Find(service_g.id).price = Convert.ToDouble(priceTextBox.Text);
                                Db.PersonalService.Find(service_g.id).additional_payment = Convert.ToDouble(additionalPaymentTextBox.Text);

                                Db.SaveChanges();

                                MessageBox.Show("Данные об услуге изменены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            else
                            {
                                MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            Db.Service.Find(service_g.id).title = titleTextBox.Text;
                            Db.Service.Find(service_g.id).description = descriptionTextBox.Text;
                            MessageBox.Show("trololo group service");

                            if (AddDefend.AddGroupService(titleTextBox.Text, priceTextBox.Text, roomNumTextBox.Text) == true)
                            {
                                Db.Service.Find(service_g.id).price = Convert.ToDouble(priceTextBox.Text);
                                Db.GroupService.Find(service_g.id).room_num = Convert.ToInt32(roomNumTextBox.Text);

                                Db.SaveChanges();
                                MessageBox.Show("Данные об услуге изменены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            else
                            {
                                MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }      
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
