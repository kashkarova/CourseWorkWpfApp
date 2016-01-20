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
        private bool isAdd = true;
        private Contract contract_g;

        public addContractWindow()
        {
            InitializeComponent();

            
        }

        public addContractWindow(Contract contract)
        {
            InitializeComponent();

            isAdd = false;
            contract_g = contract;

            this.Title = "Редактирование контракта";
        }

        private void coachComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    coachComboBox.ItemsSource = Db.CoachesNamesWithContract.Select(i => i.name).ToList();
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
                    int i= Db.CoachesNamesWithContract.FirstOrDefault(n =>n.name == (string)coachComboBox.SelectedValue).id;

                    var result = Db.CoachesNamesWithContract.Where(x => x.id == i).Select(x => x.title).ToList<string>();

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
                        titleServiceComboBox.ItemsSource = Db.ViewGroupServices.Select(x => x.title).ToList();
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
                        titleServiceComboBox.ItemsSource = Db.ViewPersonalServices.Select(x => x.title).ToList();
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
            if (isAdd == true)
            {
                Contract contract = new Contract();

                

                if (AddDefend.AddContract(salaryTextBox.Text) == true)
                {
                    contract.salary = Convert.ToDouble(salaryTextBox.Text);

                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            contract.coach_id = Db.CoachesNamesWithContract.FirstOrDefault(n => n.name == (string)coachComboBox.SelectedValue).id;

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
            else
            {
                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        Db.Contract.Find(contract_g.id).coach_id = Db.CoachesNamesWithContract.FirstOrDefault(p => p.name == (string)coachComboBox.SelectedValue).id;
                        Db.Contract.Find(contract_g.id).service_id = Db.Service.FirstOrDefault(s => s.title == (string)titleServiceComboBox.SelectedValue).id;
                        Db.Contract.Find(contract_g.id).salary = Convert.ToDouble(salaryTextBox.Text);
                        

                        if (AddDefend.AddContract((Db.Contract.Find(contract_g.id).salary).ToString()) == true)
                        {
                            Db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    MessageBox.Show("Данные о контракте изменены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }          
        }

        private void cancelContractButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
