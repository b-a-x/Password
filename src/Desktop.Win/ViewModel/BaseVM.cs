using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop.Win.Annotations;

namespace Desktop.Win.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            bool propertyChanged = false;
            if (EqualityComparer<T>.Default.Equals(field, value) == false)
            {
                field = value;
                OnPropertyChanged(propertyName);
                propertyChanged = true;
            }

            return propertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
