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
    /// Interaction logic for addPostWindow.xaml
    /// </summary>
    public partial class addPostWindow : Window
    {       
        private bool isAdd = true;

        public addPostWindow()
        {
            InitializeComponent();
        }

        private void RefreshPostDataGrid()
        {
            postDataGrid.Items.Refresh();

            try
            {
                using (var Db = new DatabaseContext())
                {
                    postDataGrid.ItemsSource = Db.Post.ToList();
                }

                postDataGrid.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var Db = new DatabaseContext())
                {
                    postDataGrid.ItemsSource = Db.Post.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addPostButton_Click(object sender, RoutedEventArgs e)
        {
            postTitleTextBox.Clear();

            postTitleTextBox.Focus();
            editPostButton.IsEnabled = false;
        }

        private void savePostButton_Click(object sender, RoutedEventArgs e)
        {

            if (isAdd == true)
            {
                this.Title = "Добавить должность";

                Post post = new Post();
                post.title = postTitleTextBox.Text;

                if (AddDefend.AddPostTitle(post.title) == true)
                {
                    try
                    {
                        using (var Db = new DatabaseContext())
                        {
                            Db.Post.Add(post);
                            Db.SaveChanges();
                        }

                        MessageBox.Show("Данные о должности добавлены успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка добавления данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                editPostButton.IsEnabled = true;
            }
            else
            {
                int row = postDataGrid.SelectedIndex;
                int id = Convert.ToInt32((postDataGrid.Columns[0].GetCellContent(postDataGrid.Items[row]) as TextBlock).Text);

                Post post = new Post();

                try
                {
                    using (var Db = new DatabaseContext())
                    {
                        post = Db.Post.FirstOrDefault(p => p.id == id);

                        Db.Post.Find(post.id).title = postTitleTextBox.Text;

                        if (AddDefend.AddPostTitle(post.title) == true)
                        {
                            Db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Возможно, были введены некорректные данные! Попробуйте ещё раз.", "Ошибка изменения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    MessageBoxResult result = new MessageBoxResult();
                    result=MessageBox.Show("Данные о должности успешно изменены!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (result==MessageBoxResult.OK)
                    {
                        postTitleTextBox.Clear();
                        addPostButton.IsEnabled = true;
                        deletePostButton.IsEnabled = true;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            RefreshPostDataGrid();
        }

        private void editPostButton_Click(object sender, RoutedEventArgs e)
        {
            addPostButton.IsEnabled = false;
            deletePostButton.IsEnabled = false;

            this.Title = "Редактировать должность";

            Post post = new Post();

            int row = postDataGrid.SelectedIndex;
            int id = Convert.ToInt32((postDataGrid.Columns[0].GetCellContent(postDataGrid.Items[row]) as TextBlock).Text);

            try
            {
                using (var Db = new DatabaseContext())
                {
                    post = Db.Post.FirstOrDefault(p => p.id == id);
                }

                postTitleTextBox.Text = post.title;
                isAdd = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }       
        }

        private void deletePostButton_Click(object sender, RoutedEventArgs e)
        {
            int row = postDataGrid.SelectedIndex;
            int id = Convert.ToInt32((postDataGrid.Columns[0].GetCellContent(postDataGrid.Items[row]) as TextBlock).Text);

            editPostButton.IsEnabled = false;

            try
            {
                using (var Db = new DatabaseContext())
                {
                    Db.Post.Remove(Db.Post.FirstOrDefault(p => p.id == id));
                    Db.SaveChanges();
                }

                MessageBoxResult result = new MessageBoxResult();
                result = MessageBox.Show("Данные о должности успешно удалены!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    editPostButton.IsEnabled = true;
                }

                RefreshPostDataGrid();

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
