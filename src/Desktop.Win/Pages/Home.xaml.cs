using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Desktop.Win.Data;
using Desktop.Win.Model;
using Desktop.Win.ViewModel;

namespace Desktop.Win.Pages
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            this.Loaded += HomeLoaded;
        }

        private void HomeLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
                HomePageListView.ItemsSource = context.PasswordInfos.Select(x => new PasswordInfoVM(x));
        }

        private void HomeCreateOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PasswordInfoPage));
        }

        private void HomeUpdateOnClick(object sender, RoutedEventArgs e)
        {
            if (HomePageListView?.SelectedItem is PasswordInfoVM info)
                Frame.Navigate(typeof(PasswordInfoPage), info.Id);
        }

        private void HomeDeleteOnClick(object sender, RoutedEventArgs e)
        {
            if (HomePageListView?.SelectedItem is PasswordInfoVM info)
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    PasswordInfo password = context.PasswordInfos.Find(info.Id);
                    if (password != null)
                    {
                        context.PasswordInfos.Remove(password);
                        context.SaveChanges();
                        HomePageListView.ItemsSource = context.PasswordInfos.ToList();
                    }
                }
            }
        }
    }
}