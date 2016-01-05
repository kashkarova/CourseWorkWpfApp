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
    /// Interaction logic for addCoachWindow.xaml
    /// </summary>
    public partial class addCoachWindow : Window
    {

        public addCoachWindow()
        {
            InitializeComponent();

            surnameTextBox.Clear();
            nameTextBox.Clear();
            maleRadioButton.IsChecked = false;
            femaleRadioButton.IsChecked = false;
            passportTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenuWindow mainMenuWindow = new mainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            surnameTextBox.Clear();
            nameTextBox.Clear();
            maleRadioButton.IsChecked = false;
            femaleRadioButton.IsChecked = false;
            passportTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
            postComboBox.SelectedIndex = 0;
            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Coach coach = new Coach();

            coach.surname = surnameTextBox.Text;
            coach.name = nameTextBox.Text;
            coach.sex = (maleRadioButton.IsChecked == true ? 0 : 1);
            coach.passp_num = passportTextBox.Text;
            coach.address = addressTextBox.Text;
            coach.telephone = telephoneTextBox.Text;

            if (AddDefend.AddCoachDefend(coach.surname, coach.name, coach.sex, coach.passp_num, coach.address) == true)
            {
                try
                {
                    using (var DB = new DatabaseContext())
                    {
                        coach.post = DB.Post.FirstOrDefault(p => p.title == (string)postComboBox.SelectedValue).id;
                        DB.Coach.Add(coach);
                        DB.SaveChanges();
                    }

                    MessageBox.Show("Данные о тренере успешно добавлены!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка добавления данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка добавления данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void postComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    postComboBox.ItemsSource = Db.Post.Select(x => x.title).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }    
        }
    }
}
