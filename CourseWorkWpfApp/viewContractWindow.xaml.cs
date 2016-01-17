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
    /// Interaction logic for viewContractWindow.xaml
    /// </summary>
    public partial class viewContractWindow : Window
    {
        public viewContractWindow()
        {
            InitializeComponent();
            
        }

        private void coachComboBox_Loaded(object sender, RoutedEventArgs e)
        {

          //  try
           // {
                using (var Db = new DatabaseContext())
                {
                    coachComboBox.ItemsSource = Db.CoachesNames.Select(i => i.name).ToList();
                }
         //   }
         //   catch (Exception)
          //  {
          //      MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
          //  }
        }

        private void coachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double minSalary = 1378;

            minSalaryTextBox.Text = minSalary.ToString();

            double payment_sum = 0;

            double additionalPayment_sum = 0;

            double resultSalary = 0;

            try
            {
                using (var Db = new DatabaseContext())
                {
                    int i = Db.CoachesNames.FirstOrDefault(n => n.name == (string)coachComboBox.SelectedValue).id;

                    var result = Db.ViewContractWithAddPayment.Where(x => x.coach_id == i).Select(x => x).ToList();
                
                    contractDataGrid.ItemsSource = result;

                    var payment = Db.ViewContractWithAddPayment.Where(x => x.coach_id == i).Select(x => x.payment).ToList();                  

                    foreach (double p in payment)
                    {
                        payment_sum += p;
                    }

                    var additionalPayment = Db.ViewContractWithAddPayment.Where(j => j.coach_id == i && j.additional_payment != null).Select(j => j.additional_payment).ToList();

                    foreach (double r in additionalPayment)
                    {
                        additionalPayment_sum += r;
                    }

                    sumServicePaymentTextBox.Text = payment_sum.ToString()+"+"+ additionalPayment_sum.ToString();

                }

                resultSalary = Convert.ToDouble(minSalaryTextBox.Text) +payment_sum+additionalPayment_sum;

                salaryTextBox.Text = resultSalary.ToString();

                
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ascSortContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    int i = Db.CoachesNames.FirstOrDefault(n => n.name == (string)coachComboBox.SelectedValue).id;

                    var result = Db.ViewContractWithAddPayment.Where(x => x.coach_id == i).OrderBy(x=>x.title).Select(x => x).ToList();

                    contractDataGrid.ItemsSource = result;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void descSortContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    int i = Db.CoachesNames.FirstOrDefault(n => n.name == (string)coachComboBox.SelectedValue).id;

                    var result = Db.ViewContractWithAddPayment.Where(x => x.coach_id == i).OrderByDescending(x => x.title).Select(x => x).ToList();

                    contractDataGrid.ItemsSource = result;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
