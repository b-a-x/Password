using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Desktop.Win.Annotations;
using Desktop.Win.Model;

namespace Desktop.Win.ViewModel
{
    public class LessonVM : INotifyPropertyChanged
    {
        private Lesson lesson;

        internal LessonVM(Lesson lesson)
        {
            this.lesson = lesson;
        }
        internal LessonVM(IReadOnlyCollection<Lesson> lessons)
        {
            LessonList = new ObservableCollection<LessonVM>(lessons.Select(l=>new LessonVM(l)));
        }

        public ObservableCollection<LessonVM> LessonList { get; set; }

        public string Title
        {
            get => lesson.Title;
            set
            {
                lesson.Title = value;
                OnPropertyChanged(nameof(Lesson.Title));
            }
        }

        public string Author
        {
            get => lesson.Author;
            set
            {
                lesson.Author = value;
                OnPropertyChanged(nameof(Lesson.Author));
            }
        }

        public int Number
        {
            get => lesson.Number;
            set
            {
                lesson.Number = value;
                OnPropertyChanged(nameof(Lesson.Number));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}