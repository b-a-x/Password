using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Desktop.Win.Converters
{
    public class BooltoVisabilityConverter : IValueConverter
    {
        public Visibility OnTrue { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool == false)
            {
                return DependencyProperty.UnsetValue;
            }

            Visibility onfalse = OnTrue == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            return (bool)value ? OnTrue : onfalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
