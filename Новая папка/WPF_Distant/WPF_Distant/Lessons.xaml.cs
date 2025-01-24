using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Lessons.xaml
    /// </summary>
    /// 
    public class Lesson
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public partial class Lessons : UserControl
    {
        public ObservableCollection<string> LessonsListCollection { get; set; }
        public Dictionary<string, ObservableCollection<Lesson>> LessonsCollection { get; set; }
        public ObservableCollection<Lesson> CurrentLessonList { get; set; }
        public Lessons()
        {
            InitializeComponent();
            // Инициализация коллекции
            LessonsListCollection = new ObservableCollection<string>();

            // Привязка коллекции к ListBox
            LessonsList.ItemsSource = LessonsListCollection;
            LessonsCollection = new Dictionary<string, ObservableCollection<Lesson>>()
            {
                { "Предмет 1", new ObservableCollection<Lesson>()
                    {
                        new Lesson() { Title = "Химические реакции", Description = "Описание: В этом уроке мы изучим химические реакции." },
                        new Lesson() { Title = "Математика", Description = "Описание: Этот урок посвящен математике." },
                        new Lesson() { Title = "Физика", Description = "Описание: В этом уроке мы разберем законы физики." }
                    }
                },
                { "Предмет 2", new ObservableCollection<Lesson>()
                    {
                        new Lesson() { Title = "Биология", Description = "Описание: Этот урок посвящен биологии." },
                        new Lesson() { Title = "Литература", Description = "Описание: Мы рассмотрим классическую литературу." },
                        new Lesson() { Title = "История", Description = "Описание: В этом уроке мы изучаем историю." }
                    }
                },
                { "Предмет 3", new ObservableCollection<Lesson>()
                    {
                        new Lesson() { Title = "География", Description = "Описание: Этот урок посвящен географии." },
                        new Lesson() { Title = "Информатика", Description = "Описание: В этом уроке мы изучим основы информатики." },
                        new Lesson() { Title = "Искусство", Description = "Описание: Мы поговорим об искусстве." }
                    }
                }
            };

            // Инициализация выбранной темы
            CurrentLessonList = new ObservableCollection<Lesson>();
            LessonsList.ItemsSource = CurrentLessonList;
        }
        private void DownloadMaterial_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Скачивание началась");
        }
        //private void LessonsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Очищаем текущий список
        //    LessonsListCollection.Clear();

        //    // Добавляем соответствующие уроки в зависимости от выбранного предмета
        //    if (LessonsCB.SelectedIndex == 0) // Предмет 1
        //    {
        //        LessonsListCollection.Add("1.1 Урок Химии");
        //        LessonsListCollection.Add("1.2 Урок Математики");
        //        LessonsListCollection.Add("1.3 Урок Физики");
        //    }
        //    else if (LessonsCB.SelectedIndex == 1) // Предмет 2
        //    {
        //        LessonsListCollection.Add("2.1 Урок Биологии");
        //        LessonsListCollection.Add("2.2 Урок Литературы");
        //        LessonsListCollection.Add("2.3 Урок Истории");
        //    }
        //    else if (LessonsCB.SelectedIndex == 2) // Предмет 3
        //    {
        //        LessonsListCollection.Add("3.1 Урок Географии");
        //        LessonsListCollection.Add("3.2 Урок Информатики");
        //        LessonsListCollection.Add("3.3 Урок Искусства");
        //    }
        //}
        // Обработчик изменения предмета
        private void LessonsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LessonsCB.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedSubject = selectedItem.Content.ToString();

                // Очистить текущий список уроков
                CurrentLessonList.Clear();

                // Добавить уроки для выбранного предмета
                if (LessonsCollection.ContainsKey(selectedSubject))
                {
                    foreach (var lesson in LessonsCollection[selectedSubject])
                    {
                        CurrentLessonList.Add(lesson);
                    }
                }
            }
        }

        // Обработчик выбора темы урока
        private void LessonsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LessonsList.SelectedItem is Lesson selectedLesson)
            {
                // Обновить отображение выбранной темы
                TopicTitle.Text = selectedLesson.Title;
                LessonDescription.Text = selectedLesson.Description;
            }
        }
    }
}
