using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Desktop.Win.Model;
using Desktop.Win.ViewModel;

namespace Desktop.Win.Pages
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            List<Lesson> lessons = new List<Lesson>
            {
                new Lesson
                {
                    Title = "asdasd",
                    Author = "asdasd",
                    Number = 2
                },
                new Lesson
                {
                    Title = "adfasf",
                    Author = "dgvsdvbs",
                    Number = 12
                },
                new Lesson
                {
                    Title = "fjfhkjf",
                    Author = "vzbfdhgkyui",
                    Number = 15
                },
                new Lesson
                {
                    Title = "fjfhkjf",
                    Author = "vzbfdhgkyui",
                    Number = 20
                }
            };

            LessonVM lessonVm = new LessonVM(lessons);
            this.DataContext = lessonVm;
        }
    }
}
