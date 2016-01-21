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

        private bool isAdd = true;
        private Coach coach_g;

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

        public addCoachWindow(Coach coach)
        {
            InitializeComponent();

            surnameTextBox.Text = coach.surname;
            nameTextBox.Text = coach.name;
            if (coach.sex == 1)
                femaleRadioButton.IsChecked = true;
            else
                maleRadioButton.IsChecked = true;
            passportTextBox.Text = coach.passp_num;
            addressTextBox.Text = coach.address;
            telephoneTextBox.Text = coach.telephone;

            postComboBox.SelectedIndex = coach.post;

            isAdd = false;
            coach_g = coach;

            this.Title = "Редактирование тренера";
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
            femaleRadioButton.IsChecked = false;
            passportTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
            postComboBox.SelectedIndex = 0;
            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (isAdd == true)
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
                    catch (Exception )
                    {
                          MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        Db.Coach.Find(coach_g.id).surname = surnameTextBox.Text;
                        Db.Coach.Find(coach_g.id).name = nameTextBox.Text;
                        Db.Coach.Find(coach_g.id).sex = (maleRadioButton.IsChecked == true ? 0 : 1);
                        Db.Coach.Find(coach_g.id).passp_num = passportTextBox.Text;
                        Db.Coach.Find(coach_g.id).address = addressTextBox.Text;
                        Db.Coach.Find(coach_g.id).telephone = telephoneTextBox.Text;
                        Db.Coach.Find(coach_g.post).post = Db.Post.FirstOrDefault(p => p.title == (string)postComboBox.SelectedValue).id;

                    if (AddDefend.AddCoachDefend(Db.Coach.Find(coach_g.id).surname, Db.Coach.Find(coach_g.id).name, Db.Coach.Find(coach_g.id).sex, Db.Coach.Find(coach_g.id).passp_num, Db.Coach.Find(coach_g.id).address) == true)
                        {
                            Db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    MessageBox.Show("Данные о тренере изменены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }    
        }
    }
}
