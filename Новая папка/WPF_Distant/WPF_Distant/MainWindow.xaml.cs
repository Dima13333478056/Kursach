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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Distant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new Profile();
        }
        private void Menu_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                string selectedPage = clickedLabel.Tag.ToString();

                switch (selectedPage)
                {
                    case "ProfilePage":
                        MainContent.Content = new Profile(); // Загрузка профиля
                        break;
                    case "LessonsPage":
                        MainContent.Content = new Lessons(); // Загрузка уроков
                        break;
                    case "HomeworkPage":
                        MainContent.Content = new Homework(); // Загрузка домашних заданий
                        break;
                    default:
                        MessageBox.Show("Неизвестная страница!");
                        break;
                }
            }
        }
    }
}
