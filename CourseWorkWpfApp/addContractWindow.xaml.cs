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
    /// Interaction logic for addContractWindow.xaml
    /// </summary>
    public partial class addContractWindow : Window
    {
        public addContractWindow()
        {
            InitializeComponent();
        }

        private void coachComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    coachComboBox.ItemsSource = Db.CoachesNames.Select(i => i.name).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void coachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    int i= Db.CoachesNames.FirstOrDefault(n =>n.name == (string)coachComboBox.SelectedValue).id;

                    var result = Db.CoachesNames.Where(x => x.id == i).Select(x => x.title).ToList<string>();

                    foreach (string s in result)
                    {
                        postTextBox.Text = s;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void typeServiceComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            typeServiceComboBox.ItemsSource = new List<string>() { "Групповая", "Персональная" };
            typeServiceComboBox.SelectedIndex = -1;
        }

        private void typeServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeServiceComboBox.SelectedIndex.Equals(0))
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        titleServiceComboBox.ItemsSource = Db.ViewGroupService.Select(x => x.title).ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        titleServiceComboBox.ItemsSource = Db.ViewPersonalService.Select(x => x.title).ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addContractButton_Click(object sender, RoutedEventArgs e)
        {
            postTextBox.Clear();
            salaryTextBox.Clear();
            typeServiceComboBox.SelectedIndex = -1;
        }

        private void saveContractButton_Click(object sender, RoutedEventArgs e)
        {
            Contract contract = new Contract();

            contract.salary = Convert.ToDouble(salaryTextBox.Text);

            if (AddDefend.AddContract(contract.salary) == true)
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        contract.coach_id = Db.CoachesNames.FirstOrDefault(n => n.name == (string)coachComboBox.SelectedValue).id;

                        contract.service_id = Db.Service.FirstOrDefault(n => n.title == (string)titleServiceComboBox.SelectedValue).id;

                        Db.Contract.Add(contract);
                        Db.SaveChanges();

                        MessageBox.Show("Данные о контракте добавлены успешно!", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Возможно, были введены некорректные данные! Поробуйте ещё раз.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                addContractButton_Click(sender, e);
            }
            
        }
    }
}
